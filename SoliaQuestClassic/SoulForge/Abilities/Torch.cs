using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kirali;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Torch : SQAbility
    {
        public Torch()
        {
            ModifyAbilityReference("Torch", "torch");
            addTypeOf("light", 1.0);
            description = "A basic light attack that blinds your opponent.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.APPLY_DAMAGE_EFFECT;

            //set base damage / heal stuff
            m_doBaseDamageTarget =  12.0;
            m_doBaseDamageSelf   =   1.0;
            m_doBaseHealTarget   =   0.0;
            m_doBaseHealSelf     =   0.0;

            //id like to add another bonus tho

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.007;
            m_controlMod       =  0.80;

            //stamina usage
            m_doBaseStaminaCost = 4.5;

            //I will use the base ability damage info here :)
        }

        public override string GetFlavorText(SQCreature sender)
        {
            string ident = sender.CreatureName;
            if (String.IsNullOrEmpty(ident)) { ident = sender.CreatureSpecies.SpeciesName; }
            int response = Kirali.Framework.Random.Int(0, 100);
            if(response < 5)
            {
                return ident + " shines bright like a star!";
            }
            else
            {
                return ident + " emits an intense beam of light.";
            }
        }

        public override void OnAbilityUsedOn(SQCreature target)
        {
            //separate 70% chance to burn and 70% chance to stun target
            double applyEffect = Kirali.Framework.Random.Double(0, 1);
            if(applyEffect < 0.9)
            { target.AddEffect(new Effects.BlindedEffect()); }
            applyEffect = Kirali.Framework.Random.Double(0, 1);
            if(applyEffect < 0.2)
            { target.AddEffect(new Effects.StunnedEffect()); }
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Brush());
            return 1;
        }
    }
}
