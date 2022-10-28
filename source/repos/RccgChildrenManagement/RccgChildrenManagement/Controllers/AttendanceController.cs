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
using System.Net.Mail;
using System.IO;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Data.SqlClient;
using MessagingToolkit.QRCode.Codec.Data;
using RccgChildrenManagement.DataClass;

namespace RccgChildrenManagement.Controllers
{
    // [Authorize(Roles="Admin")]
   
    public class AttendanceController : Controller
    {
        IRccgRepository RccgRepository;

        public AttendanceController(IRccgRepository Rrccg)
        {
            RccgRepository = Rrccg;
        }
        public ActionResult Index()
        {
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


            var List = RccgRepository.Attendances;

            return View(List);
        }

        //  [Authorize(Roles = "Admin")]
        // POST: Attendance/Controller/DropOffMail
        public IActionResult DropOffMail()
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

            var list = RccgRepository.Attendances.Where(d => d.EmailAddress == UserEmail).ToList();
            //var admin = RccgRepository.Users;

            return View(list);


        }


        // GET: UserController/GenerateQRCode
        public IActionResult GenerateQRCode()
        {

            return View();
        }
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public string GenerateNumber()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomNumber(100000, 999999));
            return builder.ToString();
        }
        public string GenerateQRImage(string QRString)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRString, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap bitMap = qrCode.GetGraphic(20);
                bitMap.Save(ms, ImageFormat.Png);
                string fileLocation = "/wwwroot/QRCodeImage/"+ QRString+".png";
                
                return "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
            }
        }


        // POST: UserController/SendQRCodeMail
        public ActionResult SendQRCodeMail(string EmailAddress, string subject, string message, string QRCodeImage)
        {
            try
            {
                bool status = false;
                string imagePath = EmailClass.GenerateQRWithImagePath(QRCodeImage);
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
                    mail.IsBodyHtml = true;
                    mail.To.Add(user.EmailAddress);
                    mail.From = new MailAddress("portal@posshop-ng.com");
                    mail.Subject = "QR CODE to DropOff Children";
                    //string qrcodeImage = 
                    string Body = $"Dear {user.FirstName},to dropOff Children use this QRCode attached to this Email<br><br><img src='" + imagePath + "', QRCodeAttachment />";

                    string fileName = "wwwroot/QRCodeImage/" + QRCodeImage + ".png";
                    mail.Attachments.Add(new Attachment(fileName));


                    string Body1 = string.Format("Dear {0} your password is {1} ", user.EmailAddress, user.Password);
                    string Password = user.Password;
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient())
                    {

                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Host = "mail.posshop-ng.com";
                        smtp.Port = 25; //587; 465
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential("portal@posshop-ng.com", "7qfRq98#"); // Enter seders User name and password  
                        smtp.EnableSsl = false;
                        smtp.Send(mail);
                        status = true;
                    }
                  

                    using (StreamWriter stream = new StreamWriter(("wwwroot/EmailLog.txt"), false))
                    {
                        stream.WriteLine("Date:" + DateTime.Now + "EmailAddress:" + EmailAddress + "Message:" + "Sent Sucessfully"); // Write the file.
                        stream.Flush();
                        stream.Close();
                    }
                    // TempData["ModelState"] = "QRCode sent to your EmailAddress Successfull";
                    
                }
                return View();
            }
            catch (Exception ex) 
            {
                using (StreamWriter stream = new StreamWriter(("wwwroot/EmailLog.txt"), false))
                {
                    stream.WriteLine("Date:" + DateTime.Now + "EmailAddress:" + EmailAddress + "Message:" + ex.Message); // Write the file.
                    stream.Flush();
                    stream.Close();
                }
                return View();
            }
        } 




            // GET: UserController/GenerateQRCode
            public IActionResult Create()
        {
            return View();
        }

        // POST: AttendanceController/Create
        [HttpPost]
        public ActionResult Create(Attend model)
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
                    NewValue = "Attendance",
                    //  OldValue = "",
                    IpAddress = ip,
                    CreatedBy = HttpContext.User.Identity.Name,
                    ObjectName = "Create",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                };
                RccgRepository.AddAuditTrail(auditTrail);
                RccgRepository.Save();
                string parentQrCode = GenerateNumber();
                string receipientEmail = "";
                foreach (var d in model.details)
                {
                    if (d.isActive == true)
                    {
                        var child = RccgRepository.Childrens.Where(f => f.ChildrenId == d.ChildrenId).FirstOrDefault();
                        Attendance attendance1 = new Attendance();
                        attendance1.ChildrenId = d.ChildrenId;
                        attendance1.EmailAddress = child.EmailAddress;
                        attendance1.ParentCode = parentQrCode;
                        attendance1.ChildrenCode = GenerateNumber();
                        
                        attendance1.QRImage = GenerateQRImage(attendance1.ChildrenCode);
                        attendance1.DroppedOff = false;
                        attendance1.PickedUp = false;
                        attendance1.Created = DateTime.Now;
                        attendance1.Updated = DateTime.Now;
                        receipientEmail = child.EmailAddress;
                        RccgRepository.AddAttendance(attendance1);
                        RccgRepository.Save();
                    }
                }
                var userInfo = RccgRepository.Users.Where(f => f.EmailAddress == receipientEmail).FirstOrDefault();
                //// code to SendEmail 
                EmailClass.SendQRCodeMail(receipientEmail, "", "", parentQrCode,userInfo.FirstName);

                TempData["ModelState"] = "Children Dropped Up successfully, Check your email for QRCode";
                return  View();//RedirectToAction("Attendance", "Create");
               

            }
            catch (Exception e)
            {
                return View();
            }
        }
        // Get: AttendanceController/FetchQRCode
        public ActionResult PickUpQRCode()
        {
            return View();
        }

        // POST: AttendanceController/FetchQRCode
        [HttpPost]
        [HttpGet]
        public ActionResult PickUpQRCode(string id, string ChildrenId)
        {
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


            ViewBag.id = id;
            var display = RccgRepository.Attendances.Join
                (RccgRepository.Childrens, r => r.ChildrenId, p => p.ChildrenId, (r, p) => new { r, p })
                .Where(m => m.r.ParentCode == id && m.r.DroppedOff == true && m.r.PickedUp == false).
                Select(g => new FetchQrDetails
                {
                    ChildrenCode = g.r.ChildrenCode,
                    ChildrenId = g.r.ChildrenId,
                    ChildFirstName = g.p.ChildFirstName,
                    ChildLastName = g.p.ChildLastName,
                    ParentCode = g.r.ParentCode
                });

            return View(display);

            //ViewBag.id = id;
            //var disp = RccgRepository.Attendances.Where(d => d.ParentCode == id && d.ChildrenCode == ChildrenId && d.DroppedOff == true && d.PickedUp == false).FirstOrDefault();
            //if (disp != null)
            //{
            //    disp.PickedUp = true;
            //    disp.Updated = DateTime.Now;
            //    RccgRepository.Save();
            //    TempData["status"] = "QRCode Verification is successful, Children Picked Up, Bye till next week";
            //    return RedirectToAction(nameof(PickUpQRCode));
            //}

          
            //else
            //{
            //    TempData["statuss"] = "Parent and Children Code Mismatch";
            //    return RedirectToAction(nameof(PickUpQRCode));
            //}

        }
    

        // Get: AttendanceController/FetchQRCode
        public ActionResult FetchQRCode()
        {
            return View();
        }

        // POST: AttendanceController/FetchQRCode
        [HttpPost]
        [HttpGet]
        public ActionResult FetchQRCode(string id)
        {
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


            ViewBag.id = id;
            var display = RccgRepository.Attendances.Join
                (RccgRepository.Childrens, r=>r.ChildrenId, p=>p.ChildrenId, (r,p)=> new { r,p})
                .Where(m=>m.r.ParentCode==id && m.r.DroppedOff==false && m.r.PickedUp== false).
                Select(g => new FetchQrDetails
                {
                    ChildrenCode= g.r.ChildrenCode,
                    ChildrenId = g.r.ChildrenId,
                    ChildFirstName = g.p.ChildFirstName,
                    ChildLastName = g.p.ChildLastName,
                    ParentCode = g.r.ParentCode


                });
              
            return View(display);
        }


        //// Get: AttendanceController/PickUp
        //[HttpGet]
        //public ActionResult PickUp()
        //{
        //    return View();
        //}

        // POST: AttendanceController/PickUp
        [HttpPost]
        public ActionResult PickUp(string id, string ChildrenId)
        {
            try
            {
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


                ViewBag.id = id;
                var display = RccgRepository.Attendances.Where(d => d.ParentCode == id && d.ChildrenCode == ChildrenId && d.DroppedOff == true && d.PickedUp == false).FirstOrDefault();
                if (display != null)
                {
                    display.PickedUp = true;
                    display.Updated = DateTime.Now;
                    RccgRepository.Save();
                    TempData["status"] = "QRCode Verification is successful, Children Picked Up, Bye till next week";
                    return RedirectToAction(nameof(PickUp));                                                                                                                      
                }

                //ViewBag.id = id;
                //var disp = RccgRepository.Attendances.Where(d => d.ParentCode == d.ParentCode && d.ChildrenCode == d.ChildrenCode).FirstOrDefault();

                //if (disp.ParentCode != disp.ChildrenCode)
                //{
                //    TempData["statuss"] = "QRCode  Mismatch, Try Again";
                //    return RedirectToAction(nameof(PickUp));
                //}
                else
                {
                    TempData["statuss"] = "Parent and Children Code Mismatch";
                    return RedirectToAction(nameof(PickUp));
                }            
               
            }
            catch (Exception e)
            {
                return View();
            }
        }
        // GET: AttendanceController/Print
        [HttpGet]
        public ActionResult PrintQRCode(string id)
        {
            
            ViewBag.id = id;
            var display = RccgRepository.Attendances.Where(d => d.ChildrenCode == id && d.DroppedOff == false && d.PickedUp == false).FirstOrDefault();
            if (display != null)
            {
                display.DroppedOff = true;
                display.Updated = DateTime.Now;
                RccgRepository.Save();
            }


            return View();
        }

        [HttpGet]
        public dynamic Verify(string parentcode, string childrencode)
        {
            try
            {
                // ViewBag.id = id;
                var display1 = RccgRepository.Attendances.Where(d => d.ParentCode == parentcode && d.ChildrenCode == childrencode).FirstOrDefault(); //&& d.DroppedOff == true && d.PickedUp == false
                var display = RccgRepository.Attendances.Join
                    (RccgRepository.Childrens, r => r.ChildrenId, p => p.ChildrenId, (r, p) => new { r, p })
                    .Where(m => m.r.ParentCode == parentcode && m.r.ChildrenCode == childrencode && m.r.DroppedOff == false && m.r.PickedUp == false).
                      Select(g => new FetchQrDetails
                      {
                          ChildrenCode = g.r.ChildrenCode,
                          ChildrenId = g.r.ChildrenId,
                          ChildFirstName = g.p.ChildFirstName,
                          ChildLastName = g.p.ChildLastName,
                          ParentCode = g.r.ParentCode
                      });


                if (display != null)
                {
                    var childInfo = RccgRepository.Childrens.Where(k => k.ChildrenId == display1.ChildrenId).FirstOrDefault();
                    display1.PickedUp = true;
                    display1.Updated = DateTime.Now;
                    RccgRepository.Save();
                    TempData["status"] = "QRCode Verification is successful, Child Picked Up";
                    return new { childInfo, status = "QRCode Verification is successful, Child Picked Up" }; //RedirectToAction(nameof(PickUp));
                }
                else
                {
                    //TempData["statuss"] = "Parent and Children Code Mismatch";
                    //return RedirectToAction(nameof(PickUp));
                    return new { status = "Parent and Children Code Failed, Try again later" };
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }

        [HttpPost]
        public dynamic PrintQRCode(string id, string ChildrenId)
        {
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


            ViewBag.id = id;
            var display = RccgRepository.Attendances.Where(d => d.ParentCode == id && d.ChildrenCode == ChildrenId && d.DroppedOff == false && d.PickedUp == false).FirstOrDefault();
            if (display != null)
            {
                display.DroppedOff = true;
                display.Updated = DateTime.Now;
                RccgRepository.Save();
              //  return RedirectToAction(nameof(FetchQRCode));
            }
            return new {display ,status = true };
        }
    }
}
    
