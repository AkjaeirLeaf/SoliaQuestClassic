using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kirali.Framework;

namespace SoliaQuestClassic.SoulForge
{
    public partial class SQEffect
    {
        private string internalID = "";
        private string displayName = "";
        protected int stackMax = -1;
        public bool isStackable { get { if (stackMax <= 0) { return false; } else { return true; } } }
        public int StackMaximum { get { return stackMax; } }
        public string InternalName { get { return internalID; } }
        public string DisplayName { get { return displayName; } }
        protected int ModifyEffectReference(string display, string internalName)
        {
            try
            {
                displayName = display;
                internalID = internalName;
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        protected bool doShowEffect = true;
        public bool HideAbility { get { return !doShowEffect; } }

        protected string tooltip = "A SoliaQuest creature effect, may be placed upon a creature dealing damage over time, healing, or temporarily changing stats..";
        public string Tooltip { get { return tooltip; } }

        protected double m_tickBaseDamageTarget = 0.0;
        protected double m_tickBaseDamageSelf = 0.0;
        protected double m_tickBaseHealTarget = 0.0;
        protected double m_tickBaseHealSelf = 0.0;

        protected double m_doDecay = 1; //1 is no decay
        protected double m_timeLeft = 0;
        
        protected bool removePostCombat = false;
        public bool RemoveCombatEnd { get { return removePostCombat; } }

        protected int m_doNumberedTicks = -1; //-1 is use decay.
        protected double m_doTickSpeed = 1.0;
        // in the future maybe ill do efficiency boost per type?
        public double GetDecayAmount { get { return m_doDecay; } }
        public double GetTimeLeft { get { return m_timeLeft; } }
        public int GetTickMax { get { return m_doNumberedTicks; } }
        public double GetTickLength { get { return m_doTickSpeed; } }

        private string[] typesOf = new string[0];
        public string[] AbilityType { get { return typesOf; } }
        private double[] typeEffectors = new double[0];
        public double[] TypeEffectors { get { return typeEffectors; } }

        protected int addTypeOf(SQType type, double effector)
        {
            try
            {
                int len = typesOf.Length;
                typesOf = ArrayHandler.appendIfNonexist(typesOf, type.Internal);
                if (len != typesOf.Length)
                {
                    typeEffectors = ArrayHandler.append(typeEffectors, effector);
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        protected int addTypeOf(string type, double effector)
        {
            try
            {
                int len = typesOf.Length;
                if (SQWorld.SQWorldTypeList.ContainsKey(type))
                {
                    typesOf = ArrayHandler.appendIfNonexist(typesOf, type);
                    if (len != typesOf.Length)
                    {
                        typeEffectors = ArrayHandler.append(typeEffectors, effector);
                    }
                    return 1;
                }
                else
                {
                    return -200; //this will be a "type not found" error code.
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// <tooltip>Returns the effectivity multiplier of a certain combination of creature types and ability types, specifically for an ability enacted in the form of DAMAGE TO TARGET.</tooltip>
        /// </summary>
        /// <param name="actionType"></param>
        /// <param name="effectorsOf"></param>
        /// <param name="senderType"></param>
        /// <returns></returns>
        public static double GetEffectiveOut(string[] actionType, double[] effectorsOf, string[] senderType)
        {
            if (senderType.Length > 0 && actionType.Length == effectorsOf.Length)
            {
                //list each type here, then compare to provided sender type
                double modify = 0.0;
                int totalDiv = 0;
                for (int totalSend = 0; totalSend < senderType.Length; totalSend++)
                {
                    SQType thisType;
                    if (SQWorld.SQWorldTypeList.TryGetValue(senderType[totalDiv], out thisType))
                    {
                        //cycle through ability's types for effectiveness comparison
                        for (int subTypes = 0; subTypes < actionType.Length; subTypes++)
                        {
                            modify += effectorsOf[subTypes] * thisType.GetModifyDamageOutgoing(actionType[subTypes]);
                            totalDiv++;
                        }
                    }
                    else { modify += 1.0; totalDiv += 1; }
                }
                double avgMod = modify / totalDiv;
                return avgMod;
            }
            else
            {
                return 1.0;
            }
        }

        /// <summary>
        /// <tooltip>Returns the effectivity multiplier of a certain combination of creature types and ability types, specifically for an ability enacted in the form of DAMAGE TO SELF.</tooltip>
        /// </summary>
        /// <param name="actionType"></param>
        /// <param name="effectorsOf"></param>
        /// <param name="senderType"></param>
        /// <returns></returns>
        public static double GetEffectiveIn(string[] actionType, double[] effectorsOf, string[] senderType)
        {
            if (senderType.Length > 0 && actionType.Length == effectorsOf.Length)
            {
                //list each type here, then compare to provided sender type
                double modify = 0.0;
                int totalDiv = 0;
                for (int totalSend = 0; totalSend < senderType.Length; totalSend++)
                {
                    SQType thisType;
                    if (SQWorld.SQWorldTypeList.TryGetValue(senderType[totalDiv], out thisType))
                    {
                        //cycle through ability's types for effectiveness comparison
                        for (int subTypes = 0; subTypes < actionType.Length; subTypes++)
                        {
                            modify += effectorsOf[subTypes] * thisType.GetModifyDamageIncoming(actionType[subTypes]);
                            totalDiv++;
                        }
                    }
                    else { modify += 1.0; totalDiv += 1; }
                }
                double avgMod = modify / totalDiv;
                return avgMod;
            }
            else
            {
                return 1.0;
            }
        }

        protected virtual double GetTickDamageTarget(SQCreature sender)
        {
            return GetEffectiveOut(typesOf, typeEffectors, sender.CreatureSpecies.UseSpeciesTypes) * m_tickBaseDamageTarget;
        }
        protected virtual double GetTickDamageSelf(SQCreature sender)
        {
            return GetEffectiveIn(typesOf, typeEffectors, sender.CreatureSpecies.UseSpeciesTypes) * m_tickBaseDamageSelf;
        }
        protected virtual double GetTickHealTarget(SQCreature sender)
        {
            return GetEffectiveOut(typesOf, typeEffectors, sender.CreatureSpecies.UseSpeciesTypes) * m_tickBaseHealTarget;
        }
        protected virtual double GetTickHealSelf(SQCreature sender)
        {
            return GetEffectiveIn(typesOf, typeEffectors, sender.CreatureSpecies.UseSpeciesTypes) * m_tickBaseHealSelf;
        }

        public SQEffect()
        {

        }

        public virtual int EffectEvent_Activated(SQCreature effected)
        {
            return 0;
        }

        public virtual int EffectEvent_DoTick(SQCreature effected)
        {
            return 0;
        }

        public virtual int EffectEvent_DoAbilityUsedOn(SQAbility ability, SQCreature effected, SQCreature sender)
        {
            return 0;
        }

        public virtual int EffectEvent_DoAbilityUsedSelf(SQAbility ability, SQCreature effected)
        {
            return 0;
        }

        public virtual int EffectEvent_CombatRoomEnds(SQCreature effected)
        {
            if (removePostCombat) { effected.RemoveEffect(this.internalID); }
            return 0;
        }

        public virtual SQAbilityInfo EffectEvent_OnUseAbility(SQAbilityInfo ability, SQCreature effected, SQCreature target)
        {
            return ability;
        }

        public virtual SQAbilityInfo PreDoDamage(SQAbilityInfo incoming, SQCreature effected, bool dodged = false)
        {
            return incoming;
        }

        public virtual SQAbilityInfo PreDoHeal(SQAbilityInfo incoming, SQCreature effected)
        {
            return incoming;
        }
    }
}
