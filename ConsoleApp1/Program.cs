using QRCoder;

namespace WifiQRCodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string ssid = "MyWiFiNetwork";
            string password = "123456789";
            string encryption = "WPA"; // WPA, WEP, or nopass

            string wifiString = $"WIFI:S:{ssid};T:{encryption};P:{password};;";

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(wifiString, QRCodeGenerator.ECCLevel.Q);
                PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeBytes = qrCode.GetGraphic(20);

                File.WriteAllBytes("wifi_qr_code.png", qrCodeBytes);
                Console.WriteLine("QR code image saved as wifi_qr_code.png");
            }
        }
    }
}