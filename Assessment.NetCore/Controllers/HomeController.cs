using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assessment.NetCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assessment.NetCore.Models;

namespace Assessment.NetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var amigos = _context.Amigos.ToList();
            var amigosOrdemAniv = amigos.OrderBy(amigo => amigo.dataDeNascimento).ToList();
            return View(amigosOrdemAniv);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}