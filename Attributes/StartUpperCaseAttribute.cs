namespace Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class StartUpperCaseAttribute : Attribute
{
    public StartUpperCaseAttribute() { }
}
