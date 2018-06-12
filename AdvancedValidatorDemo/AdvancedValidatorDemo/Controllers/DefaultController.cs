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
        public ActionResult Index(Student student)
        {
			var validator = new StudentValidator();
			var result = validator.Validate(student);
			if (!result.IsValid)
			{
				foreach (var error in result.Errors)
					ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
			}

			return View(student);
        }
    }
}