using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer.Reflection;

public class Spy
{

    public string StealFieldInfo(string className, params string[] reguestedFields)
    {
        Type? classType = Type.GetType(className);
        FieldInfo[] fields = classType.GetFields((BindingFlags)60);
        StringBuilder sb = new();

        object? instance = Activator.CreateInstance(classType, new object[] { });

        sb.AppendLine($"Class under investigation: {className}");

        foreach (FieldInfo field in fields.Where(f => reguestedFields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAccessModifiers(string className)
    {
        Type? type = Type.GetType(className);
        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        MethodInfo[] privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        StringBuilder sb = new();

        foreach (FieldInfo field in fields)
            sb.AppendLine($"{field.Name} must be private!");
        foreach (MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
            sb.AppendLine($"{method.Name} have to be private!");
        foreach (MethodInfo method in privateMethods.Where(m => m.Name.StartsWith("get")))
            sb.AppendLine($"{method.Name} have to be public!");

        return sb.ToString().Trim();

    }

    public string RevealPrivateMethods(string className)
    {
        Type? type = Type.GetType(className);
        MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        StringBuilder sb = new();

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        foreach (MethodInfo method in methods)
            sb.AppendLine(method.Name);

        return sb.ToString().Trim();
    }

    public string CollectGettersAndASetters(string className)
    {
        Type? type = Type.GetType(className);

        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        StringBuilder sb = new();

        foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("get")))
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");

        foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("set")))
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");

        return sb.ToString().Trim();
    }
}
