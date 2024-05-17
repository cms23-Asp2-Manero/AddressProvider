using AddressProvider.Data.Entities;
using AddressProvider.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AddressProvider.Functions
{
    public class GetAllFromUser(ILogger<GetAllFromUser> logger, IAddressRepository addressRepository)
    {
        private readonly ILogger<GetAllFromUser> _logger = logger;
        private readonly IAddressRepository _addressRepository = addressRepository;

        [Function("GetAllFromUser")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route="AddressProvider/{userId}")] HttpRequest req, string userId)
        {
            _logger.LogInformation("Proccessing GET request to get all Address objects with userId");
            try
            {
                IEnumerable<AddressEntity>? addresses = await _addressRepository.GetAllFromUserAsync(userId);
                if (addresses != null)
                {
                    return new OkObjectResult(addresses);
                }
                else
                {
                    return new NotFoundObjectResult(new { error = "No object found" });
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
