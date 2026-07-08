using Microsoft.AspNetCore.Components;
using Portfolio.Services;

namespace Portfolio.Components;

public abstract class I18nComponentBase : ComponentBase, IDisposable
{
    [Inject] protected I18nService I18n { get; set; } = default!;

    protected override void OnInitialized()
    {
        I18n.OnChange += HandleI18nChange;
    }

    private void HandleI18nChange() => InvokeAsync(StateHasChanged);

    public void Dispose()
    {
        I18n.OnChange -= HandleI18nChange;
    }
}
