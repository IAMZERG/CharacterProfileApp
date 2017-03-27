using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharacterProfileApp.Models
{
    public class Stat
    {
        public int Id { get; set; }
        public string StatName { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public int CharacterProfileId { get; set; }
    }
}