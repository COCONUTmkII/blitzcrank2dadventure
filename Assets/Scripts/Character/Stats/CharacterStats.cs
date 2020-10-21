using System.Collections.Generic;

namespace Character.Stats
{
    public class CharacterStats : BaseStats
    {
        //TODO: Omg... I'll leave it like this for a while
        public void AddStats(List<StatsModifier> mod)
        {
            foreach (StatsModifier statsModifier in mod)
            {
                if(statsModifier.Stat == Stat.Agility)
                {
                    Agility += statsModifier.Value;
                }
                if(statsModifier.Stat == Stat.Strength)
                {
                    Strength += statsModifier.Value;
                }
            }
        }

        public void RemoveStats(List<StatsModifier> mod)
        {
            foreach (StatsModifier statsModifier in mod)
            {
                if (statsModifier.Stat == Stat.Agility)
                {
                    Agility -= statsModifier.Value;
                }
                if (statsModifier.Stat == Stat.Strength)
                {
                    Strength -= statsModifier.Value;
                }
            }
        }
    }
}