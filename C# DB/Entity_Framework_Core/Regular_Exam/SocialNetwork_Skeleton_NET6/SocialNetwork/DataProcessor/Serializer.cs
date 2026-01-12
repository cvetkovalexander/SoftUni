using Microsoft.EntityFrameworkCore;
using NetPay.Utilities;
using Newtonsoft.Json;
using SocialNetwork.Data;
using SocialNetwork.DataProcessor.ExportDTOs;

namespace SocialNetwork.DataProcessor
{
    public class Serializer
    {
        public static string ExportUsersWithFriendShipsCountAndTheirPosts(SocialNetworkDbContext context)
        {
            const string xmlRootName = "Users";

            ExportUserDto[] dtos = context
                .Users
                .AsNoTracking()
                .OrderBy(u => u.Username)
                .Select(u => new ExportUserDto()
                {
                    Friendships = context.Friendships.Count(f => f.UserOneId == u.Id || f.UserTwoId == u.Id).ToString(),
                    Username = u.Username,
                    Posts = u.Posts
                        .OrderBy(p => p.Id)
                        .Select(p => new ExportPostDto()
                        {
                            Content = p.Content,
                            CreatedAt = p.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss")
                        })
                        .ToArray()
                })
                .ToArray();

            return XmlSerializerWrapper
                .Serialize(dtos, xmlRootName);

        }

        public static string ExportConversationsWithMessagesChronologically(SocialNetworkDbContext context)
        {
            var dtos = context
                .Conversations
                .AsNoTracking()
                .OrderBy(c => c.StartedAt)
                .Select(c => new
                {
                    Id = c.Id,
                    Title = c.Title,
                    StartedAt = c.StartedAt.ToString("yyyy-MM-ddTHH:mm:ss"),
                    Messages = c.Messages
                        .OrderBy(m => m.SentAt)
                        .Select(m => new
                        {
                            Content = m.Content,
                            SentAt = m.SentAt.ToString("yyyy-MM-ddTHH:mm:ss"),
                            Status = m.Status,
                            SenderUsername = m.Sender.Username
                        })
                        .ToArray()
                })
                .ToArray();

            return JsonConvert
                .SerializeObject(dtos, Formatting.Indented);
        }
    }
}
