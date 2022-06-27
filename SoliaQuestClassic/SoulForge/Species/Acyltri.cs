using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SoliaQuestClassic.SoulForge;
using SoliaQuestClassic.SoulForge.Types;

namespace SoliaQuestClassic.SoulForge.Species
{
    public class Acyltri : SQSpecies
    {
        public Acyltri()
        {
            //Set creature ref and name
            ModifySpeciesReference("Acyltri", "acyltri");

            //Set creature type
            SetSpeciesType("stone");

            //Set base stats
            statHealth  = 39.0;
            //statHealth  = 3900000000.0;
            statDefense = 6.0;
            statAttack  =  0.8;
            statStamina = 36.0;
            statEvade   =  0.8;
            statControl =  0.5;

            //add initially known abilities:
            AddInitialAbility("useItem");
            AddInitialAbility("waterbolt");

            //Setup which stat / color mods options to use



        }

        public override void Event_LevelUp(SQCreature sender)
        {
            switch (sender.Level)
            {
                case 3:
                    //sender.TeachAbility(new Abilities.Mirror());
                    break;
                case 5:
                    
                    break;
                case 10:
                    
                    break;
                default:

                    break;
            }

            base.Event_LevelUp(sender);
        }

        public static int RegisterSpecies()
        {
            SQWorld.Register(new Acyltri());
            return 1;
        }


        public override SQCreature NewCreatureOf()
        {
            return new SQCreature(new Acyltri());
        }
    }
}
