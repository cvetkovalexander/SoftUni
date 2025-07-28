namespace Stealer.Reflection;

public class Program
{
    static void Main(string[] args)
    {
        string className = "Stealer.Hacker";
        Spy spy = new();
        //Console.WriteLine(spy.StealFieldInfo("className", "username"));

        //Console.WriteLine(spy.AnalyzeAccessModifiers("className"));

        //Console.WriteLine(spy.RevealPrivateMethods(className));

        Console.WriteLine(spy.CollectGettersAndASetters(className));
    }
}