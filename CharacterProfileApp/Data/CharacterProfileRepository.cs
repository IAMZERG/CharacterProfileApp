using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CharacterProfileApp.Models;

namespace CharacterProfileApp.Data
{
    public class CharacterProfileRepository
    {
        private static List<CharacterProfile> _characterProfiles = new List<CharacterProfile>
        {

            new CharacterProfile()
            {
                Id = 0,
                Name = "Mike",
                Stats = new List<Models.Stat>
                {
                    new Stat { Id = 0, StatName = "Strength", Value = 5, Description = "Mike is reasonably strong." },
                    new Stat { Id = 1, StatName = "Agility", Value = 2, Description = "Mike has two left feet.  Literally." },
                    new Stat { Id = 1, StatName = "Intelligence", Value = 5, Description = "Mike is reasonably intelligent." }
                },
                Aliases = new List<Models.Alias>
                {
                    new Alias { Id = 0, AliasName = "Mike the Builder", Description = "Mike is the stereotypical construction worker." },
                    new Alias { Id = 1, AliasName = "Mike the Eater", Description = "Mike has legendary eating and drinking ability." },
                    new Alias { Id = 2, AliasName = "Mike the Store Owner", Description = "Mike owns the local grocery." }
                },

                Posessions = new List<Models.Posession>
                {
                    new Posession { Id = 0, Name = "Television", Description = "60 inch 1080P with a surround sound system.  Not top of the line, but pretty impressive." },
                    new Posession { Id = 1, Name = "Mobile Home", Description = "This old mobile home is in pretty good shape.  It appears well-maintained.  The television seems to always be on." },
                    new Posession { Id = 2, Name = "Mike's Grocery Store", Description = "Mike owns the well-built grocery store." }
                },
                Description = "Mike is a nice guy.  Currently, he is unmarried and intends to stay that" +
                " way.  Mike, when he is not working, spends time volunteering in his community, watching TV, and hanging out with friends."


            },
            new CharacterProfile()
            {
                Id = 1,
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
                Description = "Bob is a nice guy.  He has cholesterol issues, drinks too much on occasion, and has been divorced twice.  Currently, he is unmarried and intends to stay that" +
                " way.  Bob, when he is not working, spends time playing baseball, watching TV, and helping out with his children and their families."


            },
            new CharacterProfile()
            {
                Id = 2,
                Name = "Andrew",
                Stats = new List<Models.Stat>
                {
                    new Stat { Id = 0, StatName = "Strength", Value = 5, Description = "Andrew is reasonably strong." },
                    new Stat { Id = 1, StatName = "Agility", Value = 2, Description = "Andrew has two left feet.  Literally." },
                    new Stat { Id = 1, StatName = "Intelligence", Value = 5, Description = "Andrew is reasonably intelligent." }
                },
                Aliases = new List<Models.Alias>
                {
                    new Alias { Id = 0, AliasName = "Town Council President", Description = "Andrew is the Town Council President." },
                    new Alias { Id = 1, AliasName = "Employee of the Month", Description = "Andrew works at his local grocer in his spare time, and was recently awarded employee of the month." },
                    new Alias { Id = 2, AliasName = "Town Council Treasurer", Description = "Bob uses his skills with money to volunteer as the Town Council Treasurer." }
                },

                Posessions = new List<Models.Posession>
                {
                    new Posession { Id = 0, Name = "Television", Description = "72 inch 1080P with a surround sound system.  Not top of the line, but pretty impressive." },
                    new Posession { Id = 1, Name = "Mansion", Description = "Home of the Town Council President.  A pretty good party destination to boot." },
                    new Posession { Id = 2, Name = "Executive Ink Pen", Description = "Useful for signing important documents while others watch.  Now you can sign executive orders and hold them up for everyone to see too!" }
                },
                Description = "Andrew is a businessman, or at least he was.  Now he takes it easy working at the local grocery store and standing in as Town Council President."
            }
        };

        public List<CharacterProfile> GetCharacterProfiles()
        {
            return _characterProfiles;
        }

        public CharacterProfile GetCharacterProfile(int id)
        {

            if (id < _characterProfiles.Count)
            {
                return _characterProfiles.Find(cp => cp.Id == id);
            }
            else
            {
                return new CharacterProfile { Name = "The resource you are looking for is unavailable." };

            }
        }

        public string AddCharacterProfile(CharacterProfile charP)
        {

            if(_characterProfiles.FirstOrDefault(cp => cp.Name == charP.Name) != null)
            {
                return "Failed to add character profile.  Character with that name already exists.";
            }
            else
            {
                _characterProfiles.Add(charP);
                return "Successfully added character profile.";
            }
        }
        public string UpdateCharacterProfile(CharacterProfile profile)
        {
            CharacterProfile target = _characterProfiles.Find(cp => profile.Id == cp.Id);
            target.Name = profile.Name;
            target.Description = profile.Description;
            //TODO: add exception handling, clean this up.
            //TODO: overload Equals on CharacterProfile model so all changes to the model will not need to be reflected here also.
            return "Profile successfully updated";
        }

        public string DeleteCharacterProfile(CharacterProfile profile)
        {
            CharacterProfile target = _characterProfiles.Find(cp => profile.Id == cp.Id);
            string name = target.Name;
            _characterProfiles.Remove(target);
            //TODO: add exception handling, clean this up.
            return string.Format("{0}'s profile successfully removed", name);
        }
    }
}