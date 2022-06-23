using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Species
{
    public class TrainingDummy : SQSpecies
    {
        public TrainingDummy()
        {
            //Set creature ref and name
            ModifySpeciesReference("Training Dummy", "dummy1");

            //Set creature type
            SetSpeciesType("typeless");

            //Set base stats
            statHealth = 999999.0;
            statDefense = 25.0;
            statAttack = 0.0;
            statStamina = 1.0;
            statEvade = 0.0;
            statControl = 0.5;

            //add initially known abilities:
            AddInitialAbility("blankStare");

            //Setup which stat / color mods options to use



        }

        public static int RegisterSpecies()
        {
            SQWorld.Register(new TrainingDummy());
            return 1;
        }


        public override SQCreature NewCreatureOf()
        {
            return new SQCreature(new TrainingDummy());
        }
    }
}
