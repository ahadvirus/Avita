using Microsoft.AspNetCore.Mvc;

namespace Avita.Infrastructure.Extensions;

public static class RemoveControllerExtension
{
    public static string RemoveController(this string name)
    {
        return name.Replace(oldValue: nameof(Controller), newValue: string.Empty);
    }
}