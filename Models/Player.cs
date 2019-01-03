using System;
using System.Collections.Generic;

namespace EpicTale.Models
{
    public class Player : Being
    {
        public int ExperiencePointsGained { get; set; }

        public Player(string name, Race race)
        {
            this.Name = name;
            this.Race = race;
        }
    }
}