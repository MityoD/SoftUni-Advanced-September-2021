using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public List<Player> roster;

        public Guild(string name, int capacity)
        {
            roster = new List<Player>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
       
        public int Capacity { get; set; }
        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            return roster.Remove(roster.Where(x => x.Name == name).FirstOrDefault());
        }
        public void PromotePlayer(string name)
        {
            Player currentPlayer = roster.Where(x => x.Name == name).FirstOrDefault();
            currentPlayer.Rank = "Member";            
        }
        public void DemotePlayer(string name)
        {
            Player currentPlayer = roster.Where(x => x.Name == name).FirstOrDefault();
            currentPlayer.Rank = "Trial";
        }
        public Player[] KickPlayersByClass(string @class)
        {
            Player[] elements = roster.Where(x => x.Class == @class).ToArray();
            foreach (var item in elements)
            {
            roster.Remove(item);
            }
            return elements;
        }
        public int Count => roster.Count;

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Players in the guild: {Name}");
            foreach (var item in roster)
            {
                report.AppendLine(item.ToString());
            }
            return report.ToString().TrimEnd();
        }
    }
}
