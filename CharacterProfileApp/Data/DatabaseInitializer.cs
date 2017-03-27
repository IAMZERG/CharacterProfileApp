using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using CharacterProfileApp.Models;

namespace CharacterProfileApp.Data
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            //create each individual profile before initializing a CharacterProfile list and adding each of them to it.

            CharacterProfile mike = new CharacterProfile()
            {
                Id = 0,
                Name = "Mike",
                Description = "Mike is a nice guy.  Currently, he is unmarried and intends to stay that" +
                " way.  Mike, when he is not working, spends time volunteering in his community, watching TV, and hanging out with friends."


            };

            CharacterProfile bob = new CharacterProfile()
            {
                Id = 1,
                Name = "Bob",
                Description = "Bob is a nice guy.  He has cholesterol issues, drinks too much on occasion, and has been divorced twice.  Currently, he is unmarried and intends to stay that" +
                " way.  Bob, when he is not working, spends time playing baseball, watching TV, and helping out with his children and their families."


            };
            CharacterProfile andrew = new CharacterProfile()
            {
                Id = 2,
                Name = "Andrew",
                Description = "Andrew is a businessman, or at least he was.  Now he takes it easy working at the local grocery store and standing in as Town Council President."
            };

            //create character profile list
            List<CharacterProfile> characterProfiles = new List<CharacterProfile>()
            { bob, mike, andrew };


            List<Stat> mikeStats = new List<Models.Stat>
                {
                    new Stat { Id = 0, StatName = "Strength", Value = 5, Description = "Mike is reasonably strong." },
                    new Stat { Id = 1, StatName = "Agility", Value = 2, Description = "Mike has two left feet.  Literally." },
                    new Stat { Id = 1, StatName = "Intelligence", Value = 5, Description = "Mike is reasonably intelligent." }
                };
            List<Alias> mikeAliases = new List<Models.Alias>
                {
                    new Alias { Id = 0, AliasName = "Mike the Builder", Description = "Mike is the stereotypical construction worker." },
                    new Alias { Id = 1, AliasName = "Mike the Eater", Description = "Mike has legendary eating and drinking ability." },
                    new Alias { Id = 2, AliasName = "Mike the Store Owner", Description = "Mike owns the local grocery." }
                };

            List<Posession> mikePosessions = new List<Models.Posession>
                {
                    new Posession { Id = 0, Name = "Television", Description = "60 inch 1080P with a surround sound system.  Not top of the line, but pretty impressive." },
                    new Posession { Id = 1, Name = "Mobile Home", Description = "This old mobile home is in pretty good shape.  It appears well-maintained.  The television seems to always be on." },
                    new Posession { Id = 2, Name = "Mike's Grocery Store", Description = "Mike owns the well-built grocery store." }
                };
            List<Stat> bobStats = new List<Models.Stat>
                    {
                        new Stat { Id = 0, StatName = "Strength", Value = 5, Description = "Bob is reasonably strong." },
                        new Stat { Id = 1, StatName = "Agility", Value = 2, Description = "Bob has two left feet.  Literally." },
                        new Stat { Id = 1, StatName = "Intelligence", Value = 5, Description = "Bob is reasonably intelligent." }
                    };
            List<Alias> bobAliases = new List<Models.Alias>
                    {
                        new Alias { Id = 0, AliasName = "Bob the Builder", Description = "Bob is the stereotypical construction worker." },
                        new Alias { Id = 1, AliasName = "International Hot Dog Eating Contest Competitor", Description = "Bob has legendary eating and drinking abilities." },
                        new Alias { Id = 2, AliasName = "Town Council Treasurer", Description = "Bob uses his skills with money to volunteer as the Town Council Treasurer." }
                    };

            List<Posession> bobPosessions = new List<Models.Posession>
                    {
                        new Posession { Id = 0, Name = "Television", Description = "60 inch 1080P with a surround sound system.  Not top of the line, but pretty impressive." },
                        new Posession { Id = 1, Name = "Mobile Home", Description = "This old mobile home is in pretty good shape.  It appears well-maintained.  The television seems to always be on." }
                    };
            List<Stat> andrewStats = new List<Models.Stat>
                    {
                        new Stat { Id = 0, StatName = "Strength", Value = 5, Description = "Andrew is reasonably strong." },
                        new Stat { Id = 1, StatName = "Agility", Value = 2, Description = "Andrew has two left feet.  Literally." },
                        new Stat { Id = 1, StatName = "Intelligence", Value = 5, Description = "Andrew is reasonably intelligent." }
                    };
            List<Alias> andrewAliases = new List<Models.Alias>
                    {
                        new Alias { Id = 0, AliasName = "Town Council President", Description = "Andrew is the Town Council President." },
                        new Alias { Id = 1, AliasName = "Employee of the Month", Description = "Andrew works at his local grocer in his spare time, and was recently awarded employee of the month." }
                    };

            List<Posession> andrewPosessions = new List<Models.Posession>
                    {
                        new Posession { Id = 0, Name = "Television", Description = "72 inch 1080P with a surround sound system.  Not top of the line, but pretty impressive." },
                        new Posession { Id = 1, Name = "Mansion", Description = "Home of the Town Council President.  A pretty good party destination to boot." },
                        new Posession { Id = 2, Name = "Executive Ink Pen", Description = "Useful for signing important documents while others watch.  Now you can sign executive orders and hold them up for everyone to see too!" }
                    };

            //add posessions, aliases, and stats to each character profile.  There has to be a cleaner way to pull this off....
            //Overload the constructor of CharacterProfile to instantiate Stats, Aliases, and Posessions?  Meh... This is fine I suppose.
            mike.AddAliases(mikeAliases);
            mike.AddStats(mikeStats);
            mike.AddPosessions(mikePosessions);


            bob.AddAliases(bobAliases);
            bob.AddStats(bobStats);
            bob.AddPosessions(bobPosessions);


            andrew.AddAliases(andrewAliases);
            andrew.AddStats(andrewStats);
            andrew.AddPosessions(andrewPosessions);

            context.SaveChanges();
        }
    }
}