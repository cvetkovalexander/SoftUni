namespace P01_StudentSystem.Common;

public static class EntityValidations
{
    public static class Student
    {
        public const int NameMaxLength = 100;

        public const string PhoneNumberColumnType = "CHAR(10)";
    }

    public static class Course 
    {
        public const int NameMaxLength = 80;

        public const string PriceColumnType = "DECIMAL(8,2)";
    }

    public static class Resource 
    {
        public const int NameMaxLength = 50;

        public const string UrlColumnType = "VARCHAR(2048)";
    }

    public static class Homework 
    {
        public const string ContentColumnType = "VARCHAR(500)";
    }
}
