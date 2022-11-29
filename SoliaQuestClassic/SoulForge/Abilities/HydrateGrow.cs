using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class HydrateGrow : SQAbility
    {
        public HydrateGrow()
        {
            ModifyAbilityReference("Hydrate / Grow", "hydrateGrow");
            addTypeOf("plant", 1.0);
            description = "(Hydrate) The user gains a Water affinity,\n(Grow) The user loses the water affinity and some evade\nin exchange for a sharp increase in defense.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.PHYSICAL;
            abilityPurpose = SQAbilityPurpose.STAT_BOOST;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 0.0; //unless water type
            m_doBaseDamageSelf   = 0.0;
            m_doBaseHealTarget   = 0.0;
            m_doBaseHealSelf     = 0.0;

            //id like to add another bonus tho

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.0;

            //stamina usage
            m_doBaseStaminaCost = 6.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUse(SQCreature sender)
        {
            if (sender.DoesHaveEffect("hydrateEffect"))
            {
                sender.RemoveEffect("hydrateEffect");
            }
            else
            {
                sender.AddEffect(new Effects.HydrateEffect());
            }
        }

        public override void OnAbilityUsedOn(SQCreature target)
        {
            bool isWater = false;
            for(int ix = 0; ix < target.DynamicTypes.Length; ix++)
            {
                if(target.DynamicTypes[ix] == "water") { isWater = true; }
            }

            if (isWater)
            {
                string[] types = new string[] { "plant" };
                SQType[] trueTypes = new SQType[types.Length];
                for (int t = 0; t < types.Length; t++)
                {
                    SQWorld.SQWorldTypeList.TryGetValue(types[t], out trueTypes[t]);
                }

                SQAbilityInfo info = new SQAbilityInfo();
                info.abilityDisplay = "Drinked!";
                info.abilityType = trueTypes;
                info.targetDodges = false;
                info.doDamageTarget = 13; //flat

                target.DoDamage(info);

                base.OnAbilityUsedOn(target);
            }
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new HydrateGrow());
            return 1;
        }
    }
}
