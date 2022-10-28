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
using System.Security.Claims;
using System.Net.Mail;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Newtonsoft.Json;

namespace RccgChildrenManagement.Controllers
{
    //[Authorize]
    public class UserController : Controller
    {
        IRccgRepository RccgRepository;

        public UserController(IRccgRepository Rrccg)
        {
            RccgRepository = Rrccg;
        }
        [Authorize(Roles = "Admin")]
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


            var List = RccgRepository.Users;

            return View(List);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult AdminIndex()
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
            var list = RccgRepository.Users.Where(d => d.EmailAddress == d.EmailAddress && d.RoleId == 2).ToList();
            //var admin = RccgRepository.Users;

            return View(list);
        }
      //  [Authorize(Roles = "Admin")]
        // POST: UserController/DataTable
        public IActionResult DataTable()
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
            
            var list = RccgRepository.Users.Where(d => d.EmailAddress == d.EmailAddress && d.RoleId == 1).ToList();
            //var admin = RccgRepository.Users;

            return View(list);

            
        }

       

        [Authorize(Roles = "Admin")]
        // GET: UserController/Create
        public ActionResult Create()
        {
           // ViewBag.User = User();
            return View();
        }
      //  [Authorize(Roles = "Admin")]
        // POST: UserController/Create
        [HttpPost]
        
        public ActionResult Create(User app)
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
                    NewValue = "User",
                    //  OldValue = "",
                    IpAddress = ip,
                    CreatedBy = HttpContext.User.Identity.Name,
                    ObjectName = "Create",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                };
                RccgRepository.AddAuditTrail(auditTrail);
                RccgRepository.Save();

                app.Password = GetMD5(app.Password);
                app.Created = DateTime.Now;
                app.Updated = DateTime.Now;

                RccgRepository.AddUser(app);
                RccgRepository.Save();
               
                // TempData["status"] = "User Created successfully";
                TempData["status"] = "Admin User Created Successfully ";
                // return View();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                return View();
            }
        }
        // GET: UserController/Create
        public ActionResult CreateUser()
        {
            
            return View();
        }

        // POST: UserController/CreateUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(User app)
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
                    NewValue = "User",
                    //  OldValue = "",
                    IpAddress = ip,
                    CreatedBy = HttpContext.User.Identity.Name,
                    ObjectName = "Create",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                };
                RccgRepository.AddAuditTrail(auditTrail);
                RccgRepository.Save();

                app.Password = GetMD5(app.Password);
                app.Created = DateTime.Now;
                app.Updated = DateTime.Now;

                RccgRepository.AddUser(app);
                RccgRepository.Save();

                // TempData["status"] = "User Created successfully";
                TempData["ModelState"] = "User Created Successfully ";
                // return View();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                return View();
            }
        }
        //EmailOtp verification and save otp to database.       
        // POST: UserController/SendMail
        public bool SendMail(string EmailAddress, string subject, string message, string otp)
        {
            bool status = false;
            try 
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
                    mail.Subject = "OTP CODE to verify EmailAddress";
                    string Body = $"Dear {user.EmailAddress},to verify your Email use this OTP {otp} number";
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
                        status = true;
                    }

                    TempData["ModelState"] = "Code sent to your EmailAddress Successfully ";
                }
                return status;
            } 
            catch(Exception ex) 
            {
                return status;
            }
            
        }     


       // Generate a QRCode
        public string QRCode()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }
        
       // [Authorize]
        // GET: User/Register
        [ActionName("Register")]
        [HttpGet]
        public IActionResult RegisterDetails()
        {
            return View();
        }
        // POST: User/Register
        //[Authorize]
        [ActionName("Register")]
        [HttpPost]    
        public IActionResult RegisterDetails(User model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    
                    return View(model);
                }
                var check = RccgRepository.Users.Where(d => d.EmailAddress == model.EmailAddress).FirstOrDefault();
                if (check !=null )
                {
                    ModelState.AddModelError("Error", "Email already exixst!");
                    return View();
                }
                // POST: User/AuditTrail 
                var ip = HttpContext.Connection.RemoteIpAddress.ToString();

                AuditTrail auditTrail = new AuditTrail
                {
                    Action = "Create",
                    NewValue = "User",
                    //  OldValue = "",
                    IpAddress = ip,
                    CreatedBy = HttpContext.User.Identity.Name,
                    ObjectName = "Create",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                };
                RccgRepository.AddAuditTrail(auditTrail);
                RccgRepository.Save();

                foreach (var d in model.ChildrenDetails)
                {
                    //// POST: User/Children       
                    Children child = new Children();
                    child.EmailAddress = model.EmailAddress;
                    child.ChildFirstName = d.ChildFirstName.ToString();
                    child.ChildLastName = d.ChildLastName.ToString();
                    child.DOB = Convert.ToDateTime(d.DOB);
                    child.Class = d.Class.ToString();
                    child.Created = DateTime.Now;
                    child.Updated = DateTime.Now;
                    RccgRepository.AddChildren(child);
                    RccgRepository.Save();
                }

                // POST: User/ResponsibleParty 
                ResponsibleParty responsible = new ResponsibleParty();
                responsible.PersonType = model.PersonType;
                responsible.relfn = model.relfn;
                responsible.relln = model.relln;
                responsible.relemail = model.relemail;
                responsible.relphonenumber = model.relphonenumber;
                responsible.Created = DateTime.Now;
                responsible.Updated = DateTime.Now;
                RccgRepository.AddResponsibleParty(responsible);
                RccgRepository.Save();

                // POST: User/Otp 
                string newOTP = GenerateNumber();
                Otp OTP = new Otp();
                OTP.OtpCode = newOTP;
                OTP.EmailAddress = model.EmailAddress;
                OTP.OtpUsed = false;
                OTP.Created = DateTime.Now;
                OTP.Updated = DateTime.Now;

                RccgRepository.AddOtp(OTP);
                RccgRepository.Save();


                model.Password = GetMD5(model.Password);
                model.Created = DateTime.Now;
                model.Updated = DateTime.Now;

                RccgRepository.AddUser(model);
                RccgRepository.Save();
         

                // code to SendEmail 
                SendMail(model.EmailAddress, "", "",newOTP);                

                TempData["status"] = "<h2>Thank you for registering, an email with <b> OTP verification code </b> has been sent to your registered email </h2>" +
                "<p> We will require your <b>QRcode</b> when dropping or picking up your child(ren) </p>";
  
                // return View();
                return RedirectToAction("Verify", "Login",new {email=model.EmailAddress });

            }
            catch (Exception e)
            {
                return View();
            }
        }
      //  [Authorize(Roles = "Admin")]
        // GET: User/Admin
        [ActionName("Admin")]
        [HttpGet]
        public IActionResult AdminDetails()
        {
            return View();
        }
        // POST: User/Admin
        //[Authorize]
        [HttpPost]
        [ActionName("Admin")]
        public IActionResult AdminDetails(User model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);
                }
                var check = RccgRepository.Users.Where(d => d.EmailAddress == model.EmailAddress).FirstOrDefault();
                if (check != null)
                {
                    ModelState.AddModelError("Error", "Email already exixst!");
                    return View();
                }
                // POST: User/AuditTrail 
                var ip = HttpContext.Connection.RemoteIpAddress.ToString();

                AuditTrail auditTrail = new AuditTrail
                {
                    Action = "Create",
                    NewValue = "User",
                    //  OldValue = "",
                    IpAddress = ip,
                    CreatedBy = HttpContext.User.Identity.Name,
                    ObjectName = "Create",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                };
                RccgRepository.AddAuditTrail(auditTrail);
                RccgRepository.Save();

               
                // POST: User/Otp 
                string newOTP = GenerateNumber();
                Otp OTP = new Otp();
                OTP.OtpCode = newOTP;
                OTP.EmailAddress = model.EmailAddress;
                OTP.OtpUsed = false;
                OTP.Created = DateTime.Now;
                OTP.Updated = DateTime.Now;

                RccgRepository.AddOtp(OTP);
                RccgRepository.Save();


                model.Password = GetMD5(model.Password);
                model.Created = DateTime.Now;
                model.Updated = DateTime.Now;

                RccgRepository.AddUser(model);
                RccgRepository.Save();


                // code to SendEmail 
                SendMail(model.EmailAddress, "", "", newOTP);

              //  TempData["status"] = "<h2>Thank you for registering, an email with <b> OTP verification code </b> has been sent to your registered email </h2>" +
               // "<p> We will require your <b>QRcode</b> when dropping or picking up your child(ren) </p>";

                // return View();
                return RedirectToAction("Verify", "Login", new { email = model.EmailAddress });

            }
            catch (Exception e)
            {
                return View();
            }
        }

        // POST: user/Edit/5
        // [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ResetOtp([Bind] User model, String EmailAddress)
        {

            // POST: User/Otp 
            string newOTP = GenerateNumber();
            Otp OTP = new Otp();
            OTP.OtpCode = newOTP;
            OTP.EmailAddress = model.EmailAddress;
            OTP.OtpUsed = false;
            OTP.Created = DateTime.Now;
            OTP.Updated = DateTime.Now;
            // code to SendEmail 
            SendMail(model.EmailAddress, "", "", newOTP);
            return View();

        }

         // GET: User/Edit/5
        //  [Authorize]
        [HttpGet]
        public ActionResult Change(int Id)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            var apps = RccgRepository.Users;
            User dba = RccgRepository.Users.FirstOrDefault(d => d.EmailAddress == userId);
            return View(dba);
        }

       // [Authorize]
        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Change(User app)
        {
            try
            {
                var UserEmail = HttpContext.User.Identity.Name;
                var ip = HttpContext.Connection.RemoteIpAddress.ToString();

                AuditTrail auditTrail = new AuditTrail
                {
                    Action = "Change",
                    NewValue = "User",
                    //  OldValue = "",
                    IpAddress = ip,
                    CreatedBy = HttpContext.User.Identity.Name,
                    ObjectName = "Change",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                };
                RccgRepository.AddAuditTrail(auditTrail);
                RccgRepository.Save();


                // TODO:  Edit logic here


               
                User dba = RccgRepository.Users.FirstOrDefault(d => d.EmailAddress == UserEmail);
              
                dba.Password = GetMD5(app.NewPassword);
                dba.Updated = DateTime.Now;
      
               // RccgRepository.AddUser(dba);
                RccgRepository.Save();
                //  return View(app);
                TempData["status"] = "Password Changed Successfully ";
                return RedirectToAction("Index", "Home");
            }

            catch (Exception e)
            {
                return View();
            }
        }


        


        //  [Authorize]
        // GET: UserController/Edit/5
        public ActionResult Edit(int Id)
        {
            
            ViewBag.User = User();
           
            var apps = RccgRepository.Users;
            User dba = RccgRepository.Users.FirstOrDefault(d => d.UserId == Id);
            return View(dba);
        }

        // POST:UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User apps)
        {
            try
            {
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

                var app = RccgRepository.Users;
                User dba = RccgRepository.Users.FirstOrDefault(d => d.UserId == apps.UserId);
                dba.FirstName = apps.FirstName;
                dba.LastName = apps.LastName;
                dba.Address= apps.Address;
                dba.PhoneNo = apps.PhoneNo;
                dba.EmailAddress = apps.EmailAddress;
                dba.Password = apps.Password;
                dba.Member_Visitor = apps.Member_Visitor;
                dba.Kidnumber = apps.Kidnumber;
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
        
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        // Generate a random string with a given size    
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        // Generate a random password    
        public string GenerateNumber()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomNumber(100000, 999999));
            return builder.ToString();
        }


        //For generating random number
        public string GeneratePassword()
        {
            string PasswordLength = "6";
            string NewPassword = "";

            string allowedChars = "";
            allowedChars = "1,2,3,4,5,6,7,8,9,0";
           // allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
           // allowedChars += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";

            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);
            string IDString = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < Convert.ToInt32(PasswordLength); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                IDString += temp;
                NewPassword = IDString;
            }
            return NewPassword;
        }

    public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                //lower  
                byte2String += targetData[i].ToString("x2");
                //upper  
                //byte2String += targetData[i].ToString("X2");  
            }
            return byte2String;
        }

        public List<SelectListItem> User1()
        {
            if (HttpContext.User.IsInRole("Parent"))
            {

                var user = new List<SelectListItem>();
                var items = RccgRepository.Users.ToList();
                foreach (var t in items)
                {
                    user.Add(new SelectListItem { Text = t.EmailAddress, Value = t.UserId.ToString() });
                }
                return user;
            }
            else
            {
                string username = HttpContext.User.Identity.Name;
                var user = new List<SelectListItem>();
                var items = RccgRepository.Users.Where(d => d.EmailAddress == username).ToList();
                foreach (var t in items)
                {
                    user.Add(new SelectListItem { Text = t.EmailAddress, Value = t.UserId.ToString() });
                }
                return user;
            }

        }

    }

   
}

