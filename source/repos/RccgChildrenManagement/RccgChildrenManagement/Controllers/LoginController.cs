using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Net.Mail;
using RccgChildrenManagement.Models;
using System.Security.Policy;

namespace RccgChildrenManagement.Controllers
{
    public class LoginController : Controller
    {
        IRccgRepository RccgRepository;
        private readonly RccgDbContext _context;

        public LoginController(IRccgRepository Rrccg, RccgDbContext context)
        {
            RccgRepository = Rrccg;
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
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
                    mail.Subject = "OTP CODE to veryfying EmailAddress";
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
            catch (Exception ex)
            {
                return status;
            }

        }


        // Generate a random password    
        public string GenerateNumber()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomNumber(100000, 999999));
            return builder.ToString();
        }
        //  [Authorize]
        [HttpPost]
        public ActionResult Login(string EmailAddress, string password)
        {
            try
            {
                var ip = HttpContext.Connection.RemoteIpAddress.ToString();

                var app = RccgRepository.Users;
                User cs = RccgRepository.Users.FirstOrDefault(d => d.EmailAddress == EmailAddress && d.Password == (GetMD5(password)) && d.OtpUsed == true);
                var user = _context.Users.Where(u => u.EmailAddress.Equals(EmailAddress) && u.Password.Equals(GetMD5(password)) && u.OtpUsed == false).FirstOrDefault();
              
                if (user != null)
                {
                    ModelState.AddModelError("Invalid Login", "Account not verified!");
                    // code to SendEmail 
                    string newOTP = GenerateNumber();
                    Otp OTP = new Otp();
                    OTP.OtpCode = newOTP;
                    OTP.EmailAddress = EmailAddress;
                    OTP.OtpUsed = false;
                    OTP.Created = DateTime.Now;
                    OTP.Updated = DateTime.Now;

                    RccgRepository.AddOtp(OTP);
                    RccgRepository.Save();
                    SendMail(EmailAddress, "", "", newOTP);
                    TempData["ModelState"] = "Check your Email to enter a new OTP";
                    return RedirectToAction("VerifyOTP", new { email = EmailAddress });
                }

                if (cs == null)
                {
                    ModelState.AddModelError("Invalid Login", "Invalid Username or Password !");
                    return View();
                }
                var role = _context.Roles.Where(r => r.RoleId.Equals(cs.RoleId))?.FirstOrDefault()?.RoleName;

                //if (!cs.RoleId.HasValue)
                //{
                //    ModelState.AddModelError("Invalid Login", "Contact Administrator for Authentication !");
                //    return View();
                //}
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, EmailAddress) };
                claims.Add(new Claim(ClaimTypes.Role, role));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, EmailAddress));
                claims.Add(new Claim(ClaimTypes.Email, EmailAddress));
                claims.Add(new Claim(ClaimTypes.Sid, cs.UserId.ToString()));
                var claimsIdentity = new ClaimsIdentity(claims, "Authentication");
                var userPrincipal = new ClaimsPrincipal(claimsIdentity);
                var authenticationProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = true,
                    IssuedUtc = DateTimeOffset.UtcNow,
                };
                HttpContext.SignInAsync("Authentication", new ClaimsPrincipal(claimsIdentity), authenticationProperties);
                HttpContext.User = new System.Security.Principal.GenericPrincipal(new System.Security.Principal.GenericIdentity(EmailAddress), new string[] { cs.RoleId.ToString() });
                var userId = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
                var createdby = HttpContext.User.Identity.Name;
                var rolename = HttpContext.User.IsInRole(role);
                var check = HttpContext.User.Identity.IsAuthenticated;
                AuditTrail auditTrail = new AuditTrail
                {
                    Action = "Login",
                    NewValue = "Login",
                    //  OldValue = "",
                    IpAddress = ip,
                    CreatedBy = HttpContext.User.Identity.Name,
                    ObjectName = "Login",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                };
                RccgRepository.AddAuditTrail(auditTrail);
                RccgRepository.Save();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Login");
            }

        }




        // GET: User/Edit/5
        // [Authorize]
        [HttpGet]

        public ActionResult Change(int Id)
        {
            var apps = RccgRepository.Users;
            User dba = RccgRepository.Users.FirstOrDefault(d => d.UserId == Id);
            return View(dba);
        }

        // POST: user/Edit/5
        // [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Change(User apps)
        {
            {
                User user = RccgRepository.Users.FirstOrDefault(d => d.EmailAddress == apps.EmailAddress);
                user.Password = GetMD5(apps.NewPassword);
                RccgRepository.Save();
                return RedirectToAction(nameof(Login));

            }
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


        // POST: User/Forget/5


        // GET: UController/Verification
        [HttpGet]
        public ActionResult Verification()
        {
            return View();
        }



        public IActionResult forgot()
        {
            return View();
        }


        // GET: User/Forget/5
        //[Authorize]
        [HttpPost]
        public ActionResult forgot(string EmailAddress)
        {

            var users = RccgRepository.Users.ToList();
            User user = RccgRepository.Users.FirstOrDefault(d => d.EmailAddress == EmailAddress);

            if (user != null)
            {
                string domainName = HttpContext.Request.Host.Host;
                var id = user.UserId;
                //var Url = GenerateNumber();
                string url = Request.Scheme + "://" + Request.Host + '/' +
                 "Login" + "/" + "validate?" + "username=" + user.EmailAddress +
                 "&id=" + id;
                MailMessage mail = new MailMessage();
                mail.To.Add(user.EmailAddress);
                mail.From = new MailAddress("portal@posshop-ng.com");
                mail.Subject = "Forgot Password";
                string Body = $"Dear {user.EmailAddress},to reset your password  Kindly click <a href='{url}'>link </a> to change your password";
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
                //   SmtpClient smtp = new SmtpClient();


                // ViewBag.msg = "Password sent Successfully";
                // TempData["ModelState"] = "Password Sent Successfully ";

            }

            return View();
        }


        // GET: UserController/Veryfy
        [HttpGet]
        public ActionResult Verify()
        {
            return View();
        }

        // POST: user/Edit/5
        // [Authorize]
        [HttpPost("/Login/Verify/{email}")]
        [ValidateAntiForgeryToken]
        public IActionResult Verify(string email, string OtpCode)
        {

            Otp OTP = RccgRepository.Otps.FirstOrDefault(d => d.EmailAddress == email && d.OtpCode == OtpCode);
            if (OTP != null)
            {
                if (OTP.OtpUsed == false)
                {
                    OTP.OtpUsed = true;
                    RccgRepository.Save();
                    User user = RccgRepository.Users.Where(f => f.EmailAddress == email).FirstOrDefault();
                    if (user != null)
                    {
                        user.OtpUsed = true;
                        RccgRepository.Save();
                    }

                }
                return RedirectToAction(nameof(Login));
            }
            else
            {


                return RedirectToAction(nameof(Login));

            }
        }

        // GET: UserController/Veryfy
        [HttpGet]
        public ActionResult VerifyOTP()
        {
            return View();
        }

        // POST: user/Edit/5
        // [Authorize]
        [HttpPost("/Login/VerifyOTP/{email}")]
        [ValidateAntiForgeryToken]
        public IActionResult VerifyOTP(string email, string OtpCode)
        {

            Otp OTP = RccgRepository.Otps.FirstOrDefault(d => d.EmailAddress == email && d.OtpCode == OtpCode);
            if (OTP != null)
            {
                if (OTP.OtpUsed == false)
                {
                    OTP.OtpUsed = true;
                    RccgRepository.Save();
                    User user = RccgRepository.Users.Where(f => f.EmailAddress == email).FirstOrDefault();
                    if (user != null)
                    {
                        user.OtpUsed = true;
                        RccgRepository.Save();
                    }

                }
                return RedirectToAction(nameof(Login));
            }
            else
            {


                return RedirectToAction(nameof(Login));

            }
        }




        public IActionResult validate(string username)
        {
            User model = new User();
            model.EmailAddress = username;
            return View(model);
        }

        // POST: user/Edit/5
        // [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult validate([Bind] User model)
        {
            User user = RccgRepository.Users.FirstOrDefault(d => d.EmailAddress == model.EmailAddress);
            user.Password = GetMD5(model.NewPassword);
            RccgRepository.Save();
            return RedirectToAction(nameof(Login));

        }



        // Logout
        public async Task<ActionResult> LogOut()
        {
            try
            {
                var authenticationProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = true,
                    IssuedUtc = DateTimeOffset.UtcNow,
                };
                //HttpContext.User = null;
                // await HttpContext.Authentication.SignOutAsync("Authentication");
                await HttpContext.SignOutAsync(authenticationProperties);
                //HttpContext.Response.Cookies.Delete("Authentication");

                var createdby = HttpContext?.User?.Identity?.Name;
                // var role = HttpContext?.User?.IsInRole("Doctor");
                var check = HttpContext?.User?.Identity?.IsAuthenticated;

            }
            catch (Exception e)
            {

            }
            return Redirect(Url.Content("~/"));

            // return Redirect("");
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
    }

}

