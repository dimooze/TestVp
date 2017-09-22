using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestVp.Attributes;
using TestVp.Manager;

namespace TestVp.Controllers
{
    public class IpController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return CommonManager.GetIP(Request);
        }
    }
}