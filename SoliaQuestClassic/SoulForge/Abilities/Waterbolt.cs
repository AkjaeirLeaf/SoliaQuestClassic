using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Waterbolt : SQAbility
    {
        public Waterbolt()
        {
            ModifyAbilityReference("Waterbolt", "waterbolt");
            addTypeOf("water", 1.0);
            description = "A sharp strike of water.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.DAMAGE_ONLY;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 23.0;
            m_doBaseDamageSelf   =  0.0;
            m_doBaseHealTarget   =  0.0;
            m_doBaseHealSelf     =  0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.01;
            m_controlMod = 0.85;

            //stamina usage
            m_doBaseStaminaCost = 4.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUsedOn(SQCreature target)
        {
            //target.AddEffect(new Effects.FrostburnEffect());
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Waterbolt());
            return 1;
        }
    }
}
