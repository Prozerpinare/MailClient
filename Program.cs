using System;
using System.Net.Mail;
using System.Net;

namespace Почттовый_клиент
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Почта отправителя, кто отправляет:");
            string mail_fr = Console.ReadLine();
            string mail_fr_name = Console.ReadLine();
            MailAddress from = new MailAddress(mail_fr, mail_fr_name); //отправитель
            Console.WriteLine("Кому отправляем (почта получателя):");
            string mail_pol = Console.ReadLine();
            MailAddress to = new MailAddress(mail_pol); //получатель
            Console.Clear();

            MailMessage objectMail = new MailMessage(from, to);
            Console.WriteLine("Тема письма:");
            string tem = Console.ReadLine();
            objectMail.Subject = tem;
            Console.WriteLine("Текст письма:");
            string bod = Console.ReadLine();
            objectMail.Body = bod;
            objectMail.IsBodyHtml = true;
            Console.Clear();

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587); //адрес сервера и порт
            Console.WriteLine("Введите логин (почта отправителя):");
            string log = Console.ReadLine();
            Console.WriteLine("Введите пароль:");
            string password = Console.ReadLine();
            smtp.Credentials = new NetworkCredential(log, password); // логин и пароль
            smtp.EnableSsl = true;
            smtp.Send(objectMail);
        }
    }
}
