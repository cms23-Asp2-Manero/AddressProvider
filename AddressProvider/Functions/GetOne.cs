using AddressProvider.Data.Entities;
using AddressProvider.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AddressProvider.Functions
{
    public class GetOne(ILogger<GetOne> logger, IAddressRepository addressRepository)
    {
        private readonly ILogger<GetOne> _logger = logger;
        private readonly IAddressRepository _addressRepository = addressRepository;

        [Function("GetOne")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "AddressProvider/{userId}/{addressId}")] HttpRequest req, string userId, int addressId)
        {
            _logger.LogInformation("Proccessing GET request to get one Address object based on id");
            try
            {
                if (await _addressRepository.ExistsAsync(x => x.UserId == userId && x.Id == addressId))
                {
                    AddressEntity account = await _addressRepository.GetOneAsync(addressId);
                    if (account != null)
                    {
                        return new OkObjectResult(account);
                    }
                }
                return new NotFoundObjectResult(new { error = "No object found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception was raised");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
