using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RccgChildrenManagement.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace RccgChildrenManagement.Controllers
{
   // [Authorize]
    public class ResponsiblePartyController : Controller
    {
        IRccgRepository RccgRepository;

        public ResponsiblePartyController(IRccgRepository Rrccg)
        {
            RccgRepository = Rrccg;
        }
        public ActionResult Index()
        {

            var UserEmail = HttpContext.User.Identity.Name;
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();

            AuditTrail auditTrail = new AuditTrail
            {
                Action = "Index",
                NewValue = "User",
                //  OldValue = "",
                IpAddress = ip,
                CreatedBy = HttpContext.User.Identity.Name,
                ObjectName = "Index",
                Created = DateTime.Now,
                Updated = DateTime.Now,
            };
            RccgRepository.AddAuditTrail(auditTrail);
            RccgRepository.Save();


            var List = RccgRepository.ResponsiblePartys;

            return View(List);
        }


        public ActionResult ResponsibleParty()
        {

            var UserEmail = HttpContext.User.Identity.Name;
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();

            AuditTrail auditTrail = new AuditTrail
            {
                Action = "Index",
                NewValue = "User",
                //  OldValue = "",
                IpAddress = ip,
                CreatedBy = HttpContext.User.Identity.Name,
                ObjectName = "Index",
                Created = DateTime.Now,
                Updated = DateTime.Now,
            };
            RccgRepository.AddAuditTrail(auditTrail);
            RccgRepository.Save();
            var List = RccgRepository.ResponsiblePartys.Where(x => x.EmailAddress == UserEmail).ToList();
            ViewBag.List = List;

           // var List = RccgRepository.ResponsiblePartys;

            return View(List);
        }


        // GET: ResponsiblePartyController/Create
        public ActionResult Create()
        {
            ViewBag.User = User();

            return View();
        }

        // POST: ResponsiblePartyController/Create
        [HttpPost]

        public ActionResult Create(ResponsibleParty model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var ip = HttpContext.Connection.RemoteIpAddress.ToString();

                AuditTrail auditTrail = new AuditTrail
                {
                    Action = "Create",
                    NewValue = "Children",
                    //  OldValue = "",
                    IpAddress = ip,
                    CreatedBy = HttpContext.User.Identity.Name,
                    ObjectName = "Create",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                };
                RccgRepository.AddAuditTrail(auditTrail);
                RccgRepository.Save();


                model.Created = DateTime.Now;
                model.Updated = DateTime.Now;

                RccgRepository.AddResponsibleParty(model);
                RccgRepository.Save();
                TempData["ModelState"] = "ResponsibleParty Created Successfully ";
                // return View();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                return View();
            }
        }
        public List<SelectListItem> User()
        {
            var user = new List<SelectListItem>();
            var items = RccgRepository.Users.ToList();
            foreach (var t in items)
            {
                user.Add(new SelectListItem { Text = t.EmailAddress, Value = t.UserId.ToString() });
            }
            return user;
        }

        // POST: UserController/DataTable
        // [Authorize]
        public IActionResult ResponsibleDataTable()
        {
            var UserEmail = HttpContext.User.Identity.Name;

            var ip = HttpContext.Connection.RemoteIpAddress.ToString();


            try
            {
                AuditTrail auditTrail = new AuditTrail
                {
                    Action = "Index",
                    NewValue = "Children",
                    //  OldValue = "",
                    IpAddress = ip,
                    CreatedBy = HttpContext.User.Identity.Name,
                    ObjectName = "Index",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                };
                RccgRepository.AddAuditTrail(auditTrail);
                RccgRepository.Save();
                var List = RccgRepository.ResponsiblePartys.Where(x => x.EmailAddress == UserEmail).ToList();
                ViewBag.List = List;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }

            return View();
        }

        // GET: ResponsiblePartyController/Create
        public ActionResult Edit(int Id)
        {
            var apps = RccgRepository.ResponsiblePartys;
            ResponsibleParty dba = RccgRepository.ResponsiblePartys.FirstOrDefault(d => d.ResponsiblePartyId == Id);
            return View(dba);
        }


        // POST: ResponsiblePartyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ResponsibleParty app)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(app);
                }
                var ip = HttpContext.Connection.RemoteIpAddress.ToString();

                AuditTrail auditTrail = new AuditTrail
                {
                    Action = "Edit",
                    NewValue = "User",
                    //  OldValue = "",
                    IpAddress = ip,
                    CreatedBy = HttpContext.User.Identity.Name,
                    ObjectName = "Edit",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                };
                RccgRepository.AddAuditTrail(auditTrail);
                RccgRepository.Save();

                // TODO:  Edit logic here

                var apps = RccgRepository.ResponsiblePartys;
                ResponsibleParty dba = RccgRepository.ResponsiblePartys.FirstOrDefault(d => d.ResponsiblePartyId == app.ResponsiblePartyId);
                dba.relfn = app.relfn;
                dba.relln = app.relln;
                dba.RegistrationId = app.RegistrationId;
                dba.PersonType = app.PersonType;
                dba.relemail = app.relemail;
                dba.relphonenumber = app.relphonenumber;
                dba.Created = app.Created;
                dba.Updated = app.Updated;
                RccgRepository.Save();
                //  return View(app);
                TempData["ModelState"] = "ResponsibleParty Updated Successfully ";
                return RedirectToAction("Index");
            }

            catch (Exception e)
            {
                return View();
            }
        }

    }
}
