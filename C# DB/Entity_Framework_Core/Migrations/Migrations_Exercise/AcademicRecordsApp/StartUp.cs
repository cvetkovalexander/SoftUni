using AcademicRecordsApp.Data;
 
namespace AcademicRecordsApp;

public class StartUp
{
    static void Main(string[] args)
    {
        var context = new AcademicRecordsDbContext();
    }
}
