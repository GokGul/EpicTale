namespace EpicTale.Models
{
    public class AbilityType
    {
        public string Name { get; set; }

        public AbilityType(string name)
        {
            this.Name = name;
            //defense or offensive?
            //type of damage, if offensive?
        }
    }
}