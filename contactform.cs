using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Net.Mail;
using ContactFormNew.ControlTemplates;
using System.Linq;

namespace ContactFormNew.ControlTemplates.ContactFormNew
{
    public partial class ContactForm : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    
        private void SendEmails()
        {
            string to = "info@marchofdimes.ca"; /*This is the Default Email to send request to*/
            // to = "rkapelus@marchofdimes.ca";
            string Reason = subjectDBox.SelectedItem.Text;
            string bccmail ="" /*= "HoldingBoxEmail,"*/;

            if (Reason == "Address Change")
            {
                to = "rehamparam@marchofdimes.ca";
                bccmail = /*bccmail +*/"tthornhill@marchofdimes.ca";
            }
            if (Reason == "Mailing List Inquiry")
            {
                to = "rehamparam@marchofdimes.ca";//rehamparam
                bccmail = /*bccmail +*/"tthornhill@marchofdimes.ca";
            }
            if (Reason == "Working at March of Dimes")
            {
                to = "recruitment@marchofdimes.ca";//recruitment
                bccmail = /*bccmail +*/"tthornhill@marchofdimes.ca";
            }
            if (Reason == "Funding for Assistive Devices")
            {
                to = "sbolger@marchofdimes.ca";//used to be trobbins  trobbins@marchofdimes.ca sbolger@marchofdimes.ca
                bccmail = /*bccmail +*/"tthornhill@marchofdimes.ca";
            }
            if (Reason == "Funding for Home and/or Vehicle Modification")
            {
                to = "hvmp@marchofdimes.ca";//hvmp
                bccmail = /*bccmail +*/"tthornhill@marchofdimes.ca";
            }
            if (Reason == "Advocacy")
            {
                to = "advocacy@marchofdimes.ca";//advocacy
                bccmail = /*bccmail +*/"tthornhill@marchofdimes.ca";
            }
            if (Reason == "Events")
            {
                to = "events@marchofdimes.ca";//events
            }
            if (Reason == "Government Relations")
            {
                to = "advocacy@marchofdimes.ca";//advocacy
                bccmail = /*bccmail +*/"tthornhill@marchofdimes.ca";
            }
            if (Reason == "An Other Reason")
            {
                to = "info@marchofdimes.ca";//info
                bccmail = /*bccmail +*/"tthornhill@marchofdimes.ca";
            }
            if (Reason == "Volunteering")
            {
                to = "vbarber@marchofdimes.ca";//vbarber
                bccmail = /*bccmail +*/"tthornhill@marchofdimes.ca";
            }
            if (Reason == "Website Related")
            {
                to = "webmaster@marchofdimes.ca";
                bccmail = /*bccmail +*/"tthornhill@marchofdimes.ca";
            }
            if (Reason == "Media inquiries")
            {
                to = "media@marchofdimes.ca";//media
                bccmail = /*bccmail +*/"tthornhill@marchofdimes.ca";
            }
            if (Reason == "Polio Canada")
            {
                to = "polio@marchofdimes.ca";//polio
                bccmail = /*bccmail +*/"tthornhill@marchofdimes.ca";
            }
            if (Reason == "Stroke Recovery Canada")
            {
                to = "src@marchofdimes.ca ";//src
                bccmail = /*bccmail +*/"tthornhill@marchofdimes.ca";
            }
            if (Reason == "Programs")
            {
                to = "@marchofdimes.ca";
            }


            string from = "modcwebsite@marchofdimes.ca";

            string mbody = "<html><head><meta name='WebPartPageExpansion' content='full' /></head><body><b>Contact Us Form Submitted</b><hr><br>";


            mbody = mbody + "<br><b>Origin Page: </b>" + Request.Url.ToString();
            mbody = mbody + "<br><b>From: </b>" + nameTextBox.Text;
            mbody = mbody + "<br><b>Email: </b>" + emailTextBox.Text;
            mbody = mbody + "<br><b>Reason: </b>" + subjectDBox.SelectedItem.Text;
            mbody = mbody + "<br><br><b>Message: </b>" + bodyTextBox.Text;
            mbody = mbody + "<br><br><br><b>Time Sent: </b>" + DateTime.Now.ToLongTimeString();

            mbody = mbody + "<br><hr><br><br>Please forward to the appropriate person(s) if this wasn't intended for you.</body></html>";

            MailMessage mail = new MailMessage(from, to);

            mail.Subject = "ContactUs Form: " + subjectDBox.SelectedItem.Text + " - " + nameTextBox.Text;
            mail.IsBodyHtml = true;
            mail.Body = mbody;
            if (bccmail != "")
            {
                mail.Bcc.Add(bccmail);
            }

            string smtpHost = "10.0.1.54";
            SmtpClient client = new SmtpClient(smtpHost);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;


            try
            {
                client.Send(mail);
            }
            catch (SmtpException smtpEx)
            {
                // Just letting the error happen
            }
        }

