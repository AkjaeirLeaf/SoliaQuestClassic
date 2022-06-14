using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Species
{
    public class Ufim : SQSpecies
    {
        public Ufim()
        {
            //Set creature ref and name
            ModifySpeciesReference("Ufim", "ufim");
            description = "A plump bird that is adapted to survive in the coldest, wettest environments.";

            //Set creature type
            SetSpeciesType("ice");
            SetSpeciesType("air");

            //Set base stats
            statHealth = 82.0;
            statDefense = 2.0;
            statAttack = 1.8;
            statStamina = 45.0;
            statEvade = 5.3;
            statControl = 0.5;

            //add initially known abilities:
            AddInitialAbility("useItem");


            //Setup which stat / color mods options to use

        }

        public override void Event_LevelUp(SQCreature sender)
        {
            switch (sender.Level)
            {
                
                default:

                    break;
            }

            base.Event_LevelUp(sender);
        }






        //boring stuff
        public static int RegisterSpecies()
        {
            SQWorld.Register(new Ufim());
            return 1;
        }


        public override SQCreature NewCreatureOf()
        {
            return new SQCreature(new Ufim());
        }
    }
}
