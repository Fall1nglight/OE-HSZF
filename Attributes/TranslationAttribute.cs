namespace Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
public class TranslationAttribute : Attribute
{
    public string Language { get; set; }
    public string Text { get; set; }

    public TranslationAttribute(string language, string text)
    {
        Language = language;
        Text = text;
    }
}
