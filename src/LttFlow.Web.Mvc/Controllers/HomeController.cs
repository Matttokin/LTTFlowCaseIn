using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using LttFlow.Controllers;

namespace LttFlow.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : LttFlowControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
