using Microsoft.AspNetCore.Http;

namespace Avita.Infrastructure.Extensions;

public static class IsApiRequestExtension
{
    public static bool IsApi(this HttpRequest request)
    {
        return request.Path.HasValue &&
               request.Path.Value.ToLower().StartsWith(
                   value: string.Format(
                       format: "/{0}",
                       args: new object[] { nameof(Configurations.Route.Api) }).ToLower()
               );
    }
}