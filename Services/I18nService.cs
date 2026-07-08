namespace Portfolio.Services;

public sealed class I18nService
{
    public string Language { get; private set; } = "en";

    public event Action? OnChange;

    public void SetLanguage(string lang)
    {
        if (lang != Language && (lang == "en" || lang == "sr"))
        {
            Language = lang;
            OnChange?.Invoke();
        }
    }

    public void Toggle() => SetLanguage(Language == "en" ? "sr" : "en");

    public string T(string key) => Translations.Get(key, Language);
}
