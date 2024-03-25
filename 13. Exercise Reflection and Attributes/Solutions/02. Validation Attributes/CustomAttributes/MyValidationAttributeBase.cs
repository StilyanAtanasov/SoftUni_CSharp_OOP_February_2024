namespace ValidationAttributes.CustomAttributes;

[AttributeUsage(AttributeTargets.Property)]
public abstract class MyValidationAttributeBase : Attribute
{
    public abstract bool IsValid(object obj);
}