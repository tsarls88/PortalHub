using Microsoft.AspNetCore.Mvc;
using PortalHub.DAL;

namespace PortalHub.Controllers
{
    public class PortalController: Controller
    {
        private readonly Portal_DAL _dal;
        
        public PortalController(Portal_DAL dal)
        {
            _dal = dal;
           
        }

        public IActionResult Index()
        {
            var portalApps = _dal.GetPortalhubModels();
            return View(portalApps);  
        }
    }

    
}
