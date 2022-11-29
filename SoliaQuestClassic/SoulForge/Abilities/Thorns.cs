using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kirali;

using SoliaQuestClassic.SoulForge.Effects;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Thorns : SQAbility
    {
        public Thorns()
        {
            ModifyAbilityReference("Thorns", "thorns");
            addTypeOf("plant", 1.0);
            addTypeOf("toxic", 1.0);
            description = "A basic plant ability that covers the user in sharp thorns. \nPhysical attacks on the user deal damage to the attacker.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.PHYSICAL;
            abilityPurpose = SQAbilityPurpose.DAMAGE_ONLY;

            //set base damage / heal stuff
            m_doBaseDamageTarget =  0.0;
            m_doBaseDamageSelf   =  0.0;
            m_doBaseHealTarget   =  0.0;
            m_doBaseHealSelf     =  0.0;

            //id like to add another bonus tho

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.00;
            m_controlMod       = 0.80;

            //stamina usage
            m_doBaseStaminaCost = 13.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUse(SQCreature sender)
        {
            sender.AddEffect(new Effects.ThornsEffect());

            base.OnAbilityUse(sender);
        }

        public override string GetFlavorText(SQCreature sender)
        {
            string ident = sender.CreatureName;
            if (String.IsNullOrEmpty(ident)) { ident = sender.CreatureSpecies.SpeciesName; }
            int response = Kirali.Framework.Random.Int(0, 100);
            if(response < 5)
            {
                return ident + " rolls around in the bushes...";
            }
            else
            {
                return ident + " covers " + SQWorld.GetPronoun(sender.Gender, SQWorld.PronounType.Object) + "self in spiky thorns.";
            }
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Thorns());
            return 1;
        }
    }
}
