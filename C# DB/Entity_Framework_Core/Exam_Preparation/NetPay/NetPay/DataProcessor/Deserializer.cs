using NetPay.Data;
using NetPay.Data.Models;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ImportDtos;
using NetPay.Utilities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net;
using System.Text;

namespace NetPay.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";
        private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

        public static string ImportHouseholds(NetPayContext context, string xmlString)
        {
            const string xmlRootName = "Households";

            StringBuilder output = new StringBuilder();
            ICollection<Household> validHouseholds = new List<Household>();

            IEnumerable<ImportHouseholdDto>? dtos = XmlSerializerWrapper
                .Deserialize<ImportHouseholdDto[]>(xmlString, xmlRootName);

            if (dtos != null) 
            {
                foreach (var dto in dtos) 
                {
                    if (!IsValid(dto)) 
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool householdExists = context
                        .Households
                        .Any(h => h.ContactPerson == dto.ContactPerson ||
                                    h.PhoneNumber == dto.PhoneNumber ||
                                    (h.Email != null && h.Email == dto.Email));

                    bool householdAlreadyImported = validHouseholds
                        .Any(h => h.ContactPerson == dto.ContactPerson ||
                                    h.PhoneNumber == dto.PhoneNumber ||
                                    (h.Email != null && h.Email == dto.Email));

                    if (householdExists || householdAlreadyImported)
                    {
                        output.AppendLine(DuplicationDataMessage);
                        continue;
                    }

                    Household newHousehold = new Household()
                    {
                        ContactPerson = dto.ContactPerson,
                        Email = dto.Email,
                        PhoneNumber = dto.PhoneNumber
                    };

                    validHouseholds.Add(newHousehold);

                    output.AppendLine(String
                        .Format(SuccessfullyImportedHousehold, dto.ContactPerson));
                }

                context.Households.AddRange(validHouseholds);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportExpenses(NetPayContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();
            ICollection<Expense> validExpenses = new List<Expense>();

            IEnumerable<ImportExpenseDto>? dtos = JsonConvert
                .DeserializeObject<ImportExpenseDto[]>(jsonString);

            if (dtos != null) 
            {
                foreach (var dto in dtos) 
                {
                    if (!IsValid(dto)) 
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool householdExists = context
                        .Households
                        .Any(h => h.Id == dto.HouseholdId!.Value);
                    bool serviceExists = context
                        .Services
                        .Any(s => s.Id == dto.ServiceId!.Value);

                    if (!householdExists ||
                        !serviceExists) 
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isDueDateValid = DateTime
                        .TryParseExact(dto.DueDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dueDateVal);

                    bool isPaymentStatusValid = Enum
                        .TryParse<PaymentStatus>(dto.PaymentStatus, out PaymentStatus paymentStatusVal);

                    if (!isDueDateValid ||
                        !isPaymentStatusValid) 
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Expense newExpense = new Expense() 
                    {
                        ExpenseName = dto.ExpenseName,
                        Amount = dto.Amount!.Value,
                        DueDate = dueDateVal,
                        PaymentStatus = paymentStatusVal,
                        HouseholdId = dto.HouseholdId!.Value,
                        ServiceId = dto.ServiceId!.Value,
                    };

                    validExpenses.Add(newExpense);

                    output.AppendLine(String.Format(SuccessfullyImportedExpense,
                        dto.ExpenseName, dto.Amount.Value.ToString("f2")));
                }

                context.Expenses.AddRange(validExpenses);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach(var result in validationResults)
            {
                string currvValidationMessage = result.ErrorMessage;
            }

            return isValid;
        }
    }
}
