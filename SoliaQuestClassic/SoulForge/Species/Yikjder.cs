using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Species
{
    public class Yikjder : SQSpecies
    {
        public Yikjder()
        {
            //Set creature ref and name
            ModifySpeciesReference("Yikjder", "yikjder");
            description = "A bearlike creature native to the seas of Planet Izi.";

            //Set creature type
            SetSpeciesType("water");
            SetSpeciesType("dark");

            //Set base stats
            statHealth = 112.0;
            statDefense = 12.0;
            statAttack = 1.5;
            statStamina = 82.0;
            statEvade = 1.0;
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
            SQWorld.Register(new Yikjder());
            return 1;
        }


        public override SQCreature NewCreatureOf()
        {
            return new SQCreature(new Yikjder());
        }
    }
}
