using System;
using System.Collections.Generic;

namespace EpicTale.Models
{
    public class Ability
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public AbilityType AbilityType { get; set; }

        private List<string> RandomFirstWords { get; set; }
        private List<string> RandomSecondWords { get; set; }

        public Ability()
        {
            FillRandomWordsLists();
            RandomizeAbilityNames();
            RandomizeAbilityDescriptions();
            RandomizeAbilityTypes();
        }

        private void FillRandomWordsLists()
        {
            RandomFirstWords = new List<string>(){ "Howling", "Focused", "Falling", "Rampaging", "Dazzling" };
            RandomSecondWords = new List<string>(){ "Thrust", "Thunder", "Burst", "Blow", "Strike" };
        }

        private void RandomizeAbilityNames()
        {
            Random r = new Random();
            
            for(int i =0; i<RandomFirstWords.Count; i++){
                this.Name = $"{RandomFirstWords[r.Next(5)]} {RandomSecondWords[r.Next(5)]}";
            }
        }

        private void RandomizeAbilityDescriptions()
        {
            string[] randomizedAbilityName = this.Name.Split();

            this.Description = $"A {randomizedAbilityName[0]} {randomizedAbilityName[1]} to reign hell upon your opponent!}}";
        }

        private void RandomizeAbilityTypes()
        {
            //Not sure. Might randomize the ability types as well for variation
        }
    }
}