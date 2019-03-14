using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ApplicationHost.Quickstart.Account;
using ApplicationHost.Services;
using Hangfire;

namespace ApplicationHost.Extensions
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, UserInputModel user, string link)
        {
            var message = string.Format(@"<p> Dear {0}, </p>
                <p>An account has been created for you on infusync! <br>
                Kindly confirm your account by clicking <a href='{1}'>here</a>
                <p></p>
                <p>This mail is computer generated. Please don't respond to it<br><br>
                <p>Warm Regards, <br>
                The infusync Team
                </p>", user.FirstName, HtmlEncoder.Default.Encode(link));

            //return emailSender.SendEmailAsync(email, "Confirm your email",
            //    $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
            return Task.Run(() => BackgroundJob.Enqueue(() => emailSender.SendEmailAsync(user.Email, "Confirm your email", message)));
        }

        public static Task SendPasswordAsync(this IEmailSender emailSender, UserInputModel user, string password, string link)
        {
            var message = string.Format(@"<p> Dear {0}, </p>
                <p> Congratulations, your company has been setup on the <strong>infusync</strong> platform and you have been created as your Company's Administrator. <br>
                Your login details are: <br>
                User Name: Same as your email address ({1}). <br>
                Temporary Password: <strong>{2}</strong> <br></p>
                <p>You will be required to reset your Password when you login to the system. 
                    Kindly click on this <a href='{3}'>here</a> to log in. </p>
                <p></p>
                <p>This mail is computer generated. You don't have to respond to this.<br><br>
                <p> Warm Regards, <br>
                The infusync Team
                </p> ", user.FirstName, user.Email, password, HtmlEncoder.Default.Encode(link));

            return Task.Run(() => BackgroundJob.Enqueue(() => emailSender.SendEmailAsync(user.Email, "New infusync Admin Account Created!", message)));
        }
    }
}
