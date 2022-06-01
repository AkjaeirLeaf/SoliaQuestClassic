using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Species
{
    public class AvieaDer : SQSpecies
    {
        public AvieaDer()
        {
            //Set creature ref and name
            ModifySpeciesReference("Aviean Bear", "avieader");
            description = "A stocky bipedal bearlike species known for their tough and hardened spirit.";

            //Set creature type
            SetSpeciesType("water");
            SetSpeciesType("stone");
            SetSpeciesType("metal");

            //Set base stats
            statHealth = 120.0;
            statDefense = 29.0;
            statAttack = 2.5;
            statStamina = 98.0;
            statEvade = 1.1;
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
            SQWorld.Register(new AvieaDer());
            return 1;
        }


        public override SQCreature NewCreatureOf()
        {
            return new SQCreature(new AvieaDer());
        }
    }
}
