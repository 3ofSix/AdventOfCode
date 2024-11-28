
namespace AOC2016.Day10;

public class Bot : IReceiver
{
    public int Number { get; init; }
    public List<int> Chips = new ('2');
    private Dictionary<string, IReceiver> _instructions = new ();
    
    public void Receive(int chipValue)
    {
        Chips.Add(chipValue);
        Chips.Sort();
        if (Chips.Count == 2) DoWork();
    }

    public void Instruction(string instruction, IReceiver receiver)
    {
        _instructions.TryAdd(instruction, receiver);
    }

    private void DoWork()
    {
        foreach (KeyValuePair<string,IReceiver> instruction in _instructions)
        {
            switch (instruction.Key)
            {
                case "low":
                    instruction.Value.Receive(Chips.First());
                    break;
                case "high":
                    instruction.Value.Receive(Chips.Last());
                    break;
                default:
                    throw new Exception($"Unknown instruction: {instruction.Key}");
            }
        }
    }

}