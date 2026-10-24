using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace c5m._2d6Dungeon.web.Components.Dialogues;

/// <summary>
/// Base class for the app's dialogs on Fluent UI v5.
/// It keeps the v4 shape the dialogs were written with: a <c>Content</c> parameter that is
/// returned to the caller when the primary button is clicked, and <see cref="TogglePrimaryActionButton"/>.
/// </summary>
public abstract class AppDialogBase<TContent> : FluentDialogInstance
{
    [Parameter]
    public TContent Content { get; set; } = default!;

    protected void TogglePrimaryActionButton(bool enabled)
    {
        DialogInstance.Options.Footer.PrimaryAction.Disabled = !enabled;
        StateHasChanged();
    }

    protected Task CloseAsync(object? value) => DialogInstance.CloseAsync(value);

    protected override Task OnActionClickedAsync(bool primary)
        => primary ? DialogInstance.CloseAsync(Content) : DialogInstance.CancelAsync();
}
