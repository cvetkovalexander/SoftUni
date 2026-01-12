using Microsoft.EntityFrameworkCore;
using NetPay.Data;
using NetPay.Data.Models;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ExportDtos;
using NetPay.Utilities;
using Newtonsoft.Json;

namespace NetPay.DataProcessor
{
    public class Serializer
    {
        public static string ExportHouseholdsWhichHaveExpensesToPay(NetPayContext context)
        {
            const string xmlRootName = "Households";

            ExportHouseholdDto[] dtos = context
                .Households
                .AsNoTracking()
                .Include(h => h.Expenses)
                .ThenInclude(e => e.Service)
                .Where(h => h.Expenses.Any(e => e.PaymentStatus != PaymentStatus.Paid))
                .OrderBy(h => h.ContactPerson)
                .ToArray()
                .Select(h => new ExportHouseholdDto()
                {
                    ContactPerson = h.ContactPerson,
                    Email = h.Email,
                    PhoneNumber = h.PhoneNumber,
                    Expenses = h.Expenses
                        .Where(e => e.PaymentStatus != PaymentStatus.Paid)
                        .Select(e => new ExportHouseholdExpenseDto()
                        {
                            ExpenseName = e.ExpenseName,
                            Amount = e.Amount.ToString("f2"),
                            PaymentDate = e.DueDate.ToString("yyyy-MM-dd"),
                            ServiceName = e.Service.ServiceName
                        })
                        .OrderBy(e => e.PaymentDate)
                        .ThenBy(e => e.Amount)
                        .ToArray()
                })
                .ToArray();

            return XmlSerializerWrapper
                .Serialize(dtos, xmlRootName);
        }

        public static string ExportAllServicesWithSuppliers(NetPayContext context)
        {
             var servicesWithSuppliers = context
                .Services
                .AsNoTracking()
                .Select(s => new 
                {
                    ServiceName = s.ServiceName,
                    Suppliers = s.SuppliersServices
                        .Select(ss => ss.Supplier)
                        .OrderBy(sup => sup.SupplierName)
                        .Select(sup => new 
                        {
                            SupplierName = sup.SupplierName
                        })
                        .ToArray()
                })
                .OrderBy(s => s.ServiceName)
                .ToArray();

            return JsonConvert
                .SerializeObject(servicesWithSuppliers, Formatting.Indented);
        }
    }
}
