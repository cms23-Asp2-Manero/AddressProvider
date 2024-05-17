using AddressProvider.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AddressProvider.Functions
{
    public class GetAll(ILogger<GetAll> logger, IAddressRepository addressRepository)
    {
        private readonly ILogger<GetAll> _logger = logger;
        private readonly IAddressRepository _addressRepository = addressRepository;

        [Function("GetAll")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "AddressProvider")] HttpRequest req)
        {
            _logger.LogInformation("Processing GET request to get all Address objects");
            try
            {
                var addresses = await _addressRepository.GetAllAsync();
                return new OkObjectResult(addresses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception was raised");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
