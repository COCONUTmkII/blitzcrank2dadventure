namespace Character.Skill
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