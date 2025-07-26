using Entities.LogModel;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ActionFilters
{
    public class LogFilterAttribute:ActionFilterAttribute
    {
        private readonly ILoggerService _Service;

        public LogFilterAttribute(ILoggerService service)
        {
            _Service = service;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _Service.LogInfo(Log("OnActionExecuting", context.RouteData));
        }

        private string Log(string ModelName, RouteData routeData)
        {
            var LogDetails = new LogDetails()
            {
                ModelName = ModelName,
                Controller = routeData.Values["controller"],
                Action=routeData.Values["action"]
            };
            if (routeData.Values.Count>=3)
                LogDetails.Id = routeData.Values["Id"];
               
            return LogDetails.ToString();
        }
    }
}
