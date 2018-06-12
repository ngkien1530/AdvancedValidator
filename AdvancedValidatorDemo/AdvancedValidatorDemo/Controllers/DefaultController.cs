using System.Web.Mvc;
using AdvancedValidator.Attributes;
using AdvancedValidatorDemo.Models;

namespace AdvancedValidatorDemo.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Student objStudent)
        {
			var validator = new StudentValidator();
			var result = validator.Validate(objStudent);
			if (result.IsValid)
			{
			}
			else
			{
				foreach (var failer in result.Errors)
					ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
			}

			return View(objStudent);
        }
    }
}