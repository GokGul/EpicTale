using System.Collections.Generic;

namespace EpicTale.Models
{
    public class Area
    {
        public string Name { get; set; }
        public Dictionary<string, Area> Neighbors { get; set; }
        public bool IsDestroyed { get; set; }

        public Area(string name)
        {
            this.Name = name;
            Neighbors = new Dictionary<string, Area>();
            IsDestroyed = false;
        }

        public Area GetNeighbor(string direction){
            if(!Neighbors.ContainsKey(direction)){
                
            }
            return Neighbors[direction];
        }

        public void SetNeighbor(string direction, Area area){
            Neighbors.Add(direction, area);
        }
    }
}