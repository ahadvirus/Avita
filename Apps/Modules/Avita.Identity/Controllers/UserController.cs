using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Avita.Models.Entities.Identity;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using NHibernate.Linq;

namespace Avita.Identity.Controllers;

[ApiController]
[Route(template: "[controller]")]
public class UserController : ControllerBase
{
    protected ISessionFactory SessionFactory { get; }

    public UserController(ISessionFactory sessionFactory)
    {
        SessionFactory = sessionFactory;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get(CancellationToken cancellationToken)
    {
        IEnumerable<User> result;

        using (ISession session = SessionFactory.OpenSession())
        {
            result = await session.Query<User>().ToListAsync(cancellationToken: cancellationToken);
        }
        
        return Ok(value: result);
    }
}