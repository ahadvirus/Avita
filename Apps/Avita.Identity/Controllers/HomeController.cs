using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Avita.Identity.Models;
using Avita.Identity.Models.Entities;
using Microsoft.Extensions.Logging;
using NHibernate;
using NHibernate.Linq;

namespace Avita.Identity.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISessionFactory _sessionFactory;

    public HomeController(ILogger<HomeController> logger, ISessionFactory sessionFactory)
    {
        _sessionFactory = sessionFactory;
        _logger = logger;
    }

    public async Task<IActionResult> Index(CancellationToken cancellation)
    {
        IEnumerable<User> model;
        using (ISession session = _sessionFactory.OpenSession())
        {
            /*
            IQuery query = session.CreateQuery(queryString: string.Empty);
            query = query.MappedAs(type: NHibernateUtil.Class).
            */

            string value = "admin";
            IQueryable<User> query = session.Query<User>();
            query = query.Where(predicate: user => string.Compare(user.Username, value, StringComparison.OrdinalIgnoreCase) == 0);
            model = await query.ToListAsync(cancellationToken: cancellation);
        }

        return View(model: model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
