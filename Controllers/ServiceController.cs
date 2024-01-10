using Microsoft.AspNetCore.Mvc;

namespace Queue_Management_System_Assignment.Controllers
{
    public class ServiceController : Controller
    {
        private readonly DbOperationsRepository _dbOperationsRepository;

        public ServiceController(DbOperationsRepository dbOperationsRepository)
        {
            _dbOperationsRepository = dbOperationsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ServiceSelection()
        {
            var serviceTypes = await _dbOperationsRepository.GetAvailableServicesAsync();
            return View(serviceTypes);
        }

        [HttpPost]
        public async Task<IActionResult> SelectService(int selectedServiceId)
        {
            // Perform actions with the selected service ID
            // For example, store it in the database for the logged-in user

            // Redirect to a success page or perform further actions
            return RedirectToAction("Success", "Service");
        }
    }
}
