using AddressProvider.Data.Contexts;
using AddressProvider.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AddressProvider.Functions
{
    //public class AddressProvider(ILogger<AddressProvider> logger, Context context)
    //{
    //    private readonly ILogger<AddressProvider> _logger = logger;
    //    private readonly Context _context = context;

    //    [Function("AddressProvider")]
    //    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", "put")] HttpRequest req)
    //    {
    //        _logger.LogInformation("C# HTTP trigger function processed a request.");

    //        if (req.Method == HttpMethods.Post)
    //        {
    //            try
    //            {
    //                string message = await new StreamReader(req.Body).ReadToEndAsync();
    //                AddressEntity? address = JsonConvert.DeserializeObject<AddressEntity>(message);
    //                if (address != null)
    //                {
    //                    AddressEntity entity = _context.Addresses.Add(address).Entity;
    //                    await _context.SaveChangesAsync();
    //                    return new OkObjectResult(entity);
    //                }
    //                else
    //                {
    //                    return new BadRequestResult();
    //                }

    //            }
    //            catch (Exception ex)
    //            {
    //                return new BadRequestObjectResult(ex);
    //            }

    //        }

    //        if (req.Method == HttpMethods.Put)
    //        {
    //            try
    //            {
    //                string message = await new StreamReader(req.Body).ReadToEndAsync();
    //                AddressEntity? address = JsonConvert.DeserializeObject<AddressEntity>(message);
    //                if (address != null)
    //                {
    //                    if (await _context.Addresses.AnyAsync(x => x.Id == address.Id))
    //                    {
    //                        _context.Addresses.Update(address);
    //                        await _context.SaveChangesAsync();  
    //                        return new OkObjectResult(address);
    //                    }
    //                    return new NotFoundObjectResult("No Object found with id: " + address.UserId);
    //                }
    //                else
    //                {
    //                    return new BadRequestResult();
    //                }
    //            }
    //            catch
    //            {
    //                return new BadRequestResult();
    //            }

    //        }

    //        IEnumerable<AddressEntity> accounts = await _context.Addresses.ToListAsync();
    //        return new OkObjectResult(accounts);
    //    }   
    //}
}
