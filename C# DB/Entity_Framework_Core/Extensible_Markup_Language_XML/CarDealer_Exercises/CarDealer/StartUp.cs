using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Export.Problem_18;
using CarDealer.DTOs.Export.Problem_19;
using CarDealer.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new CarDealerContext();

        Console.WriteLine(GetSalesWithAppliedDiscount(context));
    }

    // Problem 18
    public static string GetTotalSalesByCustomer(CarDealerContext context) 
    {
        var temp = context
            .Customers
            .AsNoTracking()
            .Where(c => c.Sales.Any())
            .Select(c => new 
            {
                FullName = c.Name,
                BoughtCars = c.Sales.Count,
                SalesInfo = c.Sales
                    .Select(s => new 
                    {
                        Prices = c.IsYoungDriver
                            ? s.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price * 0.95, 2))
                            : s.Car.PartsCars.Sum(pc => (double)pc.Part.Price)
                    })
                    .ToArray()
            })
            .ToArray();

        ExportCustomerTotalSalesDto dto = new ExportCustomerTotalSalesDto() 
        {
            Customers = temp
                .Select(c => new ExportCustomerDto() 
                {
                    FullName = c.FullName,
                    BoughtCars = c.BoughtCars,
                    SpentMoney = c.SalesInfo
                        .Sum(si => (decimal)si.Prices)

                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray()
        };

        return XmlSerializerWrapper
            .Serialize(dto, "customers");
    }

    // Problem 19
    public static string GetSalesWithAppliedDiscount(CarDealerContext context) 
    {
        var temp = context
            .Sales
            .AsNoTracking()
            .Select(s => new
            {
                Car = s.Car,
                Discount = (double)s.Discount,
                CustomerName = s.Customer.Name,
                Price = s.Car.PartsCars
                    .Sum(pc => pc.Part.Price),
                PriceWithDiscount = (s.Car.PartsCars
                    .Sum(pc => pc.Part.Price) * (1 - s.Discount / 100m))
            })
            .ToArray();


        ExportSalesWithDiscountDto dto = new ExportSalesWithDiscountDto()
        {
            Sales = temp
                .Select(s => new ExportSaleDto()
                {
                    Car = new ExportCarDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = (decimal)s.Discount,
                    CustomerName = s.CustomerName,
                    Price = s.Price,
                    PriceWithDiscount = decimal.Parse(s.PriceWithDiscount.ToString("0.####")),
                })
                .ToArray()
        };

        //var salesRaw = context.Sales
        //.AsNoTracking()
        //.Select(s => new
        //{
        //    CarMake = s.Car.Make,
        //    CarModel = s.Car.Model,
        //    CarDistance = s.Car.TraveledDistance,
        //    Discount = s.Discount,
        //    CustomerName = s.Customer.Name,
        //    Price = s.Car.PartsCars.Sum(pc => pc.Part.Price)
        //})
        //.ToArray();

        //var salesDtos = salesRaw
        //.Select(s =>
        //{
        //    // сурова цена с отстъпка – до 4 знака след запетая
        //    decimal rawPriceWithDiscount =
        //        s.Price * (1 - s.Discount / 100m);

        //    // нормализиране: до 4 знака, но без излишни нули
        //    // "0.####" => максимум 4 десетични знака, без trailing zeros
        //    decimal normalizedPriceWithDiscount =
        //        decimal.Parse(rawPriceWithDiscount.ToString("0.####"));

        //    return new ExportSaleDto
        //    {
        //        Car = new ExportCarDto
        //        {
        //            Make = s.CarMake,
        //            Model = s.CarModel,
        //            TraveledDistance = s.CarDistance
        //        },
        //        Discount = s.Discount,
        //        CustomerName = s.CustomerName,
        //        Price = s.Price,
        //        PriceWithDiscount = normalizedPriceWithDiscount
        //    };
        //})
        //.ToArray();

        //var dto = new ExportSalesWithDiscountDto
        //{
        //    Sales = salesDtos
        //};

        return XmlSerializerWrapper
            .Serialize(dto, "sales");
    }
}