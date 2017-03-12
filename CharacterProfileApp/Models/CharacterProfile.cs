using System;
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


    }
}