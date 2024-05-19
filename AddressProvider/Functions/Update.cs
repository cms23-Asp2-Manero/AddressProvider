using AddressProvider.Data.Entities;
using AddressProvider.Helpers;
using AddressProvider.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AddressProvider.Functions
{
    public class Update(ILogger<Update> logger, IAddressRepository addressRepository)
    {
        private readonly ILogger<Update> _logger = logger;
        private readonly IAddressRepository _addressRepository = addressRepository;

        [Function("Update")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "put", Route = "AddressProvider")] HttpRequest req)
        {
            _logger.LogInformation("Processing PUT request to Update an Address object");
            try
            {
                string message = await new StreamReader(req.Body).ReadToEndAsync();
                AddressEntity? address = JsonConvert.DeserializeObject<AddressEntity>(message);
                if (ValidModel.IsValid(address))
                {
                    if (await _addressRepository.ExistsAsync(x => x.Id == address!.Id && x.UserId == address.UserId))
                    {
                        var modifiedEntity = await _addressRepository.UpdateAsync(address!);
                        return new OkObjectResult(modifiedEntity);
                    }
                    return new NotFoundObjectResult(new { error = "No object found" });
                }
                else
                {
                    return new BadRequestObjectResult(new { error = "Put request failed due to invalid data" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception was raised");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
