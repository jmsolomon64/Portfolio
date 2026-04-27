using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Models;

namespace PortfolioAPI;

public class BaseController : ControllerBase
{
    protected Response<T> HandleRequest<T>(Func<T> action, string message = "")
        {
            try
            {
                return new Response<T>()
                {
                    Message = message,
                    Success = true,
                    Data = action()
                };
            }
            catch(Exception ex)
            {
                return new Response<T>()
                {
                    Message = ex.Message,
                    Success = false
                };
            }
        }
}
