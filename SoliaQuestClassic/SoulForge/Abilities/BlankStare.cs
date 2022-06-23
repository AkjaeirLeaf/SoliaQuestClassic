using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class BlankStare : SQAbility
    {
        public BlankStare()
        {
            ModifyAbilityReference("Blank Stare", "blankStare");
            addTypeOf("typeless", 1.0);
            description = "Looks at you without any sort of expression.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.PHYSICAL;
            abilityPurpose = SQAbilityPurpose.UNKNOWN;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 0.0;
            m_doBaseDamageSelf = 0.0;
            m_doBaseHealTarget = 0.0;
            m_doBaseHealSelf = 0.0;

            //id like to add another bonus tho

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.0;

            //stamina usage
            m_doBaseStaminaCost = 0.0;

            m_baseExperienceUse = 0;

            //I will use the base ability damage info here :)
        }

        public override string GetFlavorText(SQCreature sender)
        {
            string ident = sender.CreatureName;
            if (String.IsNullOrEmpty(ident)) { ident = sender.CreatureSpecies.SpeciesName; }
            int response = Kirali.Framework.Random.Int(0, 100);
            if(response < 50)
            {
                return ident + " looks at you blankly";
            }
            else if (response < 85)
            {
                return ident + " gives you an expressionless look";
            }
            else if (response < 98)
            {
                return ident + " has no feelings on the matter";
            }
            else
            {
                return "It doesn\'t matter";
            }
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new BlankStare());
            return 1;
        }
    }
}
