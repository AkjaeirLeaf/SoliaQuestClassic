using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Species
{
    public class NoctaelQhota : SQSpecies
    {
        public NoctaelQhota()
        {
            //Set creature ref and name
            ModifySpeciesReference("Noctael Qhota", "noctaelQhota");
            description = "A tough, small catlike species from the planet Noctae.";

            //Set creature type
            SetSpeciesType("dark");
            SetSpeciesType("water");
            SetSpeciesType("metal");

            //Set base stats
            statHealth = 110.0;
            statDefense = 16.0;
            statAttack = 2.2;
            statStamina = 130.0;
            statEvade = 2.0;
            statControl = 0.5;

            //add initially known abilities:
            AddInitialAbility("useItem");
            AddInitialAbility("scratchbasic");


            //Setup which stat / color mods options to use



        }

        public override void Event_LevelUp(SQCreature sender)
        {
            base.Event_LevelUp(sender);
        }






        //boring stuff
        public static int RegisterSpecies()
        {
            SQWorld.Register(new NoctaelQhota());
            return 1;
        }


        public override SQCreature NewCreatureOf()
        {
            return new SQCreature(new NoctaelQhota());
        }
    }
}
