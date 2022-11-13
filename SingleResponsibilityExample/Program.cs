using System.Net.Mail;

#nullable disable

// In before variant the Invoice class was doing also error logging and email sevicing such as sending

#region Before

//public class Invoice
//{
//    public long InvAmount { get; set; }
//    public DateTime InvDate { get; set; }
//    public void AddInvoice()
//    {
//        try
//        {
//            // Here we need to write the Code for adding invoice
//            // Once the Invoice has been added, then send the  mail
//            MailMessage mailMessage = new MailMessage("EMailFrom", "EMailTo", "EMailSubject", "EMailBody");
//            this.SendInvoiceEmail(mailMessage);
//        }
//        catch (Exception ex)
//        {
//            //Error Logging
//            System.IO.File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
//        }
//    }
//    public void DeleteInvoice()
//    {
//        try
//        {
//            //Here we need to write the Code for Deleting the already generated invoice
//        }
//        catch (Exception ex)
//        {
//            //Error Logging
//            System.IO.File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
//        }
//    }
//    public void SendInvoiceEmail(MailMessage mailMessage)
//    {
//        try
//        {
//            // Here we need to write the Code for Email setting and sending the invoice mail
//        }
//        catch (Exception ex)
//        {
//            //Error Logging
//            System.IO.File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
//        }
//    }
//}
#endregion


// But with Single-Responcibility principle we divided it apart for ILogger and MailSender classes for better understanding and better funcionality

#region After

public interface ILogger
{
    void Info(string info);
    void Debug(string info);
    void Error(string message, Exception ex);
}
public class Logger : ILogger
{
    public Logger()
    {
        // here we need to write the Code for initialization 
        // that is Creating the Log file with necesssary details
    }
    public void Info(string info)
    {
        // here we need to write the Code for info information into the ErrorLog text file
    }
    public void Debug(string info)
    {
        // here we need to write the Code for Debug information into the ErrorLog text file
    }
    public void Error(string message, Exception ex)
    {
        // here we need to write the Code for Error information into the ErrorLog text file
    }
}

public class MailSender
{
    public string EMailFrom { get; set; }
    public string EMailTo { get; set; }
    public string EMailSubject { get; set; }
    public string EMailBody { get; set; }
    public void SendEmail()
    {
        // Here we need to write the Code for sending the mail
    }
}

public class Invoice
{
    public long InvAmount { get; set; }
    public DateTime InvDate { get; set; }
    private ILogger fileLogger;
    private MailSender emailSender;
    public Invoice()
    {
        fileLogger = new Logger();
        emailSender = new MailSender();
    }
    public void AddInvoice()
    {
        try
        {
            fileLogger.Info("Add method Start");
            // Here we need to write the Code for adding invoice
            // Once the Invoice has been added, then send the  mail
            emailSender.EMailFrom = "emailfrom@xyz.com";
            emailSender.EMailTo = "emailto@xyz.com";
            emailSender.EMailSubject = "Single Responsibility Princile";
            emailSender.EMailBody = "A class should have only one reason to change";
            emailSender.SendEmail();
        }
        catch (Exception ex)
        {
            fileLogger.Error("Error Occurred while Generating Invoice", ex);
        }
    }
    public void DeleteInvoice()
    {
        try
        {
            //Here we need to write the Code for Deleting the already generated invoice
            fileLogger.Info("Delete Invoice Start at @" + DateTime.Now);
        }
        catch (Exception ex)
        {
            fileLogger.Error("Error Occurred while Deleting Invoice", ex);
        }
    }
}

#endregion
