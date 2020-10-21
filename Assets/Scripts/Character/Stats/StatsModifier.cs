namespace Character.Stats
{
    public enum Stat : int
    {
        Strength,
        Energy,
        Agility,
    }
    public enum StatsModType : int
    {
        Flat,
        Percent,
    }
    public class StatsModifier
    {
        public readonly Stat Stat;
        public readonly int Value;
        public readonly StatsModType Type;

        public StatsModifier(Stat stat, int value, StatsModType type)
        {
            Stat = stat;
            Value = value;
            Type = type;
        }
    }
}