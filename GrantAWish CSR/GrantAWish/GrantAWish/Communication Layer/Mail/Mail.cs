using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using GrantAWish.Database_Model;

namespace GrantAWish.Communication_Layer
{
    public class Mail
    {
        MailMessage mailMessageObj;
        SmtpClient smtpClientObj;
        //System.Security.SecureString a = new System.Security.SecureString();
        
        private string _usernameSender;
        public string UsernameSender
        {
            get { return _usernameSender; }
            set { _usernameSender = "Harveen54@gmail.com"; }
        }
        private string _passwordSender;

        public string PasswordSender
        {
            get { return _passwordSender; }
            set { _passwordSender = "casino456H_"; }
        }

        private string _smtpHost;

        public string SmtpHost
        {
            get { return _smtpHost; }
            set { _smtpHost = "smtp.gmail.com"; }
        }
        
        //public Mail()
        //{
        //    mailMessageObj = new MailMessage();
        //    mailMessageObj.From = new MailAddress("");
        //    mailMessageObj.To.Add("");
        //    mailMessageObj.Subject = "";
        //    mailMessageObj.Body = "";
        //    mailMessageObj.IsBodyHtml = true;
        //    //if (FileUpload1.HasFile)
        //    //{
        //    //    FileUpload1.PostedFile.SaveAs(Server.MapPath("teachermail") + "//tobatch//" + FileUpload1.FileName);
        //    //    String p = "~//teachermail//tobatch//" + FileUpload1.FileName;
        //    //    m.Attachments.Add(new Attachment(Server.MapPath(p)));
        //    //}
        //    smtpClientObj = new SmtpClient(); //same
        //    smtpClientObj.EnableSsl = true; //same
        //    smtpClientObj.Host = "smtp.gmail.com"; //same

        //    smtpClientObj.Credentials = new NetworkCredential(UsernameSender, PasswordSender); //same
        //    try
        //    {
        //        smtpClientObj.Send(mailMessageObj);

        //    }
        //    catch (Exception ex)
        //    {

        //    }

          
        //}

        public void intializeSMTP()
        {
            smtpClientObj = new SmtpClient(); //same
            smtpClientObj.EnableSsl = true; //same
            smtpClientObj.Host = "smtp.gmail.com"; //same
            smtpClientObj.Credentials = new NetworkCredential("Harveen54@gmail.com", "casino456H_"); //same
            
        }
        public bool sendMailForgotPassword(User userObj)
        {
            mailMessageObj = new MailMessage();
            mailMessageObj.From = new MailAddress("Harveen54@gmail.com");
            mailMessageObj.To.Add("Harveen54@gmail.com");
            mailMessageObj.Subject ="GrantAWish Forgot Password" ;
            mailMessageObj.Body = "The requested password by you is " + userObj.password;
            mailMessageObj.IsBodyHtml = true;
            intializeSMTP();
            try
            {
                smtpClientObj.Send(mailMessageObj);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
       
    }
}
