using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Species
{
    public class Soqaruth : SQSpecies
    {
        public Soqaruth()
        {
            //Set creature ref and name
            ModifySpeciesReference("Soqaruth", "soqaruth");
            description = "Soqaruth is more plant than animal; They require little food but can digest almost anything.\n" +
                "Exceptionally high defense and attack stats but lower base health.";

            //Set creature type
            SetSpeciesType("plant");

            //Set base stats
            statHealth = 55.0;
            statDefense = 16.0;
            statAttack = 1.8;
            statStamina = 65.0;
            statEvade = 4.3;
            statControl = 0.5;

            //add initially known abilities:
            AddInitialAbility("useItem");
            AddInitialAbility("scratchbasic");
            AddInitialAbility("leafBlade");
            AddInitialAbility("thorns");


            //Setup which stat / color mods options to use

        }

        public override void Event_LevelUp(SQCreature sender)
        {
            switch (sender.Level)
            {
                case 2:
                    sender.ReplaceAbility("scratchbasic", new Abilities.ScratchII(UseSpeciesTypes));
                    sender.TeachAbility(new Abilities.Sunbathe("plant"));
                    break;
                case 3:
                    sender.TeachAbility(new Abilities.HydrateGrow());
                    break;
                case 5:
                    sender.TeachAbility(new Abilities.Thorns());
                    break;
                case 10:
                    //sender.ReplaceAbility("prismSlashI", new Abilities.PrismSlashII());
                    break;
                default:

                    break;
            }

            base.Event_LevelUp(sender);
        }






        //boring stuff
        public static int RegisterSpecies()
        {
            SQWorld.Register(new Soqaruth());
            return 1;
        }


        public override SQCreature NewCreatureOf()
        {
            return new SQCreature(new Soqaruth());
        }
    }
}
