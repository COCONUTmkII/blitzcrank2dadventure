using System.Collections.Generic;

#region using Blitzcrank
using Blitzcrank.Character.Stats;
#endregion

namespace Blitzcrank.Character.Skill
{
    public interface ISecondSkillBehavior
    {
        int Level { get; set; }
        (int time, List<StatsModifier> mod) UseSecondSkill();
    }
}