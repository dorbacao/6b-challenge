using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Filter to compose aspnet core pipeline to catch all unhandled exception can be thorw in the api
/// </summary>
public class UnhandledExceptionFilter : IExceptionFilter
{
    string GetFriendlyError(Exception exception)
    {
        var updateException = exception as DbUpdateException;
        if (updateException != null)
        {
            var sqlException = updateException.InnerException as SqlException;

            if (sqlException != null)
                return "Error performing an operation on the database";

        }

        return exception.Message;
    }
    public void OnException(ExceptionContext context)
    {
        var logger = context.HttpContext.RequestServices.GetService(typeof(ILogger<UnhandledExceptionFilter>)) as ILogger<UnhandledExceptionFilter>;

        logger.LogError(context.Exception, "UnhandledExceptionFilter: An unhandled exception occurred in the application");

        var errorMessage = GetFriendlyError(context.Exception);
        var result = new ObjectResult(errorMessage);
        result.StatusCode = 500;
        context.Result = result;
    }
}


