using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class CrystalStorm : SQAbility
    {
        public CrystalStorm()
        {
            ModifyAbilityReference("Crystal Storm", "crystalStorm");
            addTypeOf("crystal", 1.0);
            description = "Launches a volley of sharp crystal shards towards a target. Heals the user a small amount.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.HEAL_DAMAGE;

            //set base damage / heal stuff
            m_doBaseDamageTarget =  32.0;
            m_doBaseDamageSelf   =   0.0;
            m_doBaseHealTarget   =   0.0;
            m_doBaseHealSelf     =   6.2;

            //how possible is evading this attack?
            m_dodgeCompdChance   =  0.03;

            //stamina usage
            m_doBaseStaminaCost = 12.0;

            //I will use the base ability damage info here :)
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new CrystalStorm());
            return 1;
        }
    }
}
