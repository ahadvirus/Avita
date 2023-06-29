using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Avita.Infrastructure.Extensions;
using Avita.Models.Entities.Identity;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using NHibernate.Linq;

namespace Avita.Identity.Controllers;

//[ApiController]
[Route(template: nameof(Infrastructure.Configurations.Route.Api) + "/" + "[controller]")]
[Route(template:"[controller]")]
public class UserController : Controller
{
    private ISessionFactory SessionFactory { get; }

    public UserController(ISessionFactory sessionFactory)
    {
        SessionFactory = sessionFactory;
    }

    [HttpGet]
    [HttpGet(template:"[action]")]
    public async Task<ActionResult<IEnumerable<User>>> Index(CancellationToken cancellationToken)
    {
        IEnumerable<User> result;

        using (ISession session = SessionFactory.OpenSession())
        {
            result = await session.Query<User>().ToListAsync(cancellationToken: cancellationToken);
        }
        
        return Request.IsApi() ? Ok(value: result) : View(model: result);
    }
}