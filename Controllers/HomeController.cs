using BudgetCalculator.Models;
using dboBudgets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace BudgetCalculator.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private BudgetCalculatordbContext _context;
		public HomeController(ILogger<HomeController> logger, BudgetCalculatordbContext context)
		{
			_context = context;
			_logger = logger;
		}
		[HttpGet]
		public IActionResult Index()
		{
			var budgets = _context.Budgets.ToList();
			return View(model: budgets);
		}

		[HttpPost]
		public IActionResult Privacy(BudgetModel model)
		{
			if (ModelState.IsValid == false) return View(model);
			_context.Budgets.Add(model);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		//[HttpPost]
		public IActionResult DeleteResult(int id)
		{
			var model = _context.Budgets.Find(id);
			_context.Budgets.Remove(model);
			_context.SaveChanges();
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
