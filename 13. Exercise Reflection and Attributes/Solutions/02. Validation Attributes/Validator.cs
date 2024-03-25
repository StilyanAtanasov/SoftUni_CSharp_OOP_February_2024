using System.Reflection;
using ValidationAttributes.CustomAttributes;

namespace ValidationAttributes;

public static class Validator
{
    public static bool IsValid(object obj)
    {
        Type objType = obj.GetType();

        foreach (PropertyInfo prop in objType.GetProperties())
            foreach (var attr in prop.GetCustomAttributes(typeof(MyValidationAttributeBase), inherit: true).Cast<MyValidationAttributeBase>())
                if (!attr.IsValid(prop.GetValue(obj)!)) return false;

        return true;
    }
}