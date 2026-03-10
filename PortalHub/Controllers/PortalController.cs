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
            //var testData = new List<PortalhubModel> {
            //  new PortalhubModel { AppName = "Test App", AppUrl = "http://google.com", IconClass="bi-globe" } 
            //};
    
            //return View(testData);
            var portalApps = _dal.GetPortalhubModels();
            return View(portalApps);
        }
    }


}
