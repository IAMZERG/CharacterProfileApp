using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CharacterProfileApp.Models;

namespace CharacterProfileApp.Data
{
    public class CharacterProfileRepository
    {
        public CharacterProfile GetCharacterProfile()
        {
            var characterProfile = new CharacterProfile()
            {
                Id = 0,
                Name = "Bob",
                Stats = new List<Models.Stat>
                {
                    new Stat { Id = 0, StatName = "Strength", Value = 5, Description = "Bob is reasonably strong." },
                    new Stat { Id = 1, StatName = "Agility", Value = 2, Description = "Bob has two left feet.  Literally." },
                    new Stat { Id = 1, StatName = "Intelligence", Value = 5, Description = "Bob is reasonably intelligent." }
                },
                Aliases = new List<Models.Alias>
                {
                    new Alias { Id = 0, AliasName = "Bob the Builder", Description = "Bob is the stereotypical construction worker." },
                    new Alias { Id = 1, AliasName = "Bob the Eater", Description = "Bob has legendary eating and drinking ability." },
                    new Alias { Id = 2, AliasName = "Town Council Treasurer", Description = "Bob uses his skills with money to volunteer as the Town Council Treasurer." }
                },

                Posessions = new List<Models.Posession>
                {
                    new Posession { Id = 0, Name = "Television", Description = "60 inch 1080P with a surround sound system.  Not top of the line, but pretty impressive." },
                    new Posession { Id = 1, Name = "Mobile Home", Description = "This old mobile home is in pretty good shape.  It appears well-maintained.  The television seems to always be on." }
                },
                Description = "Bob is a truly nice guy.  He has cholesterol issues, drinks too much on occasion, and has been divorced twice.  Currently, he is unmarried and intends to stay that" +
                " way.  Bob, when he is not working, spends time volunteering in his community, watching TV, and hanging out with friends."


            };
            return characterProfile;
        }
    }
}