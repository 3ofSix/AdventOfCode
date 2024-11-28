namespace AOC2016.Day10;

/// <summary>
/// Class <c>BotFactory</c> Makes and tracks bots in a factory.
/// Also tracks the Output from bots
/// </summary>
/// Create Bots, assign numbers to bots
// Store outputs of bots
public class BotFactory
{
    private Dictionary<int, IReceiver> Receivers = new ();  // Track bots in factory 
    private Dictionary<int, int> Outsputs = new Dictionary<int, int>(); // Track outputs
    
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
                worker = (Bot)GetorAddBot(Int32.Parse(splitInstruction[1]));
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