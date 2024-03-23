using System.Reflection;
using System.Text;

namespace Stealer;

public class Spy
{
    public string AnalyzeAccessModifiers(string className)
    {
        StringBuilder sb = new();

        Object target = Activator.CreateInstance(Type.GetType(className)!)!;
        Type targetType = target.GetType();


        foreach (FieldInfo fieldInfo in targetType.GetFields((BindingFlags)60)) if (!fieldInfo.IsPrivate) sb.AppendLine($"{fieldInfo.Name} must be private!");
        foreach (MethodInfo methodInfo in targetType.GetMethods((BindingFlags)60).Where(m => m.Name.StartsWith("get")))
            if (!methodInfo.IsPublic) sb.AppendLine($"{methodInfo.Name} have to be public!");
        foreach (MethodInfo methodInfo in targetType.GetMethods((BindingFlags)60).Where(m => m.Name.StartsWith("set")))
            if (!methodInfo.IsPrivate) sb.AppendLine($"{methodInfo.Name} have to be private!");

        return sb.ToString().Trim();
    }
}