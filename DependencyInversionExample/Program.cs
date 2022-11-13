
#nullable disable

// In Dependency Inversion principle we say that high level modules(that are controlling the other modules and doing main work)
// should not depend on low level modules(for exapmle services dataaccessing and etc.)
// They both should depend on abstraction so if we change low level module we don't touch high level module
// In before example our main module EmployeeBusinessLogic depends on EmployeeDataAccess and that is wrong fo our principle

#region Before

//public class Employee
//{
//    public int ID { get; set; }
//    public string Name { get; set; }
//    public string Department { get; set; }
//    public int Salary { get; set; }
//}

//public class EmployeeBusinessLogic
//{
//    EmployeeDataAccess _EmployeeDataAccess;
//    public EmployeeBusinessLogic()
//    {
//        _EmployeeDataAccess = DataAccessFactory.GetEmployeeDataAccessObj();
//    }
//    public Employee GetEmployeeDetails(int id)
//    {
//        return _EmployeeDataAccess.GetEmployeeDetails(id);
//    }
//}

//public class DataAccessFactory
//{
//    public static EmployeeDataAccess GetEmployeeDataAccessObj()
//    {
//        return new EmployeeDataAccess();
//    }
//}

//public class EmployeeDataAccess
//{
//    public Employee GetEmployeeDetails(int id)
//    {
//        // In real time get the employee details from db
//        //but here we are hard coded the employee details
//        Employee emp = new Employee()
//        {
//            ID = id,
//            Name = "Pranaya",
//            Department = "IT",
//            Salary = 10000
//        };
//        return emp;
//    }
//}

#endregion

// With Dependency Inversion principle we create an IEmployeeDataAccess interface and now our EmployeeBusinessLogic class depends on this abstraction

#region After

public class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public int Salary { get; set; }
}

public interface IEmployeeDataAccess
{
    Employee GetEmployeeDetails(int id);
}

public class EmployeeDataAccess : IEmployeeDataAccess
{
    public Employee GetEmployeeDetails(int id)
    {
        // In real time get the employee details from db
        //but here we are hardcoded the employee details
        Employee emp = new Employee()
        {
            ID = id,
            Name = "Pranaya",
            Department = "IT",
            Salary = 10000
        };
        return emp;
    }
}

public class DataAccessFactory
{
    public static IEmployeeDataAccess GetEmployeeDataAccessObj()
    {
        return new EmployeeDataAccess();
    }
}

public class EmployeeBusinessLogic
{
    IEmployeeDataAccess _EmployeeDataAccess;
    public EmployeeBusinessLogic()
    {
        _EmployeeDataAccess = DataAccessFactory.GetEmployeeDataAccessObj();
    }
    public Employee GetEmployeeDetails(int id)
    {
        return _EmployeeDataAccess.GetEmployeeDetails(id);
    }
}

#endregion