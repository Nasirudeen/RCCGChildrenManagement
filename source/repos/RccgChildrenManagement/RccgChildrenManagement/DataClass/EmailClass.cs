using QRCoder;
using RccgChildrenManagement.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RccgChildrenManagement.DataClass
{
    public class EmailClass
    {
        public static string GenerateQRWithImagePath(string QRString)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRString, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap bitMap = qrCode.GetGraphic(20);
                    bitMap.Save(ms, ImageFormat.Png);

                    string fileLocation = "wwwroot/QRCodeImage/" + QRString + ".png";
                    File.WriteAllBytes(fileLocation, ms.ToArray());
                    return "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public static bool SendQRCodeMail(string EmailAddress, string subject, string message, string QRCodeImage, string Name)
        {
            bool status = false;
            try
            {
               
                string imagePath = GenerateQRWithImagePath(QRCodeImage);

              
                    // string url = Request.Scheme + "://" + Request.Host + '/' +
                    // "User" + "/" + "Validate?" + "username=" + user.EmailAddress +
                    //  "&id=" + id;
                    MailMessage mail = new MailMessage();
                    mail.IsBodyHtml = true;
                    mail.To.Add(EmailAddress);
                    mail.From = new MailAddress("portal@posshop-ng.com");
                    mail.Subject = "QRCODE to Drop Off Children";
                    //string qrcodeImage = 
                    string Body = $"Dear {Name},to dropOff child(ren) use this QRCode attached to this Email<br><br><img src='" + imagePath + "', QRCodeAttachment />";

                    string fileName = "wwwroot/QRCodeImage/" + QRCodeImage + ".png";
                    mail.Attachments.Add(new Attachment(fileName));
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
                    string path = "wwwroot/EmailLog.txt";
                    string content = "Date:" + DateTime.Now + "EmailAddress:" + EmailAddress + " Message: " + "Sent Sucessfully" + Environment.NewLine;
                    File.AppendAllText(path,content);

                return status;
            }
            catch (Exception ex)
            {
                string path = "wwwroot/EmailLog.txt";
                string content = "Date: " + DateTime.Now + "EmailAddress: " + EmailAddress + " Message: " + ex.Message + Environment.NewLine;
                File.AppendAllText(path, content);
                return status;
            }
        }
    }
}
