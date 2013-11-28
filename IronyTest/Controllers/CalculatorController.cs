using ParserGeneratorTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParserGeneratorTest.Controllers
{
    public class CalculatorController : Controller
    {
        //
        // GET: /Calculator/
        public ActionResult Index()
        {
            var parsers = new AvailableParserRepository().GetAllParsers();
            ViewData["parsers"] = from parser in parsers
                                  select new SelectListItem {
                                      Text = parser.Name,
                                      Value = parser.Id.ToString()
                                  };
            return View();
        }

        [HttpPost]
        public ActionResult ParseAndEvaluate(string expression, string parser)
        {
            var calculator = new ExpressionEvaluator(expression, new Guid(parser));
            try {
                var opResult = calculator.Evaluate();
                string result;
                if (opResult == null) {
                    result = "(la variable 'result' no fue asignada)";
                } else {
                    result = opResult.ToString();
                }
                return Json(new { Success = true, Result = result });
            } catch (Exception excep) {
                return Json(new { Success = false, Result = excep.Message });
            }
        }
	}
}