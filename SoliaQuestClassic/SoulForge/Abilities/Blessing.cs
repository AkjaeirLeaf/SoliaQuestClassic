using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Blessing : SQAbility
    {
        public Blessing()
        {
            ModifyAbilityReference("Blessing", "blessing");
            addTypeOf("light", 1.0);
            addTypeOf("spirit", 1.0);
            description = "You've gained the attention of the spirits and have an unusually high amount of luck on your side.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.STAT_BOOST;

            //set base damage / heal stuff
            m_doBaseDamageTarget =  0.0;
            m_doBaseDamageSelf   =  0.0;
            m_doBaseHealTarget   =  0.0;
            m_doBaseHealSelf     = 17.0; //after implementing teams and target selection, switch heal self to heal target

            //how possible is evading this attack?
            m_dodgeCompdChance   = 0.00;
            m_controlMod         = 0.80;

            //stamina usage
            m_doBaseStaminaCost  = 12.0;

            //I will use the base ability damage info here :)
        }

        public override string GetFlavorText(SQCreature sender)
        {
            string ident = sender.CreatureName;
            if (String.IsNullOrEmpty(ident)) { ident = sender.CreatureSpecies.SpeciesName; }
            int response = Kirali.Framework.Random.Int(0, 100);
            if(response < 10)
            {
                return ident + " calls upon the spirits of the Source.";
            }
            else
            {
                return ident + " calls for help from the starlight.";
            }
        }

        public override void OnAbilityUse(SQCreature sender)
        {
            sender.AddEffect(new Effects.BlessingEffect());
        }

        //public override void OnAbilityUsedOn(SQCreature target)
        //{
        //   target.AddEffect(new Effects.BlessingEffect());
        //}

        public static int RegisterAbility()
        {
            SQWorld.Register(new Blessing());
            return 1;
        }
    }
}
