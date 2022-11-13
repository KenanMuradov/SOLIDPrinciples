
// In before example we HPLaserJetPrinter and LiquidInkjetPrinter classes both implements IPrinterTasks Interface but only firts uses all of the methods
// and the second one throws exceptions in methods that a not used and that is wrong behaviour 
// We can just left them empty without even throwing exception but it also will be wring cause 
// someone may call this method but nothing will happen and they will be confused

#region Before

//public interface IPrinterTasks
//{
//    void Print(string PrintContent);
//    void Scan(string ScanContent);
//    void Fax(string FaxContent);
//    void PrintDuplex(string PrintDuplexContent);
//}

//public class HPLaserJetPrinter : IPrinterTasks
//{
//    public void Print(string PrintContent)
//    {
//        Console.WriteLine("Print Done");
//    }
//    public void Scan(string ScanContent)
//    {
//        Console.WriteLine("Scan content");
//    }
//    public void Fax(string FaxContent)
//    {
//        Console.WriteLine("Fax content");
//    }
//    public void PrintDuplex(string PrintDuplexContent)
//    {
//        Console.WriteLine("Print Duplex content");
//    }
//}

//class LiquidInkjetPrinter : IPrinterTasks
//{
//    public void Print(string PrintContent)
//    {
//        Console.WriteLine("Print Done");
//    }
//    public void Scan(string ScanContent)
//    {
//        Console.WriteLine("Scan content");
//    }
//    public void Fax(string FaxContent)
//    {
//        throw new NotImplementedException();
//    }
//    public void PrintDuplex(string PrintDuplexContent)
//    {
//        throw new NotImplementedException();
//    }
//}

#endregion

// With Interface Segregation Principle we split interfaces logics apart and our classes implementsonly that interfaces which they need

#region After

public interface IPrinterTasks
{
    void Print(string PrintContent);
    void Scan(string ScanContent);
}
interface IFaxTasks
{
    void Fax(string content);
}
interface IPrintDuplexTasks
{
    void PrintDuplex(string content);
}

public class HPLaserJetPrinter : IPrinterTasks, IFaxTasks,
                                     IPrintDuplexTasks
{
    public void Print(string PrintContent)
    {
        Console.WriteLine("Print Done");
    }
    public void Scan(string ScanContent)
    {
        Console.WriteLine("Scan content");
    }
    public void Fax(string FaxContent)
    {
        Console.WriteLine("Fax content");
    }
    public void PrintDuplex(string PrintDuplexContent)
    {
        Console.WriteLine("Print Duplex content");
    }
}

class LiquidInkjetPrinter : IPrinterTasks
{
    public void Print(string PrintContent)
    {
        Console.WriteLine("Print Done");
    }
    public void Scan(string ScanContent)
    {
        Console.WriteLine("Scan content");
    }
}

#endregion