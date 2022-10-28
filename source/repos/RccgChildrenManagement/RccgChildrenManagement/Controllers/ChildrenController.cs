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
using System.IO;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;

namespace RccgChildrenManagement.Controllers
{
  //  [Authorize(Roles = "Parent")]
    public class ChildrenController : Controller
    {
        IRccgRepository RccgRepository;

        public ChildrenController(IRccgRepository Rrccg)
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
           // var List = RccgRepository.Childrens.Where(x => x.EmailAddress ==UserEmail).ToList();
           // ViewBag.List = List;

           var List = RccgRepository.Childrens;

            return View(List);
        }

        public ActionResult Display()
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
            var List = RccgRepository.Childrens.Where(x => x.EmailAddress == UserEmail).ToList();
           // ViewBag.List = List;

            

            return View(List);
        }

       // POST: UserController/GenerateQRCode
        public IActionResult GenerateQRCode()
        {

            return View();
        }
        public string GenerateQRCode(string QRString)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRString, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap bitMap = qrCode.GetGraphic(20);
                bitMap.Save(ms, ImageFormat.Png);
                return "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
            }
        }


      

        // POST: UserController/DataTable
       // [Authorize]
        public IActionResult ParentDataTable()
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
                var List = RccgRepository.Childrens.Where(x => x.EmailAddress == UserEmail).ToList();
                ViewBag.List = List;
                TempData["status"] = " Children Dropped Off Succrssfully";
                return View();
            }
            catch (Exception ex)
            {
                return View();
                Console.WriteLine(ex.ToString());
            }
          
        }


        //EmailOtp verification and save otp to database.       
        // POST: UserController/SendMail
        public ActionResult SendMail(string EmailAddress, string subject, string message, string otp)
        {

            var users = RccgRepository.Users.ToList();
            User user = RccgRepository.Users.FirstOrDefault(d => d.EmailAddress == EmailAddress);

            if (user != null)
            {
                string domainName = HttpContext.Request.Host.Host;
                var id = user.UserId;

                // string url = Request.Scheme + "://" + Request.Host + '/' +
                // "User" + "/" + "Validate?" + "username=" + user.EmailAddress +
                //  "&id=" + id;
                MailMessage mail = new MailMessage();
                mail.To.Add(user.EmailAddress);
                mail.From = new MailAddress("portal@posshop-ng.com");
                mail.Subject = "QR CODE to DropOff Children";
                string Body = $"Dear {user.EmailAddress},to dropOff Children use this QRCode  number";
                string Body1 = string.Format("Dear {0} your password is {1} ", user.EmailAddress, user.Password);
                string Password = user.Password;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {

                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Host = "mail.posshop-ng.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("portal@posshop-ng.com", "7qfRq98#"); // Enter seders User name and password  
                    smtp.EnableSsl = false;
                    smtp.Send(mail);
                }

                TempData["ModelState"] = "Code sent to your EmailAddress Successfully ";

            }
            else
            {
                //ViewBag.msg = "Cannot recognise email";
                // ViewBag.msg = "alert("Cannotrecognise email");
                TempData["status"] = "Password not Recognized";
                // Save model-state to TempData
                // TempData["ModelState"] = "modelState";
            }

            return View();
        }



      

        // GET: ChildrenController/Create
        public ActionResult Create()
        {
            ViewBag.User = User();
           
            return View();
        }

        // POST: ChildrenController/Create
        [HttpPost]
        
        public ActionResult Create(Children model)
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

                Children children = new Children();
                children.EmailAddress = model.EmailAddress;
                children.ChildFirstName = model.ChildFirstName;
                children.ChildLastName = model.ChildFirstName;
                children.DOB = model.DOB;
                children.Class = model.Class;
                model.Created = DateTime.Now;
                model.Updated = DateTime.Now;

                RccgRepository.AddChildren(model);
                RccgRepository.Save();
                TempData["ModelState"] = "Children Created Successfully ";
                // return View();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                return View();
            }
        }

        


        // GET: ChildrenController/Create
        public ActionResult CreateChidren()
        {
            ViewBag.User = User();

            return View();
        }
        public IActionResult ChildrenData(string id)
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
                var List = RccgRepository.Childrens.Where(x => x.EmailAddress == UserEmail).ToList();
                ViewBag.List = List;
                var responsible = RccgRepository.ResponsiblePartys.Where(x => x.EmailAddress == UserEmail).ToList();
                ViewBag.responsible = responsible;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
            var children = RccgRepository.Childrens.Where(d => d.EmailAddress == id);
            return View(children);
        }

        public IActionResult ReponsibleParty(string id)
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
            var children = RccgRepository.Childrens.Where(d => d.EmailAddress == id);
            return View(children);
        }
        // POST: ChildrenController/Create
        [HttpPost]

        public ActionResult Children(Children model)
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

                RccgRepository.AddChildren(model);
                RccgRepository.Save();
                TempData["ModelState"] = "Children Created Successfully ";
                // return View();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                return View();
            }
        }
        // GET: ChildrenController/Edit/5
        public ActionResult Edit(int Id)
        {
            var apps = RccgRepository.Childrens;
            Children dba = RccgRepository.Childrens.FirstOrDefault(d => d.ChildrenId == Id);
            return View(dba);
        }

        // POST:ChildrenController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Children apps)
        {
            try
            {
                var ip = HttpContext.Connection.RemoteIpAddress.ToString();

                AuditTrail auditTrail = new AuditTrail
                {
                    Action = "Edit",
                    NewValue = "ClericalStaf",
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

                var app = RccgRepository.Childrens;
                Children dba = RccgRepository.Childrens.FirstOrDefault(d => d.ChildrenId == apps.ChildrenId);
                dba.ChildFirstName = apps.ChildFirstName;
                dba.ChildLastName = apps.ChildLastName;
                dba.DOB = apps.DOB;
                dba.Class = apps.Class;
                dba.Created = apps.Created;
                dba.Updated = apps.Updated;
                RccgRepository.Save();
                //return View(app);
                return RedirectToAction("Index");
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
     }
}
