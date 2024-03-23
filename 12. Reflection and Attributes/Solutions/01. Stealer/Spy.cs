using System.Reflection;
using System.Text;

namespace Stealer;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldNames)
    {
        StringBuilder sb = new();
        sb.AppendLine($"Class under investigation: {className}");

        Type targetType = Type.GetType(className)!;
        FieldInfo[] fileInfos = targetType.GetFields((BindingFlags)60);

        Object target = Activator.CreateInstance(targetType)!;
        foreach (FieldInfo fi in fileInfos.Where(fi => fieldNames.Contains(fi.Name))) sb.AppendLine($"{fi.Name} - {fi.GetValue(target)}");

        return sb.ToString().Trim();
    }
}