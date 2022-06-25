using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class CryonicBlast : SQAbility
    {
        public CryonicBlast()
        {
            ModifyAbilityReference("CryonicBlast", "cryonicBlast");
            addTypeOf("ice", 1.0);
            description = "A barrage of sharp ice spikes propel towards your target.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.APPLY_DAMAGE_EFFECT;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 28.0;
            m_doBaseDamageSelf   =  0.0;
            m_doBaseHealTarget   =  0.0;
            m_doBaseHealSelf     =  0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance   = 0.01;
            m_controlMod         = 0.75;

            //stamina usage
            m_doBaseStaminaCost  = 9.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUsedOn(SQCreature target)
        {
            target.AddEffect(new Effects.FrostburnEffect());
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new CryonicBlast());
            return 1;
        }
    }
}
