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
            statDefense = 14.0;
            statAttack  =  0.8;
            statStamina = 36.0;
            statEvade   =  0.8;
            statControl =  0.5;

            //Setup which stat / color mods options to use



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
