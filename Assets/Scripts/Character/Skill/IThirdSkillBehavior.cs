namespace Character.Skill
{
    public interface IThirdSkillBehavior
    {
        float Cooldown
        {
            get;
            set;
        }
        
        void UseThirdSkill();
    }
}