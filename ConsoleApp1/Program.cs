enum VehicalType
{
    FourWheeler,
    TwoWheeler
}
enum SloatType
{
    Medium,
    Large
}

public Vehicle
{
    public string number {get;private set;}
    public vehicalType type {get; private set;}
    public vehicle(string number,VehicalType vehicalType){
    this.number = number;
    this.type = vehicalType;
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
    }
}
