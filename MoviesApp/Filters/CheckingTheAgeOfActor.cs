using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MoviesApp.Filters;

public class CheckingTheAgeOfActor : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var formDate = DateTime.Parse(context.HttpContext.Request.Form["BirthDate"]);
        var age = DateTime.Now.Year - formDate.Year;
        if (age < 7 || age > 99)
        {
            context.Result = new BadRequestResult();
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        
    }
}