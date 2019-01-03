namespace EpicTale.Models
{
    public abstract class Race
    {
        public string Name { get; set; }
        public int BaseHP { get; set; }
        public int BaseMP { get; set; }
        public bool HasAwakening { get; set; }
        public bool IsAwakened { get; set; }
        public string AwakeningName { get; set; }
        public int ExperiencePointsGained { get; set; }

        public Race()
        {
            this.IsAwakened = false;
        }

        public abstract void SetBaseStats();
    }
}