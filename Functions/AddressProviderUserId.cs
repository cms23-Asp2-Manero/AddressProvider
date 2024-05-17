using AddressProvider.Data.Contexts;
using AddressProvider.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AddressProvider.Functions
{

    //public class AddressProviderUserId(ILogger<AddressProviderUserId> logger, Context context)
    //{
    //    private readonly ILogger<AddressProviderUserId> _logger = logger;
    //    private readonly Context _context = context;

    //    [Function("AddressProviderUserId")]
    //    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "AddressProvider/{userid}")] HttpRequest req, string userId)
    //    {
    //        _logger.LogInformation("C# HTTP trigger function processed a request.");

    //        if (req.Method == HttpMethods.Get)
    //        {
    //            try
    //            {
    //                IEnumerable<AddressEntity>? addresses = await _context.Addresses.Where(x => x.UserId == userId).ToListAsync();
    //                if (addresses != null)
    //                {
    //                    return new OkObjectResult(addresses);
    //                }
    //                else
    //                {
    //                    return new NotFoundObjectResult("No Object found with id: " + userId);
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                return new BadRequestObjectResult(ex);
    //            }
    //        }
    //        return new BadRequestResult();
    //    }
    //}
}
