using System.Collections.Generic;

namespace EpicTale.Models
{
    public abstract class Being
    {
        private Race _race;
        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int MaxMP { get; set; }
        public int CurrentMP { get; set; }
        public List<Ability> Abilities { get; set; }
        public Area CurrentArea { get; set; }
        public Race Race
        {
            get
            {
                return _race;
            }
            set
            {
                this._race = value;
                SetInitialStats();
            }
        }

        private void SetInitialStats()
        {
            this.Level = 1;
            this.MaxHP = Race.BaseHP;
            this.MaxMP = Race.BaseMP;

            this.CurrentHP = Race.BaseHP;
            this.CurrentMP = Race.BaseMP;
        }

        public void Go(string direction)
        {
            var areaInDirection = CurrentArea.GetNeighbor(direction);

            if(areaInDirection == null){
                System.Console.WriteLine($"{this.Name} doesn't see anything {direction}..");
            }else{
                CurrentArea = areaInDirection;
                System.Console.WriteLine($"Ye, ok. Im at {CurrentArea.Name}");
            }
        }

        public void AddAbility(Ability ability)
        {
            Abilities.Add(ability);
        }

        internal void SetCurrentArea(Area area)
        {
            this.CurrentArea = area;
        }
    }
}