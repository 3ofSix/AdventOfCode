namespace AOC2016;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        List<MyClass> myClasses = new List<MyClass>
        {
            new MyClass { Number = 3 },
            new MyClass { Number = 4 },
            new MyClass { Number = 5 },
        };
        Console.WriteLine(myClasses.Find(c => c.Number == 6));
    }
}

class MyClass : IEquatable<MyClass>
{
    public int Number { get; set; }
    public bool Equals(MyClass? other)
    {
        if (other == null) return false;
        return (this.Number.Equals(other.Number));
    }

    // public override string ToString()
    // {
    //     return $"MyClass {Number}";
    // }
}
