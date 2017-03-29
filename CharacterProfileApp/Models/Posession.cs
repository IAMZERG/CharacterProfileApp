using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharacterProfileApp.Models
{
    public class Posession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CharacterProfileId { get; set; }
        public CharacterProfile CharacterProfile { get; set; }
    }
}