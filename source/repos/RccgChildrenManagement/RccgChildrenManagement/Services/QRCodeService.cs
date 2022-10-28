//using QRCoder;
//using RccgChildrenManagement.Models;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Drawing.Imaging;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;

//namespace RccgChildrenManagement.Services
//{
//    public class QRCodeService
//    {    
//        public static QRCodeResponse Generate()
//        {
//            Random random = new Random();
//            int randNum = random.Next(000000, 999999);
//            QRCodeResponse qrResponse = new QRCodeResponse();
//            string inputData = randNum.ToString();
//            string QRCodeImg;
//            using (MemoryStream memoryStream = new MemoryStream())
//            {
                
//                QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
//                QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(inputData, QRCodeGenerator.ECCLevel.Q);
//                QRCode qRCode = new QRCode(qRCodeData);
//                using (Bitmap bitmap = qRCode.GetGraphic(20))
//                {
//                    bitmap.Save(memoryStream, ImageFormat.Png);
//                    QRCodeImg = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
//                    qrResponse.Code = inputData;
//                    qrResponse.Image = QRCodeImg;

//                }
//            }

//            return qrResponse;
//        }

//        public static QRCodeResponse DisplayQRCode(string inputData)
//        {
            
//            QRCodeResponse qrResponse = new QRCodeResponse();            
//            string QRCodeImg;
//            using (MemoryStream memoryStream = new MemoryStream())
//            {

//                QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
//                QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(inputData, QRCodeGenerator.ECCLevel.Q);
//                QRCode qRCode = new QRCode(qRCodeData);
//                using (Bitmap bitmap = qRCode.GetGraphic(20))
//                {
//                    bitmap.Save(memoryStream, ImageFormat.Png);
//                    QRCodeImg = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
//                    qrResponse.Code = inputData;
//                    qrResponse.Image = QRCodeImg;

//                }
//            }

//            return qrResponse;
//        }


//    }
//}
