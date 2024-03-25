namespace ValidationAttributes.CustomAttributes;

public class MyRequiredAttribute : MyValidationAttributeBase
{
    public override bool IsValid(object obj) => obj != null;
}