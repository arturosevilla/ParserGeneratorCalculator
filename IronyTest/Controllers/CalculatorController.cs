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
            return View();
        }

        [HttpPost]
        public ActionResult ParseAndEvaluate(string expression)
        {
            var calculator = new ExpressionEvaluator(expression);
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