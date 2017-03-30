using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CharacterProfileApp.Models;
using System.Diagnostics;

namespace CharacterProfileApp.Data
{
    public static class CharacterProfileRepository
    {

        /*
        /********************************************
         * Leaving in as  a reference/for posterity *
         * ******************************************

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
                    new Alias { Id = 1, AliasName = "Employee of the Month", Description = "Andrew works at his local grocer in his spare time, and was recently awarded employee of the month." }
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
        */

        



        //mostly for sanity...  doin' this in every using statement does things to a person
        public static Context GetContext()
        {
            var context = new Context();
            context.Database.Log = (message) => Debug.WriteLine(message);
            return context;
        }


        public static IList<CharacterProfile> GetCharacterProfiles()
        {
            using (Context context = GetContext())
            {
                return context.CharacterProfiles
                    .Include(cp => cp.Stats)
                    .Include(cp => cp.Posessions)
                    .Include(cp => cp.Aliases).ToList();
            }
        }
        public static CharacterProfile GetCharacterProfile(int id)
        {

            using (Context context = GetContext())
            {
                return context.CharacterProfiles.Find(id);

            }
        }

        public static string AddCharacterProfile(CharacterProfile charP)
        {
            using (Context context = GetContext())
            {
                List<CharacterProfile> profiles = context.CharacterProfiles.ToList();

                //TODO: Add validations like this in a more maintainable fashion
                if (context.CharacterProfiles.Find(charP.Id).Name == charP.Name)
                {
                    return "Failed to add character profile.  Character with that name already exists.";
                }
                else
                {
                    context.CharacterProfiles.Add(charP);
                    return "Successfully added character profile.";
                }
            }
        }
        public static string UpdateCharacterProfile(CharacterProfile profile)
        {
            using (Context context = GetContext())
            {
                CharacterProfile target = context.CharacterProfiles.Find(profile.Id);
                target.Name = profile.Name;
                target.Description = profile.Description;

                //TODO: add checks for changes on Stats, Posessions, and Aliases.  Make updates accordingly.
                context.SaveChanges();
                //TODO: add exception handling, clean this up
                return "Profile successfully updated";
            }
        }

        public static string DeleteCharacterProfile(CharacterProfile profile)
        {
            using (Context context = GetContext())
            {
                context.Entry(profile).State = EntityState.Deleted;
                context.SaveChanges();
                //TODO: add exception handling, clean this up.
                return string.Format("Profile successfully removed");
            }
        }
    }
}
