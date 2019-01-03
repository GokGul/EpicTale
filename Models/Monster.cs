namespace EpicTale.Models
{
    public class Monster : Being
    {
        public int AmountExperiencePoints { get; set; }

        public Monster(string name, int level, int hp, int mp, int xpPoints)
        {
            this.Name = name;
            this.Level = level;
            this.MaxHP = hp;
            this.MaxMP = mp;
            this.AmountExperiencePoints = xpPoints;

            this.CurrentHP = hp;
            this.CurrentMP = mp;
        }
    }
}