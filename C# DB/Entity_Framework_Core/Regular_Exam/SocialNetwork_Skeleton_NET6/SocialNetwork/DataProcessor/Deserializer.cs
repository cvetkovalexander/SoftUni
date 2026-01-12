using NetPay.Utilities;
using Newtonsoft.Json;
using SocialNetwork.Data;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.Enums;
using SocialNetwork.DataProcessor.ImportDTOs;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace SocialNetwork.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format.";
        private const string DuplicatedDataMessage = "Duplicated data.";
        private const string SuccessfullyImportedMessageEntity = "Successfully imported message (Sent at: {0}, Status: {1})";
        private const string SuccessfullyImportedPostEntity = "Successfully imported post (Creator {0}, Created at: {1})";

        public static string ImportMessages(SocialNetworkDbContext context, string xmlString)
        {
            const string xmlRootName = "Messages";

            StringBuilder output = new StringBuilder();
            ICollection<Message> validMessages = new List<Message>();

            IEnumerable<ImportMessageDto>? dtos = XmlSerializerWrapper
                .Deserialize<ImportMessageDto[]>(xmlString, xmlRootName);

            if (dtos != null) 
            {
                foreach (var dto in dtos)
                {
                    if (!IsValid(dto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isSentAtValid = DateTime
                        .TryParseExact(dto.SentAt, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var sentAt);

                    bool isStatusValid = Enum
                        .TryParse<MessageStatus>(dto.Status, out var status);

                    bool isConversationIdValid = int
                        .TryParse(dto.ConversationId, out var conversationId);

                    if (!context.Conversations.Any(c => c.Id == conversationId)) 
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isSenderIdValid = int
                        .TryParse(dto.SenderId, out var senderId);

                    if (!context.Users.Any(u => u.Id == senderId)) 
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!isSentAtValid || !isStatusValid || !isConversationIdValid || !isSenderIdValid)

                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (context
                        .Messages
                        .Any(m => m.ConversationId == conversationId && m.Content == dto.Content && m.SentAt == sentAt && m.Status == status && m.SenderId == senderId)) 
                    {
                        output.AppendLine(DuplicatedDataMessage);
                        continue;
                    }

                    if (validMessages
                        .Any(m => m.ConversationId == conversationId && m.Content == dto.Content && m.SentAt == sentAt && m.Status == status && m.SenderId == senderId)) 
                    {
                        output.AppendLine(DuplicatedDataMessage);
                        continue;
                    }

                    Message message = new Message()
                    {
                        Content = dto.Content,
                        SentAt = sentAt,
                        Status = status,
                        SenderId = senderId,
                        ConversationId = conversationId
                    };

                    validMessages.Add(message);
                    output.AppendLine($"Successfully imported message (Sent at: {sentAt.ToString("yyyy-MM-ddTHH:mm:ss")}, Status: {status})");
                }

                context.Messages.AddRange(validMessages);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportPosts(SocialNetworkDbContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();
            ICollection<Post> validPosts = new List<Post>();

            IEnumerable<ImportPostDto>? dtos = JsonConvert
                .DeserializeObject<ImportPostDto[]>(jsonString);

            if (dtos != null) 
            {
                foreach (var dto in dtos) 
                {
                    if (!IsValid(dto)) 
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isCreatedAtValid = DateTime
                        .TryParseExact(dto.CreatedAt, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var createdAt);

                    bool isCreatorIdValid = int
                        .TryParse(dto.CreatorId, out var creatorId);

                    if (!isCreatedAtValid || !isCreatorIdValid) 
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!context.Users.Any(u => u.Id == creatorId)) 
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (context.Posts.Any(p => p.Content == dto.Content && p.CreatedAt == createdAt && p.CreatorId == creatorId)) 
                    {
                        output.AppendLine(DuplicatedDataMessage);
                        continue;
                    }

                    if (validPosts.Any(p => p.Content == dto.Content && p.CreatedAt == createdAt && p.CreatorId == creatorId)) 
                    {
                        output.AppendLine(DuplicatedDataMessage);
                        continue;
                    }

                    Post post = new Post() 
                    {
                        Content = dto.Content,
                        CreatedAt = createdAt,
                        CreatorId = creatorId
                    };

                    var creator = context.Users.Where(u => u.Id == creatorId).FirstOrDefault();

                    validPosts.Add(post);
                    output.AppendLine($"Successfully imported post (Creator {creator.Username}, Created at: {createdAt.ToString("yyyy-MM-ddTHH:mm:ss")})");
                }

                context.Posts.AddRange(validPosts);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            ValidationContext validationContext = new ValidationContext(dto);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach (ValidationResult validationResult in validationResults)
            {
                if (validationResult.ErrorMessage != null)
                {
                    string currentMessage = validationResult.ErrorMessage;
                }
            }

            return isValid;
        }
    }
}
