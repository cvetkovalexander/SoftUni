namespace SocialNetwork.Common;

public static class EntityValidation
{
    public static class User 
    {
        public const int UsernameMinLength = 4;
        public const int UsernameMaxLength = 20;
        public const int EmailMinLength = 8;
        public const int EmailMaxLength = 60;
        public const int PasswordMinLength = 6;
    }

    public static class Conversation 
    {
        public const int TitleMinLength = 2;
        public const int TitleMaxLength = 30;
    }

    public static class Post 
    {
        public const int ContentMinLength = 5;
        public const int ContentMaxLength = 300;
    }

    public static class Message 
    {
        public const int ContentMinLength = 1;
        public const int ContentMaxLength = 200;
    }
}
