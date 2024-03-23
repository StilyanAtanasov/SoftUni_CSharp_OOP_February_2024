using System.Reflection;
using System.Text;

namespace Stealer;

public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        StringBuilder sb = new();

        object target = Activator.CreateInstance(Type.GetType(className)!)!;
        Type targetType = target.GetType();

        MethodInfo[] targetMethods = targetType.GetMethods((BindingFlags)60);

        foreach (MethodInfo methodInfo in targetMethods.Where(m => m.Name.StartsWith("set")))
            sb.AppendLine($"{methodInfo.Name} will set field of {methodInfo.GetParameters().First().ParameterType}");
        foreach (MethodInfo methodInfo in targetMethods.Where(m => m.Name.StartsWith("get")))
            sb.AppendLine($"{methodInfo.Name} will return {methodInfo.ReturnType}");


        return sb.ToString().Trim();
    }
}