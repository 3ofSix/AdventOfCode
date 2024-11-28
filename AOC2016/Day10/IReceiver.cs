namespace AOC2016.Day10;

public interface IReceiver
{
    int Number { get; init; }
    void Receive(int chipValue);
}