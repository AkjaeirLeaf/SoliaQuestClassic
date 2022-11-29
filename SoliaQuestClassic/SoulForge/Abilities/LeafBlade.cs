using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kirali;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class LeafBlade : SQAbility
    {
        public LeafBlade()
        {
            ModifyAbilityReference("Leaf Blade", "leafBlade");
            addTypeOf("plant", 1.0);
            addTypeOf("spirit", 1.0);
            description = "A basic plant attack that launches a large sharp leaf at your opponent. Damages the user a little.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.DAMAGE_ONLY;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 28.0;
            m_doBaseDamageSelf   =  5.0;
            m_doBaseHealTarget   =  0.0;
            m_doBaseHealSelf     =  0.0;

            //id like to add another bonus tho

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.03;
            m_controlMod       = 0.80;

            //stamina usage
            m_doBaseStaminaCost = 5.0;

            //I will use the base ability damage info here :)
        }

        public override string GetFlavorText(SQCreature sender)
        {
            string ident = sender.CreatureName;
            if (String.IsNullOrEmpty(ident)) { ident = sender.CreatureSpecies.SpeciesName; }
            int response = Kirali.Framework.Random.Int(0, 100);
            if(response < 5)
            {
                return ident + " hurls a big leafy sword.";
            }
            else
            {
                return ident + " whips up a flurry of sharp leaves.";
            }
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new LeafBlade());
            return 1;
        }
    }
}
