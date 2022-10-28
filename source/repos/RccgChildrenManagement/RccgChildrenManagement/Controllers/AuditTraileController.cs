using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RccgChildrenManagement.Models;

namespace RccgChildrenManagement.Controllers
{
   // [Authorize(Roles = "Admin")]
    public class AuditTrailController : Controller
    {
        IRccgRepository RccgRepository;

        public AuditTrailController(IRccgRepository Rrccg)
        {
            RccgRepository = Rrccg;
        }
        public ActionResult Index()
        {

            var List =RccgRepository.AuditTrails;

            return View(List);
        }
        // GET: AuditTrailController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuditTrailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuditTrail au)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(au);
                }
                var ip = HttpContext.Connection.RemoteIpAddress.ToString();

                AuditTrail auditTrail = new AuditTrail
                {
                    Action = "Admin Setup",
                    NewValue = "User",                   
                    IpAddress = ip,
                    CreatedBy = HttpContext.User.Identity.Name,
                    ObjectName = "Admin Setup",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                };
                RccgRepository.AddAuditTrail(auditTrail);

                RccgRepository.Save();

               // return View();
                 return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
