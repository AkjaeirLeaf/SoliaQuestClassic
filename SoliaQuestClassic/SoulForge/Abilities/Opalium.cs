using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Opalium : SQAbility
    {
        public Opalium()
        {
            ModifyAbilityReference("Opalium", "opalium");
            addTypeOf("crystal", 1.0);
            addTypeOf("light", 1.0);
            description = "A blinding shard of light pierces your conscience";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 22.0;
            m_doBaseDamageSelf = 0.0;
            m_doBaseHealTarget = 0.0;
            m_doBaseHealSelf = 0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.02;

            //stamina usage
            m_doBaseStaminaCost = 6.0;

            //I will use the base ability damage info here :)
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Opalium());
            return 1;
        }
    }
}
