using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WeightLossSystem.BL.DTO;
using WeightLossSystem.BL.Interface;
using WeightLossSystem.Domain.Entities;
using WeightLossSystem.Domain.Interfaces;

namespace WeightLossSystem.BL.Services
{
    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;
        private IUnitOfWork Database;
        public EmailOrderProcessor(EmailSettings emailSettings, IUnitOfWork unitOfWork)
        {
            this.emailSettings = emailSettings;
            this.Database = unitOfWork;
        }

        public void ProcessOrder(CartService cart, ShippingDTO shipping)
        {
            Shipping _shipping = new Shipping 
            {
                City = shipping.City,
                Email = shipping.Email,
                FirstName = shipping.FirstName,
                LastName = shipping.LastName,
                GiftWrap = shipping.GiftWrap
            };

            if (_shipping != null)
                Database.Shippings.Create(_shipping);
                Database.Save();


            using (var smtpClient = new SmtpClient()) 
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);
                if (emailSettings.WriteAsFile) 
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }
                StringBuilder body = new StringBuilder().AppendLine("New Order").AppendLine("____").AppendLine("Goods: ");
                foreach (var line in cart.Lines) 
                {
                    var subtotal = line.SportSupplement.Price * line.Quantity;
                    body.AppendFormat("{0}x{1} (total: {2:c})", line.Quantity, line.SportSupplement.Name,subtotal);
                }

                body.AppendFormat("total cost: {0:c}", cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine("Delivery:")
                    .AppendLine(shipping.FirstName)
                    .AppendLine(shipping.LastName)
                    .AppendLine(shipping.City ?? "")
                    .AppendLine("---")
                    .AppendFormat("Gift wrap: {0}",
                        shipping.GiftWrap ? "Yes" : "No");

                MailMessage mailMessage = new MailMessage(
                    emailSettings.MailFromAddress, emailSettings.MailToAddress,"We send your order!", body.ToString());

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.UTF8;
                }
                smtpClient.Send(mailMessage);
            }

           
        
           
        }
    }
}
