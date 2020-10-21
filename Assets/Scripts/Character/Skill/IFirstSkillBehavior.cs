namespace Character.Skill
{
    public interface IFirstSkillBehavior
    {
        float Cooldown
        {
            get;
            set;
        }
        
        void UseFirstSkill();
    }
}