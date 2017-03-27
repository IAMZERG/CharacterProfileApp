using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharacterProfileApp.Models
{
    public class CharacterProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Stat> Stats { get; set; }
        public List<Alias> Aliases { get; set; }
        public List<Posession> Posessions { get; set; }
        public string Description { get; set; }


        public CharacterProfile()
        {
            Stats = new List<Stat> { };
            Aliases = new List<Alias> { };
            Posessions = new List<Posession> { };
        }
        //TODO: overload Equals operator?
        public void AddStats(IList<Stat> stats)
        {
            Stats = (List<Stat>)stats;
        }

        public void AddAliases(IList<Alias> aliases)
        {
            Aliases = (List<Alias>)aliases;
        }
        public void AddPosessions(IList<Posession> posessions)
        {
            Posessions = (List<Posession>)posessions;
        }
    }


}