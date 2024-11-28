namespace AOC2016.Day10;

public class OutputBin : IReceiver
{
    public int Number { get; init; }
    public int Chip { get; private set; }

    public void Receive(int chipValue)
    {
        Chip = chipValue;
    }
}