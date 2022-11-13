

// In before example we made a wrong inheritence and when we call apple's GetColor Method we get oreange color and that is wrong behaviour

#region Before

//class Program
//{
//    static void Main(string[] args)
//    {
//        Apple apple = new Orange();
//        Console.WriteLine(apple.GetColor());
//    }
//}
//public class Apple
//{
//    public virtual string GetColor()
//    {
//        return "Red";
//    }
//}
//public class Orange : Apple
//{
//    public override string GetColor()
//    {
//        return "Orange";
//    }
//}

#endregion

// With Liskov Substitution Principle we create a basic Fruit class and inherit all fruit classes from it
// Now we can just call all of them like Fruit class reference and each of them will give a right result in GetColor method

#region After

class Program
{
    static void Main(string[] args)
    {
        Fruit fruit = new Orange();
        Console.WriteLine(fruit.GetColor());
        fruit = new Apple();
        Console.WriteLine(fruit.GetColor());
    }
}
public abstract class Fruit
{
    public abstract string GetColor();
}
public class Apple : Fruit
{
    public override string GetColor()
    {
        return "Green";
    }
}
public class Orange : Fruit
{
    public override string GetColor()
    {
        return "Orange";
    }
}

#endregion