        private void SendThankYouEmails()
        {
            string emailtoo = emailTextBox.Text;
            string to = emailtoo;
            string from = "modcwebsite@marchofdimes.ca";

            string mbody = "<html><head><meta name='WebPartPageExpansion' content='full' /></head><body>";
            mbody = mbody + "<br><br><a href='http://marchofdimes.ca/'><img class='noborder' alt='March of Dimes Canada Logo' src='http://marchofdimes.ca//Style%20Library/Images/ar13_logo.jpg'></a><br><br><hr>";
            mbody = mbody + "<br>To: " + nameTextBox.Text;
            mbody = mbody + "<br><br><br>Thank you for your contacting March of Dimes Canada.<br><br> We have received your message and a representative from March of Dimes Canada will be in contact with you. <br><br><br> Thank you,<br>March of Dimes Canada";
            mbody = mbody + "<br><br><hr><div>";
            mbody = mbody + "<br><b>March of Dimes Canada<b><br><span style='color:teal;'>Providing Canadians with disablities more opportinities for independence for over 60 years</span><br><br>";
            mbody = mbody + "<span><strong class='UpperCase newuppercase'>Join us on:</strong> </span><br><br>";
			mbody = mbody + "<a href='http://www.facebook.com/marchofdimescanada' class='socialbtn' target='_blank' title='Click to visit our Facebook Page'>";
			mbody = mbody + "<img src='http://marchofdimes.ca//Style%20Library/Images/FBLogo__blue.png' alt='Click to visit our facebook page' border='0' width='35px'>";
            mbody = mbody + "</a>&nbsp;&nbsp;&nbsp;";
			mbody = mbody + "<a href='http://twitter.com/modcanada' class='socialbtn' target='_blank' title='Click to visit our Twitter Page'>";
			mbody = mbody + "<img src='http://marchofdimes.ca//Style%20Library/Images/Twitter_logo_blue.png' alt='Click to visit our Twitter page' border='0' width='35px'>";
            mbody = mbody + "</a>&nbsp;&nbsp;&nbsp;";
			mbody = mbody + "<a href='http://www.youtube.com/user/marchofdimescda' class='socialbtn' target='_blank' title='Click to visit our YouTube Page'>";
			mbody = mbody + "<img src='http://marchofdimes.ca//Style%20Library/Images/YouTube-social-square_red_48px.png' alt='Click to visit our YouTube page' border='0' width='35px'>";
            mbody = mbody + "</a>&nbsp;&nbsp;&nbsp;";
			mbody = mbody + "<a href='http://instagram.com/marchofdimescda' class='socialbtn' target='_blank' title='Click to visit our Instagram Page'>";
			mbody = mbody + "<img src='http://marchofdimes.ca//Style%20Library/Images/Instagram_Icon_Large.png' alt='Click to visit our Instagram page' border='0' width='35px'>";
			mbody = mbody + "</a>";

			mbody = mbody + "</div><br>";
            
            mbody = mbody + "<br><br></body></html>";

            MailMessage mail = new MailMessage(from, to);

            mail.Subject = "Thank You: " + nameTextBox.Text;
            mail.IsBodyHtml = true;
            mail.Body = mbody;

            string smtpHost = "10.0.1.54";
            SmtpClient client = new SmtpClient(smtpHost);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;


            if (mrmari.Text == "")
            {
                try
                {

                    client.Send(mail);

                }
                catch (SmtpException smtpEx)
                {
                    // Just letting the error happen
                }
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SendEmails();
            SendThankYouEmails();
            Response.Redirect("~/EN/Pages/thanks.aspx");
        }

    }
}


