using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RccgChildrenManagement.Models;

namespace RccgChildrenManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        IRccgRepository RccgRepository;

        public RoleController(IRccgRepository Rrccg)
        {
            RccgRepository = Rrccg;
        }
        public ActionResult Index()
        {


            var List = RccgRepository.Roles;

            return View(List);
        }


        // GET: RoleController/Create
        [ActionName("Create")]
        [HttpGet]
        public ActionResult CreateDetails()
        {
            return View();
        }

        // POST: RoleController/Create
        [ActionName("Create")]       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDetails(Role app)
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
                    Action = "Create",
                    NewValue = "Role",
                    //  OldValue = "",
                    IpAddress = ip,
                    CreatedBy = HttpContext.User.Identity.Name,
                    ObjectName = "Create",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                };
                RccgRepository.AddAuditTrail(auditTrail);
                RccgRepository.Save();

                app.Created = DateTime.Now;
                app.Updated = DateTime.Now;

                RccgRepository.AddRole(app);
                RccgRepository.Save();
                TempData["ModelState"] = "Role Created Successfully ";
                // return View();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: RoleController/Edit/5
        public ActionResult Edit(int Id)
        {
            var apps = RccgRepository.Roles;
            Role dba = RccgRepository.Roles.FirstOrDefault(d => d.RoleId == Id);
            return View(dba);
        }

        // POST:RoletController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Role apps)
        {
            try
            {
                var ip = HttpContext.Connection.RemoteIpAddress.ToString();

                AuditTrail auditTrail = new AuditTrail
                {
                    Action = "Edit",
                    NewValue = "Role",
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

                var app = RccgRepository.Roles;
                Role dba = RccgRepository.Roles.FirstOrDefault(d => d.RoleId == apps.RoleId);
                dba.RoleName = apps.RoleName;

                dba.Created = apps.Created;
                dba.Updated = apps.Updated;
                RccgRepository.Save();
                //return View(app);
                TempData["ModelState"] = "Role Updated Successfully ";
                return RedirectToAction("Index");
            }

            catch (Exception e)
            {
                return View();
            }
        }

        // GET: RoleController/Delete/5
        //[Authorize]
        public ActionResult Delete(int Id)
        {
            var apps = RccgRepository.Roles;
            Role dba = RccgRepository.Roles.Single(d => d.RoleId == Id);
            return View(dba);
        }

        // POST: RoleController/Delete/5
        // [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Role apps)
        {
            try
            {
                var ip = HttpContext.Connection.RemoteIpAddress.ToString();

                AuditTrail auditTrail = new AuditTrail
                {
                    Action = "Delete",
                    NewValue = "Role",
                    //  OldValue = "",
                    IpAddress = ip,
                    CreatedBy = HttpContext.User.Identity.Name,
                    ObjectName = "Delete",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                };
                RccgRepository.AddAuditTrail(auditTrail);
                RccgRepository.Save();


                var app = RccgRepository.Roles;
                Role dba = RccgRepository.Roles.FirstOrDefault(d => d.RoleId == apps.RoleId);
                RccgRepository.RemoveRole(dba);
                RccgRepository.Save();
                //  return View(apps);
                TempData["ModelState"] = "Role Deleted Successfully ";
                return RedirectToAction("Index");


            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
