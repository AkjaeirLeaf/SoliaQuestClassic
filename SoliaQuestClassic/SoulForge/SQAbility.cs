using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kirali.Framework;

namespace SoliaQuestClassic.SoulForge
{
    public partial class SQAbility
    {
        private string internalID = "";
        private string displayName = "";
        public string InternalName { get { return internalID; } }
        public string DisplayName { get { return displayName; } }
        protected int ModifyAbilityReference(string display, string internalName)
        {
            try
            {
                displayName = display;
                internalID  = internalName;
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        protected SQAbilityCategory abilityCategory = SQAbilityCategory.UNKNOWN;
        public SQAbilityCategory Category { get { return abilityCategory; } }
        protected SQAbilityPurpose abilityPurpose = SQAbilityPurpose.UNKNOWN;
        public SQAbilityPurpose Purpose { get { return abilityPurpose; } }
        protected int abilityOverwritePriority = 0;
        public int OverwritePower { get { return abilityOverwritePriority; } }

        protected bool doShowAbility = true;
        public bool HideAbility { get { return !doShowAbility; } }

        protected string description = "A SoliaQuest creature ability, used to fight, heal, and do other things.";
        public string Description { get { return description; } }

        protected double m_doBaseDamageTarget = 1.0;
        protected double m_doBaseDamageSelf   = 1.0;
        protected double m_doBaseHealTarget   = 1.0;
        protected double m_doBaseHealSelf     = 1.0;

        protected double m_dodgeCompdChance = 0.5;
        protected double m_controlMod = 1;

        protected double m_doBaseStaminaCost = 1.0;
        protected double m_doBaseSpeed = 1.0;
        // in the future maybe ill do efficiency boost per type?
        public double GetDodgeChance { get { return m_dodgeCompdChance; } }
        public double GetControlMod { get { return m_controlMod; } }
        public double GetStaminaCost { get { return m_doBaseStaminaCost; } }
        public double GetUseTime { get { return m_doBaseSpeed; } }

        protected double m_baseExperienceUse = 100;


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
                if(len != typesOf.Length)
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
            if(senderType.Length > 0 && actionType.Length == effectorsOf.Length)
            {
                //list each type here, then compare to provided sender type
                double modify = 0.0;
                int totalDiv = 0;
                for(int totalSend = 0; totalSend < senderType.Length; totalSend++)
                {
                    SQType thisType;
                    if (SQWorld.SQWorldTypeList.TryGetValue(senderType[totalSend], out thisType))
                    {
                        //cycle through ability's types for effectiveness comparison
                        for(int subTypes = 0; subTypes < actionType.Length; subTypes++)
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
                    if (SQWorld.SQWorldTypeList.TryGetValue(senderType[totalSend], out thisType))
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


        public virtual double UseEffectivity(SQCreature sender)
        {
            return GetEffectiveOut(AbilityType, TypeEffectors, sender.CreatureSpecies.UseSpeciesTypes);
        }


        public virtual double GetDealDamageTarget(SQCreature sender)
        {
            return GetEffectiveOut(typesOf, typeEffectors, sender.CreatureSpecies.UseSpeciesTypes) * m_doBaseDamageTarget;
        }
        public virtual double GetDealDamageSelf(SQCreature sender)
        {
            return GetEffectiveIn(typesOf, typeEffectors, sender.CreatureSpecies.UseSpeciesTypes) * m_doBaseDamageSelf;
        }
        public virtual double GetHealValueTarget(SQCreature sender)
        {
            return GetEffectiveOut(typesOf, typeEffectors, sender.CreatureSpecies.UseSpeciesTypes) * m_doBaseHealTarget;
        }
        public virtual double GetHealValueSelf(SQCreature sender)
        {
            return GetEffectiveIn(typesOf, typeEffectors, sender.CreatureSpecies.UseSpeciesTypes) * m_doBaseHealSelf;
        }
        
        //Do Setup effectttttss
        public virtual SQEffect[] GetEffectsTarget(SQCreature sender)
        {
            return null;
        }
        public virtual SQEffect[] GetEffectsSelf(SQCreature sender)
        {
            return null;
        }

        public virtual void OnAbilityUse(SQCreature sender)
        {

        }

        public virtual void OnAbilityUsedOn(SQCreature target)
        {

        }

        public virtual string GetFlavorText(SQCreature sender)
        {
            return "";
        }

        public virtual double GetCriticalChance(SQCreature sender)
        {
            return (Math.Pow(m_controlMod, 2) / 5) * Math.Pow(sender.DynamicControl, 2 * m_controlMod);
        }

        public virtual double RollCritical(SQCreature sender)
        {
            double critChance = GetCriticalChance(sender);
            double x = Kirali.Framework.Random.Double(0, 1) * critChance;
            return x;
        }

        public virtual double GetCriticalDamage(double critResult)
        {
            return m_doBaseDamageTarget * (1 + Math.Floor(critResult) * m_controlMod);
        }

        public virtual double GetCriticalHeal(double critResult, bool isTargetSender = false)
        {
            if (isTargetSender)
            {
                return m_doBaseHealSelf * (1 + Math.Floor(critResult) * m_controlMod);
            }
            else
            {
                return m_doBaseHealTarget * (1 + Math.Floor(critResult) * m_controlMod);
            }
        }

        /// <summary>
        /// <tooltip>Returns the experience gained for using this ability.</tooltip>
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public virtual double GetExperienceUse(SQCreature sender)
        {
            return m_baseExperienceUse / sender.Level;
        }

    }

    public enum SQAbilityCategory
    {
        UNKNOWN,
        PHYSICAL,
        ENERGY,
        EFFECT_SET,
        ITEMLOCK
    }

    public enum SQAbilityPurpose
    {
        UNKNOWN,
        STAT_HIT,
        STAT_BOOST,
        DAMAGE_ONLY,
        DAMAGE_REFLECT,
        APPLY_DAMAGE_EFFECT,
        HEAL_ONLY,
        HEAL_DAMAGE,
        USE_ITEM
    }
}
