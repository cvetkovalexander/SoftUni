using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        using var context = new CarDealerContext();
        //context.Database.EnsureDeleted();
        //context.Database.EnsureCreated();

        string jsonFileDirPath = Path
            .Combine(Directory.GetCurrentDirectory(), "../../../Datasets/");

        string fileName = "cars.json";

        string jsonFile = File
            .ReadAllText(jsonFileDirPath + fileName);

        Console.WriteLine(ImportCars(context, jsonFile));

        //Console.WriteLine(GetOrderedCustomers(context));
    }

    // Problem 09
    public static string ImportSuppliers(CarDealerContext context, string inputJson) 
    {
        ICollection<Supplier> suppliersToImport = new List<Supplier>();

        IEnumerable<ImportSupplierDto>? supplierDtos = JsonConvert
            .DeserializeObject<ImportSupplierDto[]>(inputJson);

        if (supplierDtos != null) 
        {
            foreach (var supplierDto in supplierDtos) 
            {
                if (!IsValid(supplierDto))
                    continue;

                bool isImporterValid = bool
                    .TryParse(supplierDto.IsImporter, out bool isImporter);

                if (!isImporterValid)
                    continue;

                Supplier newSupplier = new Supplier()
                {
                    Name = supplierDto.Name,
                    IsImporter = isImporter
                };

                suppliersToImport.Add(newSupplier);
            }

            context.Suppliers.AddRange(suppliersToImport);
            context.SaveChanges();
        }

        return $"Successfully imported {suppliersToImport.Count}.";
    }

    // Problem 10
    public static string ImportParts(CarDealerContext context, string inputJson) 
    {
        ICollection<Part> partsToImport = new List<Part>();

        IEnumerable<ImportPartDto>? partDtos = JsonConvert
            .DeserializeObject<ImportPartDto[]>(inputJson);

        var existingSupplierIds = context
            .Suppliers
            .AsNoTracking()
            .Select(s => s.Id)
            .ToArray();

        if (partDtos != null) 
        {
            foreach (var partDto in partDtos) 
            {
                if (!IsValid(partDto))
                    continue;

                bool supplierIdValid = int
                    .TryParse(partDto.SupplierId, out int supplierId);

                if (!supplierIdValid || !existingSupplierIds.Contains(supplierId))
                    continue;

                Part newPart = new Part()
                {
                    Name = partDto.Name,
                    Price = partDto.Price,
                    Quantity = partDto.Quantity,
                    SupplierId = supplierId,
                };

                partsToImport.Add(newPart);
            }

            context.Parts.AddRange(partsToImport);
            context.SaveChanges();
        }

        return $"Successfully imported {partsToImport.Count}.";
    }

    // Problem 11
    public static string ImportCars(CarDealerContext context, string inputJson)
    {
        ICollection<Car> carsToImport = new List<Car>();
        ICollection<PartCar> partsCarsToImport = new List<PartCar>();

        IEnumerable<ImportCarDto>? carDtos = JsonConvert
            .DeserializeObject<ImportCarDto[]>(inputJson);
        if (carDtos != null)
        {
            foreach (ImportCarDto carDto in carDtos)
            {
                if (!IsValid(carDto))
                {
                    continue;
                }

                Car newCar = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance
                };
                carsToImport.Add(newCar);

                foreach (int partId in carDto.PartsIds.Distinct())
                {
                    if (!context.Parts.Any(p => p.Id == partId))
                    {
                        continue;
                    }

                    PartCar newPartCar = new PartCar()
                    {
                        PartId = partId,
                        Car = newCar
                    };
                    partsCarsToImport.Add(newPartCar);
                }
            }

            //context.Cars.AddRange(carsToImport); // Actually it's not needed, since EF will find the new cars from mapping entities
            context.PartsCars.AddRange(partsCarsToImport);

            context.SaveChanges();
        }

        return $"Successfully imported {carsToImport.Count}.";
    }

    // Problem 12
    public static string ImportCustomers(CarDealerContext context, string inputJson) 
    {
        ICollection<Customer> customersToImport = new List<Customer>();

        IEnumerable<ImportCustomerDto>? customerDtos = JsonConvert
            .DeserializeObject<ImportCustomerDto[]>(inputJson);

        if (customerDtos != null) 
        {
            foreach (var customerDto in customerDtos) 
            {
                bool isBirthdateValid = DateTime
                    .TryParseExact(customerDto.Birthdate, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None ,out DateTime birthdate);

                bool isYoungDriverValid = bool
                    .TryParse(customerDto.IsYoungDriver, out bool isYoungDriver);

                if (!isBirthdateValid || !isYoungDriverValid || !IsValid(customerDto))
                    continue;

                Customer newCustomer = new Customer()
                {
                    Name = customerDto.Name,
                    BirthDate = birthdate,
                    IsYoungDriver = isYoungDriver
                };

                customersToImport.Add(newCustomer);
            }

            context.Customers.AddRange(customersToImport);
            context.SaveChanges();
        }

        return $"Successfully imported {customersToImport.Count}.";
    }

    // Problem 13
    public static string ImportSales(CarDealerContext context, string inputJson)
    {
        ICollection<Sale> salesToImport = new List<Sale>();

        IEnumerable<ImportSaleDto>? saleDtos = JsonConvert
            .DeserializeObject<ImportSaleDto[]>(inputJson);
        if (saleDtos != null)
        {
            foreach (ImportSaleDto saleDto in saleDtos)
            {
                bool isCarIdExisting = context
                    .Cars
                    .Any(c => c.Id == saleDto.CarId);
                if (isCarIdExisting)
                    continue;

                bool isCustomerIdExisting = context
                    .Customers
                    .Any(cu => cu.Id == saleDto.CustomerId);
                if (isCustomerIdExisting)
                {
                    continue;
                }

                Sale newSale = new Sale()
                {
                    CarId = saleDto.CarId,
                    CustomerId = saleDto.CustomerId,
                    Discount = saleDto.Discount
                };
                salesToImport.Add(newSale);
            }

            context.Sales.AddRange(salesToImport);
            context.SaveChanges();
        }

        return $"Successfully imported {salesToImport.Count}.";
    }

    // Problem 14
    public static string GetOrderedCustomers(CarDealerContext context) 
    {
        var res = context
            .Customers
            .AsNoTracking()
            .Select(c => new
            {
                c.Name,
                c.BirthDate,
                c.IsYoungDriver
            })
            .OrderBy(c => c.BirthDate)
            .ThenBy(c => c.IsYoungDriver)
            .ToArray();

        var dtos = res
            .Select(r => new
            {
                r.Name,
                BirthDate = r.BirthDate.ToString("dd/MM/yyyy"),
                r.IsYoungDriver
            })
            .ToArray();

        return JsonConvert
            .SerializeObject(dtos, Formatting.Indented);
    }

    // Problem 15
    public static string GetCarsFromMakeToyota(CarDealerContext context) 
    {
        var res = context
            .Cars
            .AsNoTracking()
            .Where(c => c.Make == "Toyota")
            .Select(c => new
            {
                c.Id,
                c.Make,
                c.Model,
                c.TraveledDistance
            })
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .ToArray();

        return JsonConvert
            .SerializeObject(res, Formatting.Indented);
    }

    // Problem 16
    public static string GetLocalSuppliers(CarDealerContext context) 
    {
        var res = context
            .Suppliers
            .AsNoTracking()
            .Where(s => !s.IsImporter)
            .Select(s => new
            {
                s.Id,
                s.Name,
                PartsCount = s.Parts.Count
            })
            .ToArray();

        return JsonConvert
            .SerializeObject(res, Formatting.Indented);
    }

    // Problem 17
    public static string GetCarsWithTheirListOfParts(CarDealerContext context) 
    {
        var result = context
            .Cars
            .Where(c => c.PartsCars.Any())
            .AsNoTracking()
            .Select(c => new
            {
                Car = new
                {
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                },
                Parts = c.PartsCars
                    .Select(pc => new
                    {
                        pc.Part.Name,
                        Price = pc.Part.Price.ToString("f2")
                    })
                    .ToArray()
            })
            .ToArray();

        var resultDtos = result
            .Select(r => new
            {
                car = r.Car,
                parts = r.Parts
            })
            .ToArray();

        return JsonConvert
            .SerializeObject(resultDtos);
    }

    // Problem 18
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        var result = context
            .Customers
            .AsNoTracking()
            .Where(c => c.Sales.Any())
            .Select(c => new
            {
                fullName = c.Name,
                boughtCars = c.Sales.Count,
                spentMoney = c.Sales
                    .Select(s => s.Car)
                    .SelectMany(ca => ca.PartsCars)
                    .Select(pc => pc.Part)
                    .Sum(p => p.Price)
            })
            .OrderByDescending(c => c.spentMoney)
            .ThenByDescending(c => c.boughtCars)
            .ToArray();


        return JsonConvert
            .SerializeObject(result, Formatting.Indented);
    }

        // Problem 19
    public static string GetSalesWithAppliedDiscount(CarDealerContext context) 
    {
        var top10Sales = context
            .Sales
            .AsNoTracking()
            .Select(s => new
            {
                Car = new
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TraveledDistance = s.Car.TraveledDistance
                },
                CustomerName = s.Customer.Name,
                s.Discount,
                Price = s.Car.PartsCars
                    .Select(pc => pc.Part)
                    .Sum(p => p.Price)
            })
            .Take(10)
            .ToArray();

        var saleExportDtos = top10Sales
            .Select(s => new 
            {
                car = s.Car,
                customerName = s.CustomerName,
                discount = s.Discount.ToString("f2"),
                price = s.Price.ToString("f2"),
                priceWithDiscount = (s.Price - (s.Price * (s.Discount / 100)))
                                                               .ToString("f2")
            })
            .ToArray();

        string jsonRes = JsonConvert
            .SerializeObject(saleExportDtos, Formatting.Indented);

        return jsonRes;
    }

    // Validation Method (not needed for Judge)
    private static bool IsValid(object obj) 
    {
        // These two variables are required by the Validator.TryValidateObject method
        // We will not use them for now...
        // We are just using the Validation result (true or false)


        ValidationContext validationContext = new ValidationContext(obj);
        ICollection<ValidationResult> validationResults
            = new List<ValidationResult>();

        return Validator
            .TryValidateObject(obj, validationContext, validationResults);
    }
}