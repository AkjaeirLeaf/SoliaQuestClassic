using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class CrystalTalon : SQAbility
    {
        public CrystalTalon()
        {
            ModifyAbilityReference("Crystal Talon", "crystalTalon");
            addTypeOf("crystal", 1.0);
            description = "Claws sharp as crystal shards cut through anything they contact.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.PHYSICAL;
            abilityPurpose = SQAbilityPurpose.DAMAGE_ONLY;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 23.0;
            m_doBaseDamageSelf = 0.0;
            m_doBaseHealTarget = 0.0;
            m_doBaseHealSelf = 0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.08;

            //stamina usage
            m_doBaseStaminaCost = 4.0;

            //I will use the base ability damage info here :)
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new CrystalTalon());
            return 1;
        }
    }
}
