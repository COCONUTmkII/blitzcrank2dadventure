namespace Blitzcrank.Character.Skill
{
    public interface IPassiveSkillBehavior
    {
        float Cooldown
        {
            get;
            set;
        }
        
        void UsePassiveSkill();
    }
}