using System.Net;
using System.Net.Mail;

namespace BloggingPlatformAPI.Mails;

public class Mail
{
    const string adressFrom = "blog@gmail.com";
    const string nameFrom = "Blog Platform";
    MailMessage mail;
    public Mail(string text, string adress, string topic) 
    {
        mail = new MailMessage();
        mail.From = new MailAddress(adressFrom, nameFrom);
        mail.To.Add(new MailAddress(adress)); 
        mail.Subject = topic;
        mail.Body = text;
        mail.IsBodyHtml = true; //HTML-теги
    }

    public void Send()
    {
        using (SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587))
        {
            // Указываем логин и пароль от вашей почты
            smtp.Credentials = new NetworkCredential("from@yandex.ru", "ваш_пароль_или_токен");
            smtp.EnableSsl = true; // Включаем шифрование TLS

            try
            {
                smtp.Send(mail);
                Console.WriteLine("Письмо успешно отправлено!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке: {ex.Message}");
            }
        }
    }
}
