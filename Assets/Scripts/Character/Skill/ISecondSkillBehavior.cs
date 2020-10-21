using System.Collections.Generic;
using Character.Stats;

namespace Character.Skill
{
    public interface ISecondSkillBehavior
    {
        int Level { get; set; }
        (int time, List<StatsModifier> mod) UseSecondSkill();
    }
}