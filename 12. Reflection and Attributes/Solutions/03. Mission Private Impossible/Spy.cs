using System.Reflection;
using System.Text;

namespace Stealer;

public class Spy
{
    public string RevealPrivateMethods(string className)
    {
        StringBuilder sb = new();

        object target = Activator.CreateInstance(Type.GetType(className)!)!;
        Type targetType = target.GetType();

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {targetType.BaseType}");

        foreach (MethodInfo privateMethod in targetType.GetMethods((BindingFlags)60).Where(m => m.IsPrivate))
            sb.AppendLine(privateMethod.Name);

        return sb.ToString().Trim();
    }
}