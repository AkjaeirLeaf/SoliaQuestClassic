using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Species
{
    public class DaecaserDer : SQSpecies
    {
        public DaecaserDer()
        {
            //Set creature ref and name
            ModifySpeciesReference("Daecaser Bear", "daecaserDer");
            description = "A stout little bear race originating from the first moon of Aviea.";

            //Set creature type
            SetSpeciesType("air");
            SetSpeciesType("stone");

            //Set base stats
            statHealth = 102.0;
            statDefense = 12.0;
            statAttack = 2.1;
            statStamina = 95.0;
            statEvade = 2.9;
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
            SQWorld.Register(new DaecaserDer());
            return 1;
        }


        public override SQCreature NewCreatureOf()
        {
            return new SQCreature(new DaecaserDer());
        }
    }
}
