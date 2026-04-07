using DemoElasticKibana.ElasticSearch;
using DemoElasticKibana.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoElasticKibana.Controllers
{
    public class HomeController : Controller
    {
        public class Hehe
        {
            public Hehe()
            {
                hihi = "hello world";
            }
            public string hihi { get; set; }
        }
        private readonly ILogger<HomeController> _logger;
        private readonly IElasticSeachService<Hehe> _elasticSeachService;

        public HomeController(ILogger<HomeController> logger, IElasticSeachService<Hehe> elasticSeachService)
        {
            _logger = logger;
            _elasticSeachService = elasticSeachService;
        }

        public IActionResult Index()
        {
            //var document = new Hehe();
            //_elasticSeachService.IndexDocumentAsync("demo_hehe", document);
            return View();
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
}
