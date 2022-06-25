using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Species
{
    public class EaltaeQhota : SQSpecies
    {
        public EaltaeQhota()
        {
            //Set creature ref and name
            ModifySpeciesReference("Ealtae River Cat", "ealtaeQhota");
            description = "A sleek, silvery-blue feline that lives in small communities near Ealtae\'s forest rivers and caves.\n" +
                "Exceptionally high evasive stat but lower defense and resistance.\n" +
                "Possibly a descendent or relative of the elusive Silvertail Cat.";

            //Set creature type
            SetSpeciesType("water");
            SetSpeciesType("spirit");

            //Set base stats
            statHealth = 92.0;
            statDefense = 7.0;
            statAttack = 2.1;
            statStamina = 72.0;
            statEvade = 5.3;
            statControl = 0.5;

            //add initially known abilities:
            AddInitialAbility("useItem");
            AddInitialAbility("brush");
            AddInitialAbility("whisper");
            AddInitialAbility("mirror");


            //Setup which stat / color mods options to use

        }

        public override void Event_LevelUp(SQCreature sender)
        {
            switch (sender.Level)
            {
                case 3:
                    sender.TeachAbility(new Abilities.Curse());
                    sender.TeachAbility(new Abilities.Mirage());
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






        //boring stuff
        public static int RegisterSpecies()
        {
            SQWorld.Register(new EaltaeQhota());
            return 1;
        }


        public override SQCreature NewCreatureOf()
        {
            return new SQCreature(new EaltaeQhota());
        }
    }
}
