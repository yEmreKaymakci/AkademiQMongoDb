using MailKit.Net.Smtp;
using MimeKit;

namespace AkademiQMongoDb.Services.EmailServices
{
    public class EmailService : IEmailService
    {
        public async Task SendDiscountEmailToSubscribersAsync(List<string> emails)
        {
            // 1. Yeni bir e-posta nesnesi oluştur
            var emailMessage = new MimeMessage();

            // 2. Gönderici Bilgileri (Kendi Gmail adresini yaz)
            emailMessage.From.Add(new MailboxAddress("Chick Chick Restoran", "senin.epostan@gmail.com"));

            // 3. Alıcıları BCC (Gizli) olarak ekle ki kimse diğerinin e-postasını görmesin
            foreach (var email in emails)
            {
                emailMessage.Bcc.Add(new MailboxAddress("", email));
            }

            // 4. Mail Konusu
            emailMessage.Subject = "%20 İndirim Kazandınız! 🥳";

            // 5. Harika bir HTML Şablonu Tasarla
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = @"
                <div style='font-family: Arial, sans-serif; text-align: center; padding: 30px; background-color: #f8f9fa; border-radius: 10px;'>
                    <h1 style='color: #ff5e14;'>Tebrikler! 🎉</h1>
                    <p style='font-size: 16px; color: #333;'>Chick Chick restoranımızda geçerli <strong>%20 indirim</strong> kazandınız!</p>
                    <div style='background-color: #ff5e14; color: white; padding: 15px; font-size: 24px; font-weight: bold; border-radius: 5px; display: inline-block; margin: 20px 0;'>
                        CHICK20
                    </div>
                    <p style='font-size: 14px; color: #666;'>Bu kodu siparişiniz sırasında görevliye söylemeniz yeterlidir. Sizi en kısa sürede aramızda görmek dileğiyle!</p>
                </div>";

            emailMessage.Body = bodyBuilder.ToMessageBody();

            // 6. Smtp İstemcisi ile Gönderim
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);

                // DİKKAT: Buraya kendi Gmail adresini ve Google'dan alacağın 'Uygulama Şifresini' (App Password) yazacaksın
                await client.AuthenticateAsync("yunus.emre5205@gmail.com", "fsgz vhlc qgoy wbii");

                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}