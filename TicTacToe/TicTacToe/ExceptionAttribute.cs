using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.DataAccess;
using TicTacToe.Model;

namespace TicTacToe
{
    public class ExceptionAttribute : ExceptionFilterAttribute
    {
        Log logObject = new Log();
        LogData addingobject = new LogData();

        public override void OnException(ExceptionContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is Exception)
            {
                logObject.Request = actionExecutedContext.RouteData.Values["action"].ToString() + " " + actionExecutedContext.RouteData.Values["action"].ToString();
                logObject.Exception = actionExecutedContext.Exception.ToString();
                var index = logObject.Exception.IndexOf("\r");
                logObject.Exception = logObject.Exception.Substring(0, index);
                logObject.Response = "Failure";
                logObject.TimeStamp = DateTime.Now;
                addingobject.Add(logObject);
            }
        }
    }
}