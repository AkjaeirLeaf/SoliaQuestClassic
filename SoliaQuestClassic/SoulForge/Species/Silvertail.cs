using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SoliaQuestClassic.SoulForge;
using SoliaQuestClassic.SoulForge.Types;

namespace SoliaQuestClassic.SoulForge.Species
{
    public class Silvertail : SQSpecies
    {
        public Silvertail()
        {
            //Set creature ref and name
            ModifySpeciesReference("Silvertail Cat", "silvertail");
            description = "A sleek, silvery feline seen on rare occasions in the deepest and darkest of forests.";

            //Set creature type
            SetSpeciesType("crystal");
            SetSpeciesType("light");

            //Set base stats
            statHealth =  120.0;
            statDefense =   7.0;
            statAttack  =   2.8;
            statStamina =  85.0;
            statEvade   =   2.3;
            statControl =   0.5;

            //add initially known abilities:
            AddInitialAbility("useItem");
            AddInitialAbility("crystalTalon");
            AddInitialAbility("prismSlashI");


            //Setup which stat / color mods options to use


            //Load Images
            LoadSpeciesImages();
        }

        public override void Event_LevelUp(SQCreature sender)
        {
            switch (sender.Level)
            {
                case 3:
                    sender.TeachAbility(new Abilities.Mirror());
                    break;
                case 5:
                    sender.TeachAbility(new Abilities.Opalium());
                    break;
                case 10:
                    sender.ReplaceAbility("prismSlashI", new Abilities.PrismSlashII());
                    break;
                default:

                    break;
            }

            base.Event_LevelUp(sender);
        }

        //RENDER
        public override void LoadSpeciesImages()
        {
            AddSpeciesImage("frame", "young", "p0",    "default");
            AddSpeciesImage("frame", "young", "p0",  "leucistic");
            AddSpeciesImage("frame", "young", "p0",   "negative");
            AddSpeciesImage("frame", "young", "p0",  "prismatic");

        }


        //boring stuff
        public static int RegisterSpecies()
        {
            SQWorld.Register(new Silvertail());
            return 1;
        }


        public override SQCreature NewCreatureOf()
        {
            return new SQCreature(new Silvertail());
        }
    }
}
