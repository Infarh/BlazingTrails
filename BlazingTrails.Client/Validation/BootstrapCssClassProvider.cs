using Microsoft.AspNetCore.Components.Forms;

namespace BlazingTrails.Client.Validation;

public class BootstrapCssClassProvider : FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext Context, in FieldIdentifier Id)
    {
        if (Context.GetValidationMessages(Id).Any())
            return "is-invalid";

        return Context.IsModified(Id) ? "is-valid" : "";
    }
}
