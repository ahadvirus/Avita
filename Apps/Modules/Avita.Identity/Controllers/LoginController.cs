using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avita.Identity.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using NHibernate.Linq;

namespace Avita.Identity.Controllers;

public class LoginController : Controller
{
    [HttpGet(template: nameof(Models.Configurations.Route.Auth) + "/[controller]/[action]")]
    public Task<IActionResult> Index([FromQuery] string returnUrl)
    {
        return Task.FromResult<IActionResult>(View(model: new LoginVm() { ReturnUrl = returnUrl }));
    }

    [ValidateAntiForgeryToken]
    [HttpPost(template: nameof(Models.Configurations.Route.Auth) + "/[controller]/[action]")]
    public async Task<IActionResult> Index(
        [Bind(include: new string[]
        {
            nameof(LoginVm.Username),
            nameof(LoginVm.Password),
            nameof(LoginVm.RememberMe),
            nameof(LoginVm.ReturnUrl)
        })]
        LoginVm entry,
        [FromServices] ISessionFactory sessionFactory,
        CancellationToken cancellationToken)
    {
        
        IActionResult result = View(model: entry);
        
        if (ModelState.IsValid)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                IQueryable<Avita.Models.Entities.Identity.User> users =
                    session.Query<Avita.Models.Entities.Identity.User>();

                if (await users
                        .Where(predicate: user => user.Username == entry.Username && user.Password == entry.Password)
                        .Select(selector: user => user.Id)
                        .AnyAsync(cancellationToken: cancellationToken))
                {
                    //
                }
            }
        }

        return result;
    }
}