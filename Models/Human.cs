namespace EpicTale.Models
{
    public class Human : Race
    {
        public Human()
        {
            this.Name = "Human";

            SetBaseStats();
        }
        public override void SetBaseStats()
        {
            this.BaseHP = 10;
            this.BaseMP = 10;
        }
    }
}