namespace Blitzcrank.Character.Skill
{
    public interface IUltimateSkillBehavior
    {
        float Cooldown
        {
            get;
            set;
        }
        
        void UseUltimateSkill();
    }
}