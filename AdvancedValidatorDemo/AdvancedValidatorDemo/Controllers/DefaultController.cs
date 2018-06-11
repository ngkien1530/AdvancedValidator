using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdvancedValidator.Results;
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
			StudentValidator validator = new StudentValidator();
			ValidationResult result = validator.Validate(objStudent);
			if (result.IsValid)
			{

		    }
			else
			{
				foreach (ValidationFailure failer in result.Errors)
				{
					ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
				}

		    }
			return View(objStudent);
	    }
	}
}