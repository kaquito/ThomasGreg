using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ThomasGreg.Entidade;
using ThomasGreg.Site.Models;
using ThomasGreg.Site.Services;

namespace ThomasGreg.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string _RouteSite = string.Empty;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _RouteSite = "https://localHost:44377/Api/Cliente/";

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult IndexCliente()
        {
            var ret = new WebApiService<Cliente>().GetTAsync($"{_RouteSite}");
            return View(ret.Result);
        }

       
        public IActionResult Add()
        {
            return View(new Cliente());
        }

        [HttpPost]
        public IActionResult Add(Cliente cliente)
        {
            var ret = new WebApiService<Cliente>().PutTAsync($"{_RouteSite}Add/", cliente);
            return View(ret.Result);
        }

        [HttpPut]
        public IActionResult Update(Cliente cliente)
        {
            var ret = new WebApiService<Cliente>().PutTAsync($"{_RouteSite}Update/", cliente);
            return View(ret.Result);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
