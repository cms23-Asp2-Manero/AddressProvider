using AddressProvider.Data.Contexts;
using AddressProvider.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AddressProvider.Functions
{
    public class AddressProviderId(ILogger<AddressProviderId> logger, Context context)
    {
        private readonly ILogger<AddressProviderId> _logger = logger;
        private readonly Context _context = context;

        [Function("AddressProviderId")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "AddressProvider/{id}")] HttpRequest req, int id)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            if (req.Method == HttpMethods.Get)
            {
                try
                {
                    AddressEntity? account = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
                    if (account != null) 
                    {
                        return new OkObjectResult(account);
                    }
                    return new NotFoundResult();
                }
                catch (Exception ex) 
                {
                    return new BadRequestObjectResult(ex);
                }
            }

            if (req.Method == HttpMethods.Delete)
            {
                try
                {
                    AddressEntity? account = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
                    if (account != null)
                    {
                        _context.Addresses.Remove(account);
                        await _context.SaveChangesAsync();

                    }
                    return new NoContentResult();
                }
                catch (Exception ex)
                {
                    return new BadRequestObjectResult(ex);
                }
            }

            return new BadRequestResult();
        }
    }
}
