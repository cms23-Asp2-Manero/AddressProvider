using AddressProvider.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AddressProvider.Functions
{
    public class Delete(ILogger<Delete> logger, IAddressRepository addressRepository)
    {
        private readonly ILogger<Delete> _logger = logger;
        private readonly IAddressRepository _addressRepository = addressRepository;

        [Function("Delete")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "AddressProvider/{userId}/{addressId}")] HttpRequest req, string userId, int addressId)
        {
            _logger.LogInformation("Processing DELETE request to delete an Account object based on userId and addressId");
            try
            {
                if (await _addressRepository.ExistsAsync(x => x.UserId == userId && x.Id == addressId))
                {
                    await _addressRepository.DeleteAsync(addressId);
                }
                return new NoContentResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception was raised");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
