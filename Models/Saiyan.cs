namespace EpicTale.Models
{
    public class Saiyan : Race
    {
        public Saiyan()
        {
            this.Name = "Saiyan";
            this.HasAwakening = true;
            this.AwakeningName = "Super Saiyan";

            SetBaseStats();
        }

        public override void SetBaseStats()
        {
            this.BaseHP = 15;
            this.BaseMP = 5;
        }
    }
}