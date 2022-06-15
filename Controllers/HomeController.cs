using BudgetCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace BudgetCalculator.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		public List<BudgetModel> Budgets { get; set; } = new List<BudgetModel>();
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View(model: Budgets);
		}

		[HttpPost]
		public IActionResult Privacy(BudgetModel model)
		{
			Budgets.Add(model);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Privacy()
		{
			return View(new BudgetModel());
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
