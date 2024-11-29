namespace AOC2016.Day10;

public enum ReceiverType
{
    Bot,
    Output
}
/// <summary>
/// Class <c>BotFactory</c> Makes and tracks bots in a factory.
/// Also tracks the Output from bots
/// </summary>
/// Create Bots, assign numbers to bots
// Store outputs of bots
public class BotFactory
{
    private Dictionary<int, IReceiver> Receivers = new ();  // Track bots in factory 
    private List<OutputBin> Outputs = new (); // Track outputs
    private List<Bot> Bots = new();

    public IReceiver GetReceiver(ReceiverType receiverType, int botId)
    {
        switch (receiverType)
        {
            case ReceiverType.Bot:
                if (!Bots.Exists(b => b.Number == botId))
                {
                    Bots.Add(new Bot
                    {
                        Number = botId,
                    });
                }
                return Bots.Find(b => b.Number == botId);
            
            case ReceiverType.Output:
                if (!Outputs.Exists(b => b.Number == botId))
                {
                    Outputs.Add(new OutputBin
                    {
                        Number = botId,
                    });
                }
                return Outputs.Find(b => b.Number == botId);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    /// <summary>
    /// This method returns a bot with the supplied <c>botid</c>
    /// </summary>
    /// <param name="botId"></param>
    /// <returns>A <c>Bot</c></returns>
    public IReceiver GetorAddBot(int botId)
    {
        Receivers.TryAdd(botId, new Bot
            {
                Number = botId
            });
        
        return Receivers[botId];
    }

    public void LoadInstructions(string[] instructions)
    {
        // Process each line of instruction
        foreach (string instruction in instructions)
        {
            Bot worker;
            IReceiver low;
            IReceiver high;
            // Split the line by space
            // Check first noun for 'value' or 'bot'
            string[] splitInstruction = instruction.Split(" ");
            if (splitInstruction[0] == "Bot")
            {
                worker = (Bot)GetReceiver(ReceiverType.Bot, 
                    Int32.Parse(splitInstruction[1]));
                // Check if there are instructions
                if (splitInstruction.Length > 6)
                {
                    // low instruction
                    low = GetorAddBot(Int32.Parse(splitInstruction[6]));
                    worker.Instruction("low", low);
                    // high instruction
                    high = GetorAddBot(Int32.Parse(splitInstruction[11]));
                    worker.Instruction("high", high);
                }
            }

            if (splitInstruction[0] == "value")
            {
                // Get the bot and give it the chip
                IReceiver bot = GetorAddBot(Int32.Parse(splitInstruction[splitInstruction.Length - 1]));
                bot.Receive(Int32.Parse(splitInstruction[1]));
            }
            
        }
    }
}