using Microsoft.AspNetCore.Mvc;
using PortalHub.DAL;
using PortalHub.Models;

namespace PortalHub.Controllers
{
    public class PortalController : Controller
    {
        private readonly Portal_DAL _dal;

        public PortalController(Portal_DAL dal)
        {
            _dal = dal;

        }

        public IActionResult Portal()
        {
            // Fetch data from DAL
            var portalApps = _dal.GetPortalhubModels();

            // Ensure portalApps is never null before sending to the View
            if (portalApps == null)
            {
                portalApps = new List<PortalhubModel>();
            }

            return View(portalApps);
        }
    }


}
