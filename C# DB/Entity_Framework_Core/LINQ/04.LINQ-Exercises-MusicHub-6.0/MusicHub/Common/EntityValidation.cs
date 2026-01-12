namespace MusicHub.Common;

public static class EntityValidation
{
    public static class Song 
    {
        public const int NameMaxLength = 20;

        public const string PriceColumnType = "DECIMAL(8,2)";
    }

    public static class Album 
    {
        public const int NameMaxLength = 40;

        public const string PriceColumnType = "DECIMAL(12,2)";
    }

    public static class Producer 
    {
        public const int NameMaxLength = 30;
    }

    public static class Writer 
    {
        public const int NameMaxLength = 20;
    }

    public static class Performer 
    {
        public const int NameMaxLength = 20;

        public const string NetWorthColumnType = "DECIMAL(15,2)";
    }
}
