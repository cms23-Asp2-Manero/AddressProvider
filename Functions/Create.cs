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
    public class Create(ILogger<Create> logger, IAddressRepository addressRepository)
    {
        private readonly ILogger<Create> _logger = logger;
        private readonly IAddressRepository _addressRepository = addressRepository;

        [Function("Create")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "AddressProvider")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            try
            {
                string message = await new StreamReader(req.Body).ReadToEndAsync();
                AddressEntity? address = JsonConvert.DeserializeObject<AddressEntity>(message);     
                if (ValidModel.IsValid(address))
                {
                    AddressEntity entity = await _addressRepository.CreateAsync(address!);
                    return new OkObjectResult(entity);
                }
                else
                {
                    return new BadRequestObjectResult(new { error = "Post request failed due to invalid data" });
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
