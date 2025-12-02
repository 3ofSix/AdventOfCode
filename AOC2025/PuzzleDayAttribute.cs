namespace AOC2025
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PuzzleDayAttribute : Attribute
    {
        public uint Day { get; }
        public PuzzleDayAttribute(uint day) => Day = day;
    }

}
