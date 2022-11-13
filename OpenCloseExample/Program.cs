
// In before variant with each new invoice type we need to modify our Invoice class (personally GetInvoiceDiscount method)
// And it is making ourcode more complex and each time we had to make sure that old functionalities steel works

#region Before

//public class Invoice
//{
//    public double GetInvoiceDiscount(double amount, InvoiceType invoiceType)
//    {
//        double finalAmount = 0;
//        if (invoiceType == InvoiceType.FinalInvoice)
//        {
//            finalAmount = amount - 100;
//        }
//        else if (invoiceType == InvoiceType.ProposedInvoice)
//        {
//            finalAmount = amount - 50;
//        }
//        return finalAmount;
//    }
//}
//public enum InvoiceType
//{
//    FinalInvoice,
//    ProposedInvoice
//};

#endregion

// With Open-Close principle we just create Basic Invoice class and inheriting new Invoice types from it 
// And overload GetInvoiceDiscount method making our code open for extensions but close for for modifications

#region After
public class Invoice
{
    public virtual double GetInvoiceDiscount(double amount)
    {
        return amount - 10;
    }
}

public class FinalInvoice : Invoice
{
    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 50;
    }
}
public class ProposedInvoice : Invoice
{
    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 40;
    }
}
public class RecurringInvoice : Invoice
{
    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 30;
    }
}

#endregion