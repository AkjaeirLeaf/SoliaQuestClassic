using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using SoliaQuestClassic.IO;
using SoliaQuestClassic.Render;
using SoliaQuestClassic.Render.Animation;

using Kirali.Framework;

namespace SoliaQuestClassic.SoulForge
{
    public partial class SQCreature
    {
        protected string creatureUniqueID = "";
        public string GetUniqueID() { return creatureUniqueID; }
        protected string creatureName = "";
        public string CreatureName { get { return creatureName; } set { creatureName = value; } }
        protected SQGender gender = SQGender.Genderless;
        public SQGender Gender { get { return gender; } set { gender = value; } }
        private Dictionary<string, object> containedCreatureTags = new Dictionary<string, object>();
        public SQSpecies CreatureSpecies { get { return m_species; } }
        


        public int AddTag(string key, object obj)
        {
            try
            {
                containedCreatureTags.Add(key, obj);
                return 1;
            }
            catch (ArgumentException)
            {
                containedCreatureTags[key] = obj;
                return 2;
            }
        }
        public bool TryGetTag(string key, out object tagInfo)
        {
            if (containedCreatureTags.TryGetValue(key, out tagInfo))
            {
                return true;
            }
            return false;
        }


        //Storage 
        #region dataDefinitions

        private int creatureLevel = 1;
        public int Level { get { return creatureLevel; } }
        private double experienceAt = 0.0;
        public double Experience { get { return experienceAt; } }
        private int totalPointsGiven = 1;
        public int StatPointsUsed { get {
                return pointsU_Health + pointsU_Defense + pointsU_Attack + pointsU_Stamina + pointsU_Evade + pointsU_Control;
            } }
        public int StatPointsAvailable { get { return totalPointsGiven - StatPointsUsed; } }
        public int StatPointsTotal { get { return totalPointsGiven; } }

        private SQCreatureState creatureState = SQCreatureState.Nominal;
        public SQCreatureState State { get { return creatureState; } }
        public void ModifyCreatureState(SQCreatureState state)
        {
            creatureState = state;
        }


        protected SQSpecies m_species;
        protected string m_speciesInternal;
        

        protected double stat_Health  = 100.0; protected int pointsU_Health  = 0;
        protected double stat_Defense =   2.0; protected int pointsU_Defense = 0;
        protected double stat_Attack  =  10.0; protected int pointsU_Attack  = 0;
        protected double stat_Stamina =  20.0; protected int pointsU_Stamina = 0;
        protected double stat_Evade   =   1.0; protected int pointsU_Evade   = 0;
        protected double stat_Control =   0.5; protected int pointsU_Control = 0;

        protected string statRank_Health  = "";
        protected string statRank_Defense = "";
        protected string statRank_Attack  = "";
        protected string statRank_Stamina = "";
        protected string statRank_Evade   = "";
        protected string statRank_Control = "";

        protected double stat_advanceHealth  = 100.0; protected double softLock_Health  = 0;
        protected double stat_advanceDefense =   2.0; protected double softLock_Defense = 0;
        protected double stat_advanceAttack  =  10.0; protected double softLock_Attack  = 0;
        protected double stat_advanceStamina =  20.0; protected double softLock_Stamina = 0;
        protected double stat_advanceEvade   =   1.0; protected double softLock_Evade   = 0;
        protected double stat_advanceControl =   0.5; protected double softLock_Control = 0;


        public double Health { get { return stat_advanceHealth; } }
        public double Defense { get { return stat_advanceDefense; } }
        public double Attack { get { return stat_advanceAttack; } }
        public double Stamina { get { return stat_advanceStamina; } }
        public double Evade { get { return stat_advanceEvade; } }
        public double Control { get { return stat_advanceControl; } }

        public double DefaultHealth  { get { return stat_Health; } }
        public double DefaultDefense { get { return stat_Defense; } }
        public double DefaultAttack  { get { return stat_Attack; } }
        public double DefaultStamina { get { return stat_Stamina; } }
        public double DefaultEvade   { get { return stat_Evade; } }
        public double DefaultControl { get { return stat_Control; } }

        //DYNAMIC STATS SECTION - For storing the "current" stats of the creature, IE, in battle.
        protected double dynamic_Health  = 0.0;
        protected double dynamic_Defense = 0.0;
        protected double dynamic_Attack  = 0.0;
        protected double dynamic_Stamina = 0.0;
        protected double dynamic_Evade   = 0.0;
        protected double dynamic_Control = 0.0;
        protected string[] dynamic_Affinities = new string[0];

        public double DynamicHealth  { get { return dynamic_Health;  } }
        public double DynamicDefense { get { return dynamic_Defense; } }
        public double DynamicAttack  { get { return dynamic_Attack;  } }
        public double DynamicStamina { get { return dynamic_Stamina; } }
        public double DynamicEvade   { get { return dynamic_Evade;   } }
        public double DynamicControl { get { return dynamic_Control; } }
        public string[] DynamicTypes { get { return dynamic_Affinities; } set { dynamic_Affinities = value; } }

        protected SQEffect[] activeEffects = new SQEffect[0];
        protected int[] effectsStack = new int[0];
        public SQEffect[] ActiveEffects { get { return activeEffects; } }
        public int[] EffectsStack { get { return effectsStack; } }

        //add, remove, and search effects.
        public int AddEffect(SQEffect effect)
        {
            if(activeEffects.Length > 0)
            {
                for(int p = 0; p < activeEffects.Length; p++)
                {
                    if(activeEffects[p].InternalName == effect.InternalName)
                    {
                        if(effect.isStackable && effectsStack[p] < effect.StackMaximum)
                        {
                            effectsStack[p]++;
                            activeEffects[p].EffectEvent_Activated(this);
                            return 2;
                        }
                        return 0;
                    }
                }
                activeEffects = ArrayHandler.append(activeEffects, effect);
                effectsStack = ArrayHandler.append(effectsStack, 1);
                activeEffects[activeEffects.Length - 1].EffectEvent_Activated(this);
                return 1;
            }
            else
            {
                activeEffects = new SQEffect[] { effect };
                effectsStack = new int[] { 1 };
                activeEffects[0].EffectEvent_Activated(this);
                return 1;
            }
        }
        public bool DoesHaveEffect(string effectID)
        {
            if (activeEffects.Length > 0)
            {
                for (int p = 0; p < activeEffects.Length; p++)
                {
                    if (activeEffects[p].InternalName == effectID)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        public int RemoveEffect(string effectID)
        {
            if (DoesHaveEffect(effectID))
            {
                SQEffect[] newEffectsList = new SQEffect[ActiveEffects.Length - 1];
                int[] newEffectsStack = new int[newEffectsList.Length];
                int place = 0;
                bool removeEffectStack = true;
                for (int p = 0; p < activeEffects.Length; p++)
                {
                    if (activeEffects[p].InternalName == effectID)
                    {
                        activeEffects[p].EffectEvent_RemoveEffect(this);
                        if(effectsStack[p] > 1)
                        {
                            effectsStack[p]--;
                            removeEffectStack = false;
                            return 2;
                        }
                        else
                        {
                            removeEffectStack = true;
                        }
                        //do nothing, and this effect won't be added to the new list.
                    }
                    else
                    {
                        newEffectsList[place] = activeEffects[p];
                        newEffectsStack[place] = effectsStack[p];
                        place++;
                    }
                }

                activeEffects = newEffectsList;
                effectsStack = newEffectsStack;
                return 1;
            }
            return 0;
        }


        //Stat-Mod Storage
        protected string statMod = ""; protected string initialStatMod = ""; protected bool upgraded = false;
        public string StatMod { get { return statMod; } }
        public double GetStatValue(SQCreatureStat statType)
        {
            switch (statType)
            {
                case SQCreatureStat.Health:
                    return stat_advanceHealth;
                case SQCreatureStat.Defense:
                    return stat_advanceDefense;
                case SQCreatureStat.Attack:
                    return stat_advanceAttack;
                case SQCreatureStat.Stamina:
                    return stat_advanceStamina;
                case SQCreatureStat.Evade:
                    return stat_advanceEvade;
                case SQCreatureStat.Control:
                    return stat_advanceControl;
                default:
                    return 0;
            }
        }

        //ranks of stats
        public SQStatMod GetStatRank (SQCreatureStat statType)
        {
            SQStatMod statStatMod;
            switch (statType)
            {
                case SQCreatureStat.Health:
                    if(SQWorld.SQWorldStatModList.TryGetValue(statRank_Health, out statStatMod))
                    {
                        return statStatMod;
                    } else { return new StatMods.Ordinary(); }
                case SQCreatureStat.Defense:
                    if (SQWorld.SQWorldStatModList.TryGetValue(statRank_Defense, out statStatMod))
                    {
                        return statStatMod;
                    }
                    else { return new StatMods.Ordinary(); }
                case SQCreatureStat.Attack:
                    if (SQWorld.SQWorldStatModList.TryGetValue(statRank_Attack, out statStatMod))
                    {
                        return statStatMod;
                    }
                    else { return new StatMods.Ordinary(); }
                case SQCreatureStat.Stamina:
                    if (SQWorld.SQWorldStatModList.TryGetValue(statRank_Stamina, out statStatMod))
                    {
                        return statStatMod;
                    }
                    else { return new StatMods.Ordinary(); }
                case SQCreatureStat.Evade:
                    if (SQWorld.SQWorldStatModList.TryGetValue(statRank_Evade, out statStatMod))
                    {
                        return statStatMod;
                    }
                    else { return new StatMods.Ordinary(); }
                case SQCreatureStat.Control:
                    if (SQWorld.SQWorldStatModList.TryGetValue(statRank_Control, out statStatMod))
                    {
                        return statStatMod;
                    }
                    else { return new StatMods.Ordinary(); }
                default:
                    return new StatMods.Ordinary();
            }
        }
        protected SQStatMod CalculateStatRank(SQCreatureStat statType)
        {
            SQStatMod[] statModList = new SQStatMod[SQWorld.SQWorldStatModList.Count];
            SQWorld.SQWorldStatModList.Values.CopyTo(statModList, 0);
            SQStatMod lastGreater = new StatMods.Unimpressive();

            double statBeTested = -19;
            switch (statType)
            {
                case SQCreatureStat.Health:
                    statBeTested = stat_advanceHealth;
                    break;
                case SQCreatureStat.Defense:
                    statBeTested = stat_advanceDefense;
                    break;
                case SQCreatureStat.Attack:
                    statBeTested = stat_advanceAttack;
                    break;
                case SQCreatureStat.Stamina:
                    statBeTested = stat_advanceStamina;
                    break;
                case SQCreatureStat.Evade:
                    statBeTested = stat_advanceEvade;
                    break;
                case SQCreatureStat.Control:
                    statBeTested = stat_advanceControl;
                    break;
            }


            for (int statmodcyc = 0; statmodcyc < statModList.Length; statmodcyc++)
            {
                double min = StatCalcMinMax(statModList[statmodcyc], statType, false);
                double max = StatCalcMinMax(statModList[statmodcyc], statType,  true);
                
                if (statBeTested >= min)
                {
                    if(statBeTested < max)
                    {
                        return statModList[statmodcyc];
                    }
                    else
                    {
                        lastGreater = statModList[statmodcyc];
                        double nextMin = max;
                        double nextMax = max + 0.01;
                        try
                        {
                            nextMin = StatCalcMinMax(statModList[statmodcyc + 1], statType, false);
                            nextMax = StatCalcMinMax(statModList[statmodcyc + 1], statType, true);
                            if (statBeTested < nextMax) { return statModList[statmodcyc + 1]; }
                            else
                            {
                                //do nothing
                            }
                        }
                        catch
                        {
                            return statModList[statmodcyc];
                        }
                    }
                }
            }
            return new StatMods.Ordinary();
        }
        protected void UpdateAllStatRanks()
        {
            statRank_Health  = CalculateStatRank(SQCreatureStat.Health ).InternalID;
            statRank_Defense = CalculateStatRank(SQCreatureStat.Defense).InternalID;
            statRank_Attack  = CalculateStatRank(SQCreatureStat.Attack ).InternalID;
            statRank_Stamina = CalculateStatRank(SQCreatureStat.Stamina).InternalID;
            statRank_Evade   = CalculateStatRank(SQCreatureStat.Evade  ).InternalID;
            statRank_Control = CalculateStatRank(SQCreatureStat.Control).InternalID;
        }

        public double StatCalcMinMax(SQStatMod statmod, SQCreatureStat statType, bool doMax = false)
        {
            double min = 0;
            double max = 0;
            switch (statType)
            {
                case SQCreatureStat.Health:
                    if( !doMax) return statmod.defaultFunction(m_species.BaseStatHealth, 0);
                    else        return statmod.defaultFunction(m_species.BaseStatHealth, 1);
                    break;
                case SQCreatureStat.Defense:
                    if (!doMax) return statmod.defaultFunction(m_species.BaseStatDefense, 0);
                    else        return statmod.defaultFunction(m_species.BaseStatDefense, 1);
                    break;
                case SQCreatureStat.Attack:
                    if (!doMax) return statmod.defaultFunction(m_species.BaseStatAttack, 0);
                    else        return statmod.defaultFunction(m_species.BaseStatAttack, 1);
                    break;
                case SQCreatureStat.Stamina:
                    if (!doMax) return statmod.defaultFunction(m_species.BaseStatStamina, 0);
                    else        return statmod.defaultFunction(m_species.BaseStatStamina, 1);
                    break;
                case SQCreatureStat.Evade:
                    if (!doMax) return statmod.defaultFunction(m_species.BaseStatEvade, 0);
                    else        return statmod.defaultFunction(m_species.BaseStatEvade, 1);
                    break;
                case SQCreatureStat.Control:
                    if (!doMax) return statmod.defaultFunction(m_species.BaseStatControl, 0);
                    else        return statmod.defaultFunction(m_species.BaseStatControl, 1);
                    break;
            }
            return -1;
        }
        

        //Color-Mods Storage
        protected string[] colorMods = new string[0];
        public string[] ColorMods { get { return colorMods; } }


        #endregion dataDefinitions

        //Inventory
        protected bool doesHaveInventory = false;
        protected int mainInventorySize = 0;
        protected SQInventory mainInventory;
        protected void SetupInventory()
        {
            if(doesHaveInventory && mainInventorySize > 0)
            {
                mainInventory = new SQInventory(mainInventorySize);
            }
        }
        public void CreateCreatureMainInventory(int size)
        {
            if(size > 0)
            {
                doesHaveInventory = true;
                mainInventorySize = size;
                mainInventory = new SQInventory(size);
            }
        }
        public bool HasInventory { get { return doesHaveInventory; } }
        public int InventorySize { get { if (doesHaveInventory) { return mainInventorySize; }
                else { return 0; } } }
        public SQInventory MainInventory { get { return mainInventory; } }
        public void QuickGiveItem(SQItemStack stack)
        {
            if (HasInventory)
            {
                MainInventory.AddItemStack(stack, out _);
            }
        }
        public void QuickGiveItem(SQItem item, int count)
        {
            if (HasInventory)
            {
                MainInventory.AddItemStack(new SQItemStack(item, count, out _, true), out _);
            }
        }


        //Primary Constructor
        protected SQCreature() { }
        public SQCreature(SQSpecies species)
        {
            m_species = species;
            m_speciesInternal = species.InternalName;

            stat_Health  = species.BaseStatHealth;
            stat_Defense = species.BaseStatDefense;
            stat_Attack  = species.BaseStatAttack;
            stat_Stamina = species.BaseStatStamina;
            stat_Evade   = species.BaseStatEvade;
            stat_Control = species.BaseStatControl;

            stat_advanceHealth  = stat_Health;
            stat_advanceDefense = stat_Defense;
            stat_advanceAttack  = stat_Attack;
            stat_advanceStamina = stat_Stamina;
            stat_advanceEvade   = stat_Evade;
            stat_advanceControl = stat_Control;

            //TODO add stat mods and color mods, implement stat changes fetching.

            //get stat modifier?
            SQStatMod[] statModList = new SQStatMod[SQWorld.SQWorldStatModList.Count];
            SQWorld.SQWorldStatModList.Values.CopyTo(statModList, 0);
            int selectedHighest = 0;
            int highestStatPower = 0;
            for(int statmodcyc = 0; statmodcyc < statModList.Length; statmodcyc++)
            {
                if(Kirali.Framework.Random.Double(0,1) < statModList[statmodcyc].BaseProbability
                    && statModList[statmodcyc].StatModPower >= highestStatPower)
                {
                    selectedHighest = statmodcyc;
                    highestStatPower = statModList[statmodcyc].StatModPower;
                }
            }
            statMod = statModList[selectedHighest].InternalID;
            initialStatMod = statMod; upgraded = false;

            //set new stat values
            stat_advanceHealth  = statModList[selectedHighest].GetStatHealth(stat_Health);
            stat_advanceDefense = statModList[selectedHighest].GetStatDefense(stat_Defense);
            stat_advanceAttack  = statModList[selectedHighest].GetStatAttack(stat_Attack);
            stat_advanceStamina = statModList[selectedHighest].GetStatStamina(stat_Stamina);
            stat_advanceEvade   = statModList[selectedHighest].GetStatEvade(stat_Evade);
            stat_advanceControl = statModList[selectedHighest].GetStatControl(stat_Control);
            UpdateAllStatRanks();

            //add color mods?
            SQColorMod[] colorModList = new SQColorMod[SQWorld.SQWorldColorModList.Count];
            SQWorld.SQWorldColorModList.Values.CopyTo(colorModList, 0);
            int maxColorPow = -3;
            bool stop = false;
            for (int colorModCyc = 0; colorModCyc < colorModList.Length; colorModCyc++)
            {
                if (Kirali.Framework.Random.Double(0, 1) < colorModList[colorModCyc].BaseProbability)
                {
                    switch (colorModList[colorModCyc].OverrideType)
                    {
                        case SQColorModOverridesType.useArray:

                            //loop shit

                            break;
                        case SQColorModOverridesType.overrideLower:

                            //loop colorMods to check

                            break;
                        case SQColorModOverridesType.overrideHigher:

                            //loop colorMods to check

                            break;
                        case SQColorModOverridesType.overrideAll:
                            colorMods = new string[1] { colorModList[colorModCyc].InternalID };
                            stop = true;
                            break;
                        case SQColorModOverridesType.overrideNone:

                            break;
                        case SQColorModOverridesType.attemptAdd:
                            colorMods = ArrayHandler.append(colorMods, colorModList[colorModCyc].InternalID);

                            break;
                    }
                    if (stop) { break; }
                }
            }



            //set full stats
            DynamicTypes = species.UseSpeciesTypes;

            FullHeal();
            LearnDefaultAbilities();
            SetupInventory();
        }
        
        //Dislpay
        public string DisplayAs()
        {
            string displayCr = "";
            SQType typeOf;
            SQSpecies speciesOf;
            SQStatMod statMod;
            displayCr += "Level " + Level + " ";

            if(SQWorld.SQWorldSpeciesList.TryGetValue(m_speciesInternal, out speciesOf)
                && SQWorld.SQWorldStatModList.TryGetValue(StatMod, out statMod))
            {
                if (statMod.DoDisplayName) {
                    string statdisp = statMod.Display;
                    if (upgraded) { statdisp += "†"; }
                    displayCr += statdisp + " "; }
                if(colorMods.Length > 0)
                {
                    for(int colorModIx = 0; colorModIx < colorMods.Length; colorModIx++)
                    {
                        SQColorMod colorMod;
                        if (SQWorld.SQWorldColorModList.TryGetValue(colorMods[colorModIx], out colorMod))
                        {
                            if (colorMod.DoDisplayName) { displayCr += colorMod.Display + " "; }
                        }
                    }
                }
                displayCr += speciesOf.SpeciesName;
                return displayCr;
            }
            return null;
        } //Display string, ex: Level 158 Unusual Negative Cosmic Silvertail Cat
        public Bitmap GetFrameImage()
        {
            string age = "young";
            string pose = "p0";
            string color;
            if(colorMods.Length == 0) { color = "default"; }
            else { color = colorMods[0];  }
            SpeciesImageReference res;
            if (m_species.TryGetImage("frame", age, pose, color, out res))
            {
                return res.image_data;
            }
            else return new Bitmap(512, 512);
        }
        public void ForceModifyColors(string[] newColors)
        {
            colorMods = newColors;
        }
        public PoseableObject CreatureModel; private bool ModelClone = false;
        public Texture2D[] CreatureTextures;


        
        public void LoadCloneModel() 
        {
            SQSpecies species;
            if(SQWorld.SQWorldSpeciesList.TryGetValue(m_species.InternalName, out species))
            {
                species.LoadSpeciesModel(); // this shoullddd load the textures too automatically
                CreatureModel = new PoseableObject(species.GetModel()); ModelClone = true;
                CreatureModel.LinkObject.ObjectTextures = species.GetTextures();

            }

            

            //m_species.LoadSpeciesModel(); 
            //m_species.LoadSpeciesImages();
            //CreatureModel = new PoseableObject(m_species.GetModel()); ModelClone = true;
            //CreatureModel.LinkObject.ObjectTextures = m_species.GetTextures();
        }

        private Animation ActiveAnimationLink;
        private Animation AnimationQueued = null;
        public void PlayAnimation(Animation anim)
        {
            ActiveAnimationLink = anim;
            ActiveAnimationLink.PlayAnimation();
        }

        public void PauseAnimation() { ActiveAnimationLink.PauseAnimation(); }
        public void RestartAnimation() { ActiveAnimationLink.RestartAnimation(); }
        public void StopAnimation()  { ActiveAnimationLink.StopAnimation(); }
        public void ClearAnimation() { ActiveAnimationLink = null; }
        public void QueueStopAnimation()  { ActiveAnimationLink.StopAtNextLoop(); }
        public void QueueAnimation(Animation anim)
        {
            AnimationQueued = anim;
            QueueStopAnimation();
        }
        public void SwitchCurrentAnimation()
        {
            ClearAnimation();
            ActiveAnimationLink = AnimationQueued;
            AnimationQueued = null;
            ActiveAnimationLink.PlayAnimation();
        }


        private int ctr = 0; // cycle throung colors mb
        private int img = 0;
        public void Render(Kirali.Light.Camera MainCamera, Kirali.MathR.Vector3 LightSource, Kirali.Light.KColor4 LightColor)
        {
            if (ModelClone)
            {
                //int useTextureSlot = 6;
                int useTextureSlot = img;

                //do animations tick
                if(ActiveAnimationLink != null) { ActiveAnimationLink.Tick(); }
                if(AnimationQueued != null)
                {
                    if(ActiveAnimationLink != null)
                    {
                        if (ActiveAnimationLink.AnimationQueuedReady) { SwitchCurrentAnimation(); }
                    }
                    else
                    {
                        SwitchCurrentAnimation();
                    }
                }

                //ctr++;
                //if(ctr > 80) { ctr -= 80; img++; } if (img > 6) { img = 0; }
                CreatureModel.Render(MainCamera, useTextureSlot, LightSource, LightColor);
            }
            else { LoadCloneModel(); }
        }
        public void Pose()
        {
            // AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        }




        //Combat
        public void EnterBattle()
        {
            dynamic_Affinities = m_species.UseSpeciesTypes;
            dynamic_Health  = Health;
            dynamic_Defense = Defense;
            dynamic_Attack  = Attack;
            dynamic_Stamina = Stamina;
            dynamic_Evade   = Evade;
            dynamic_Control = Control;
        }
        
        public void ExitBattle()
        {
            //Only modify health really :)
            //stat_advanceHealth  = DynamicHealth;
            //stat_advanceStamina = DynamicStamina;

            dynamic_Defense = stat_advanceDefense;
            dynamic_Attack  = stat_advanceAttack;
            dynamic_Evade   = stat_advanceEvade;
            dynamic_Control = stat_advanceControl;
        }

        public void FullHeal()
        {
            dynamic_Health  = stat_advanceHealth ;
            dynamic_Defense = stat_advanceDefense;
            dynamic_Attack  = stat_advanceAttack ;
            dynamic_Stamina = stat_advanceStamina;
            dynamic_Evade   = stat_advanceEvade  ;
            dynamic_Control = stat_advanceControl;
            creatureState   = SQCreatureState.Nominal;
        }

        public void AddDynamicTyping(string type_add)
        {
            SQType Typeadd;
            bool alreadyHas  = false;
            bool sp_isTless  = false;
            bool hasTypeless = false;
            for (int ix = 0; ix < dynamic_Affinities.Length; ix++)
            {
                if(type_add == dynamic_Affinities[ix])
                {
                    alreadyHas = true;
                }
            }
            

            if (SQWorld.SQWorldTypeList.TryGetValue(type_add, out Typeadd) && !alreadyHas)
            {
                string[] newDyn = new string[dynamic_Affinities.Length + 1];
                for(int ix = 0; ix < dynamic_Affinities.Length; ix++)
                {
                    newDyn[ix] = dynamic_Affinities[ix];
                }
                newDyn[dynamic_Affinities.Length] = Typeadd.Internal;
                dynamic_Affinities = newDyn;

                //if new type affinity is added but creature has typeless in dyn but not species, we need to remove the typeless affinity.
                for (int ix = 0; ix < m_species.UseSpeciesTypes.Length; ix++)
                {
                    if ("typeless" == m_species.UseSpeciesTypes[ix])
                    {
                        sp_isTless = true;
                    }
                }
                for (int ix = 0; ix < dynamic_Affinities.Length; ix++)
                {
                    if ("typeless" == dynamic_Affinities[ix])
                    {
                        hasTypeless = true;
                    }
                }
                if (!sp_isTless && hasTypeless)
                {
                    string[] nd2 = new string[dynamic_Affinities.Length - 1];
                    int pl = 0;
                    for(int ixa = 0; ixa < dynamic_Affinities.Length; ixa++)
                    {
                        if(dynamic_Affinities[ixa] == "typeless") { }
                        else { nd2[pl] = dynamic_Affinities[ixa]; pl++; }
                    }
                    dynamic_Affinities = nd2;
                }
            }
        }

        public void RemoveDynamicTyping(string type_add)
        {
            int pl = 0;
            bool found = false;
            string[] newDyn = new string[dynamic_Affinities.Length - 1];

            bool isSpeciesTyping = false;
            for(int ixi = 0; ixi < m_species.UseSpeciesTypes.Length; ixi++)
            {
                if(m_species.UseSpeciesTypes[ixi] == type_add) { isSpeciesTyping = true; }
            }

            if (!isSpeciesTyping)
            {
                for (int ix = 0; ix < dynamic_Affinities.Length; ix++)
                {
                    if (type_add == dynamic_Affinities[ix])
                    {
                        found = true;
                    }
                    else
                    {
                        newDyn[pl] = dynamic_Affinities[ix];
                        pl++;
                    }
                }
                if (newDyn.Length == 0 && found) { newDyn = new string[] { "typeless" }; }
                dynamic_Affinities = newDyn;
            }
        }

        public void GiveExperience(double points)
        {
            experienceAt += points;
            TryLevelUp();
        }

        //learning abilities
        protected SQAbility[] creatureAbilities = new SQAbility[0];
        public SQAbility[] Abilities { get { return creatureAbilities; } }
        public int TeachAbility(SQAbility newAbility, bool overwrite = true, bool overwriteNoPower = true)
        {
            int position = 0;
            if(creatureAbilities.Length > 0)
            {
                position = -1;
                for(int p = 0; p < creatureAbilities.Length; p++)
                {
                    //if the internal id already exists in the list of abilities, overwrite it.
                    if(creatureAbilities[p].InternalName == newAbility.InternalName) { position = p; }
                }
                if(position!= -1)
                {
                    if (overwrite && overwriteNoPower)
                    {
                        creatureAbilities[position] = newAbility;
                        return 2; //ability found, overwritten.
                    }
                    else if (overwrite && newAbility.OverwritePower > creatureAbilities[position].OverwritePower)
                    {
                        creatureAbilities[position] = newAbility;
                        return 2; //ability found, overwritten.
                    }
                    else { return -2; } //return -2: ability internalid found in the creature's knowledge base
                    //already, permission not granted to overwrite.
                }
            }
            //ability not found in array, must append.
            try
            {
                creatureAbilities = ArrayHandler.append(creatureAbilities, newAbility);
                return 1; //ability written to creature.
            }
            catch
            {
                return 0;
            }
        }
        public int TeachAbility(string abilityInternalID, bool overwrite = true, bool overwriteNoPower = true)
        {
            SQAbility learnAbility;
            if(SQWorld.SQWorldAbilityList.TryGetValue(abilityInternalID, out learnAbility))
            {
                return TeachAbility(learnAbility, overwrite, overwriteNoPower);
            }
            else { return -3; } //ability was not learned because it could not be found in the SQWorld Register.
        }
        public int ReplaceAbility(string replacedID, SQAbility newAbility, bool appendIfNonexist = true, bool overwriteNoPower = false)
        {
            int position = 0;
            if (creatureAbilities.Length > 0)
            {
                position = -1;
                for (int p = 0; p < creatureAbilities.Length; p++)
                {
                    //if the internal id already exists in the list of abilities, overwrite it.
                    if (creatureAbilities[p].InternalName == replacedID) { position = p; }
                }
                if (position != -1)
                {
                    if(overwriteNoPower || (newAbility.OverwritePower > creatureAbilities[position].OverwritePower))
                    {
                        creatureAbilities[position] = newAbility;
                        return 2; //ability found, overwritten.
                    }
                    return -4;
                }
            }
            //ability not found in array, must append.
            if (appendIfNonexist)
            {
                try
                {
                    creatureAbilities = ArrayHandler.append(creatureAbilities, newAbility);
                    return 1; //ability written to creature.
                }
                catch
                {
                    return 0;
                }
            }
            else { return -3; }
        }
        protected void LearnDefaultAbilities()
        {
            if(m_species.InitialAbilities.Length > 0)
            {
                for (int a = 0; a < m_species.InitialAbilities.Length; a++)
                {
                    TeachAbility(m_species.InitialAbilities[a]);
                }
            }
        }
        public SQAbility GetAbility(string abilityID)
        {
            if (creatureAbilities.Length > 0)
            {
                for (int p = 0; p < creatureAbilities.Length; p++)
                {
                    if(creatureAbilities[p].InternalName == abilityID) { return creatureAbilities[p]; }
                }
                return null; //creature does not know the searched ability.
            }
            return null; //failed to find, creature knows no abilities.
        }

        public SQAbilityInfo GetAbilityInfo(string abilityID, bool doUseAbility = true)
        {
            SQAbilityInfo info = new SQAbilityInfo();
            info.ErrorCode = SQAbilityError.didNotAttempt;
            int place = -1;
            for(int p = 0; p < creatureAbilities.Length; p++)
            {
                if(creatureAbilities[p].InternalName == abilityID)
                {
                    info.abilityType    = SQWorld.GetTrueTypes(creatureAbilities[p].AbilityType);
                    info.abilityDisplay = creatureAbilities[p].DisplayName;
                    info.doDamageTarget = creatureAbilities[p].GetDealDamageTarget(this);
                    info.doDamageSelf   = creatureAbilities[p].GetDealDamageSelf(this);
                    info.doHealTarget   = creatureAbilities[p].GetHealValueTarget(this);
                    info.doHealSelf     = creatureAbilities[p].GetHealValueSelf(this);
                    info.senderControl  = dynamic_Control;
                    info.senderAbilityMultiplier = dynamic_Attack;
                    info.senderLevel = Level;
                    info.experienceForUse = creatureAbilities[p].GetExperienceUse(this);
                    info.ErrorCode = SQAbilityError.noError;

                    if (doUseAbility)
                    {
                        double st = DoReduceStamina(creatureAbilities[p].GetStaminaCost, true);
                        if (st == creatureAbilities[p].GetStaminaCost)
                        {
                            info.ErrorCode = SQAbilityError.noError;
                            creatureAbilities[p].OnAbilityUse(this);
                        }
                        else
                        {
                            if(st == 0)
                            {
                                info.ErrorCode = SQAbilityError.notEnoughEnergy;
                            }
                        }
                    }

                    return info;
                }
            }
            return info;
        }
        public SQAbilityInfo GetAbilityInfo(string abilityID, SQCreature target, bool doUseAbility = true)
        {
            SQAbilityInfo info = new SQAbilityInfo();
            info.ErrorCode = SQAbilityError.didNotAttempt;
            int place = -1;
            for (int p = 0; p < creatureAbilities.Length; p++)
            {
                if (creatureAbilities[p].InternalName == abilityID)
                {
                    info.abilityType = SQWorld.GetTrueTypes(creatureAbilities[p].AbilityType);
                    info.abilityDisplay = creatureAbilities[p].DisplayName;
                    info.flavorText = creatureAbilities[p].GetFlavorText(this);
                    info.doDamageTarget = creatureAbilities[p].GetDealDamageTarget(this);
                    info.doDamageSelf = creatureAbilities[p].GetDealDamageSelf(this);
                    info.doHealTarget = creatureAbilities[p].GetHealValueTarget(this);
                    info.doHealSelf = creatureAbilities[p].GetHealValueSelf(this);
                    info.abilityDodgeChance = creatureAbilities[p].GetDodgeChance;
                    info.senderControl = dynamic_Control;
                    info.senderAbilityMultiplier = dynamic_Attack;
                    info.senderLevel = Level;
                    info.experienceForUse = creatureAbilities[p].GetExperienceUse(this);
                    info.ErrorCode = SQAbilityError.noError;
                    info.source = SQDamageSource.Ability;

                    if (doUseAbility)
                    {
                        double st = DoReduceStamina(creatureAbilities[p].GetStaminaCost, true);
                        if (st == creatureAbilities[p].GetStaminaCost)
                        {
                            info.ErrorCode = SQAbilityError.noError;
                            creatureAbilities[p].OnAbilityUse(this);

                            //test if target dodges
                            //implement dodge chance and evasion stat:
                            double modifiedDodgeChance = info.abilityDodgeChance * dynamic_Evade;
                            double r = Kirali.Framework.Random.Double(0, 1);
                            if (r > modifiedDodgeChance)
                            {
                                creatureAbilities[p].OnAbilityUsedOn(target);
                                info.targetDodges = false;
                            }
                            else { info.targetDodges = true; }
                                
                        }
                        else
                        {
                            if (st == 0)
                            {
                                info.ErrorCode = SQAbilityError.notEnoughEnergy;
                            }
                        }
                    }

                    return info;
                }
            }
            return info;
        }
        public SQDamageInfo DoDamage(SQAbilityInfo[] attacks, bool isTarget = true)
        {
            SQAbilityInfo[] effectPredamage = attacks;
            if (ActiveEffects.Length > 0)
            {
                for(int at = 0; at < attacks.Length; at++)
                {
                    for (int i = 0; i < ActiveEffects.Length; i++)
                    {
                        for (int stk = 0; stk < EffectsStack[i]; stk++)
                        {
                            effectPredamage[at] = ActiveEffects[i].PreDoDamage(effectPredamage[at], this);
                        }
                    }
                }
            }
            attacks = effectPredamage;



            SQDamageInfo damage = new SQDamageInfo();
            double sumDamage = 0;
            damage.failed = false;
            damage.evade = false;

            for (int attackIndex = 0; attackIndex < attacks.Length; attackIndex++)
            {
                double modify = 0.0;
                int typeTotal = 0;
                for(int typeCt = 0; typeCt < DynamicTypes.Length; typeCt++)
                {
                    //modify = attacks[attackIndex].damageType.GetModifyDamageOutgoing(m_species.UseSpeciesTypes[typeCt]);
                    SQType thisType;
                    if(SQWorld.SQWorldTypeList.TryGetValue(DynamicTypes[typeCt], out thisType))
                    {
                        double subModify = 0.0; int h = 0;
                        for(h = 0; h < attacks[attackIndex].abilityType.Length; h++)
                        {
                            subModify += thisType.GetModifyDamageIncoming(attacks[attackIndex].abilityType[h].Internal);
                        }
                        modify += (subModify / h);
                    }
                    else { modify += 1.0; }
                    
                    typeTotal++;
                }
                modify /= typeTotal;

                if (isTarget) { sumDamage += modify * attacks[attackIndex].doDamageTarget; }
                else { sumDamage += modify * attacks[attackIndex].doDamageSelf; }

                damage.effectivity = modify;
            }

            //deal damage to creature
            double damageThroughDefense = sumDamage;
            if(dynamic_Defense < sumDamage) { damageThroughDefense = sumDamage - dynamic_Defense; }
            else { damageThroughDefense = 0; }
            if(dynamic_Health > damageThroughDefense)
            {
                dynamic_Health -= damageThroughDefense;
                creatureState = SQCreatureState.Nominal;//TODO work on this more
                damage.stateAfter = SQCreatureState.Nominal;
            }
            else
            {
                dynamic_Health = 0;
                creatureState = SQCreatureState.Blackout;//TODO work on this more
                damage.stateAfter = SQCreatureState.Blackout;
            }
            damage.damageDone = damageThroughDefense;

            return damage;
        }
        public SQDamageInfo DoDamage(SQAbilityInfo attacks, bool isTarget = true)
        {
            if (isTarget)
            {
                SQAbilityInfo effectPredamage = attacks;
                if (ActiveEffects.Length > 0)
                {
                    for (int i = 0; i < ActiveEffects.Length; i++)
                    {
                        for (int stk = 0; stk < EffectsStack[i]; stk++)
                        {
                            effectPredamage = ActiveEffects[i].PreDoDamage(effectPredamage, this, false);
                        }
                    }
                }
                attacks = effectPredamage;
            }

            SQDamageInfo damage = new SQDamageInfo();
            double sumDamage = 0;
            damage.failed = false;
            //damage.evade = attacks.targetDodges;

            double modify = 0.0;
            int typeTotal = 0;
            for (int typeCt = 0; typeCt < DynamicTypes.Length; typeCt++)
            {
                //modify = attacks[attackIndex].damageType.GetModifyDamageOutgoing(m_species.UseSpeciesTypes[typeCt]);
                SQType thisType;
                if (SQWorld.SQWorldTypeList.TryGetValue(DynamicTypes[typeCt], out thisType))
                {
                    double subModify = 0.0; int h = 0;
                    for (h = 0; h < attacks.abilityType.Length; h++)
                    {
                        subModify += thisType.GetModifyDamageIncoming(attacks.abilityType[h].Internal);
                    }
                    modify += (subModify / h);
                }
                else { modify += 1.0; }

                typeTotal++;
            }
            modify /= typeTotal;

            if (isTarget) { sumDamage += modify * attacks.doDamageTarget; }
            else { sumDamage += modify * attacks.doDamageSelf; }

            damage.effectivity = modify;

            //deal damage to creature
            double damageThroughDefense = sumDamage;
            if (dynamic_Defense < sumDamage) { damageThroughDefense = sumDamage - dynamic_Defense; }
            else { damageThroughDefense = 0; }
            if (dynamic_Health > damageThroughDefense)
            {
                dynamic_Health -= damageThroughDefense;
                creatureState = SQCreatureState.Nominal;//TODO work on this more
                damage.stateAfter = SQCreatureState.Nominal;
            }
            else
            {
                dynamic_Health = 0;
                creatureState = SQCreatureState.Blackout;//TODO work on this more
                damage.stateAfter = SQCreatureState.Blackout;
            }
            damage.damageDone = damageThroughDefense;

            return damage;
        }
        public SQHealInfo DoHeal(SQAbilityInfo[] healAbility, bool isTarget = true)
        {
            SQAbilityInfo[] modified = new SQAbilityInfo[healAbility.Length];
            if (ActiveEffects.Length > 0)
            {
                for (int at = 0; at < healAbility.Length; at++)
                {
                    for (int i = 0; i < ActiveEffects.Length; i++)
                    {
                        for (int stk = 0; stk < EffectsStack[i]; stk++)
                        {
                            modified[at] = ActiveEffects[i].PreDoHeal(modified[at], this);
                        }
                    }
                }
            }
            SQHealInfo healInfo = new SQHealInfo();
            double sumHeal = 0;
            double sumStamina = 0;
            healInfo.failed = false;

            for (int abilityIndex = 0; abilityIndex < healAbility.Length; abilityIndex++)
            {
                if (isTarget)
                {
                    sumHeal += healAbility[abilityIndex].doHealTarget;
                }
                else
                {
                    sumHeal += healAbility[abilityIndex].doHealSelf;
                }
                if (isTarget)
                {
                    sumStamina += healAbility[abilityIndex].doStaminaTarget;
                }
                else
                {
                    sumStamina += healAbility[abilityIndex].doStaminaSelf;
                }

            }

            //actually heal
            if(sumHeal > 0)
            {
                if (creatureState == SQCreatureState.Blackout)
                {
                    creatureState = SQCreatureState.Nominal;
                }
                if (dynamic_Health > 0 && dynamic_Health < stat_advanceHealth)
                {
                    if(stat_advanceHealth - dynamic_Health < sumHeal)
                    {
                        sumHeal = (stat_advanceHealth - dynamic_Health);
                    }
                    dynamic_Health += sumHeal;
                }
            }
            if (sumStamina > 0)
            {
                if (dynamic_Stamina > 0 && dynamic_Stamina < stat_advanceStamina)
                {
                    if (stat_advanceStamina - dynamic_Stamina < sumStamina)
                    {
                        sumStamina = (stat_advanceStamina - dynamic_Stamina);
                    }
                    dynamic_Stamina += sumStamina;
                }
            }

            healInfo.healthHealed = sumHeal;
            return healInfo;
        }
        public SQHealInfo DoHeal(SQAbilityInfo healAbility, bool isTarget = true)
        {
            SQAbilityInfo modified = new SQAbilityInfo();
            if (ActiveEffects.Length > 0)
            {
                for (int i = 0; i < ActiveEffects.Length; i++)
                {
                    for (int stk = 0; stk < EffectsStack[i]; stk++)
                    {
                        modified = ActiveEffects[i].PreDoHeal(healAbility, this);
                    }
                }
            }
            SQHealInfo healInfo = new SQHealInfo();
            double sumHeal = 0;
            double sumStamina = 0;
            healInfo.failed = false;
            if (isTarget)
            {
                sumHeal += healAbility.doHealTarget;
            }
            else
            {
                sumHeal += healAbility.doHealSelf;
            }
            if (isTarget)
            {
                sumStamina += healAbility.doStaminaTarget;
            }
            else
            {
                sumStamina += healAbility.doStaminaSelf;
            }
            //actually heal
            if (sumHeal > 0)
            {
                if(creatureState == SQCreatureState.Blackout)
                {
                    creatureState = SQCreatureState.Nominal;
                }
                if (dynamic_Health > 0 && dynamic_Health < stat_advanceHealth)
                {
                    if (stat_advanceHealth - dynamic_Health < sumHeal)
                    {
                        sumHeal = (stat_advanceHealth - dynamic_Health);
                    }
                    dynamic_Health += sumHeal;
                }
            }
            if (sumStamina > 0)
            {
                if (dynamic_Stamina > 0 && dynamic_Stamina < stat_advanceStamina)
                {
                    if (stat_advanceStamina - dynamic_Stamina < sumStamina)
                    {
                        sumStamina = (stat_advanceStamina - dynamic_Stamina);
                    }
                    dynamic_Stamina += sumStamina;
                }
            }

            healInfo.healthHealed = sumHeal;
            return healInfo;
        }
        public double DoReduceStamina(double cost, bool allOrNothing = true)
        {
            if (cost <= dynamic_Stamina)
            {
                dynamic_Stamina -= cost;
                return cost; //stamina was reduced.
            }
            else
            {
                if (allOrNothing)
                {
                    return 0; //stamina could not be reduced because there was not enough energy.
                }
                else
                {
                    double reduced = dynamic_Stamina;
                    dynamic_Stamina -= reduced;
                    return dynamic_Stamina;
                }
            }
        }
        public void DoModifyDefense(double newValue)
        {
            if (newValue >= 0)
            {
                dynamic_Defense = newValue;
            }
        }
        public void DoModifyAttack(double newValue)
        {
            if (newValue >= 0)
            {
                dynamic_Attack = newValue;
            }
        }
        public void DoModifyStamina(double newValue)
        {
            if (newValue >= 0)
            {
                dynamic_Stamina = newValue;
            }
        }
        public void DoModifyEvade(double newValue)
        {
            if (newValue >= 0)
            {
                dynamic_Evade = newValue;
            }
        }
        public void DoModifyControl(double newValue)
        {
            if (newValue >= 0)
            {
                dynamic_Control = newValue;
            }
        }
        public virtual double GetDefeatExperience()
        {
            switch (statMod)
            {
                case "unimpressive":
                    return 600 * Level * Level;
                case "ordinary":
                    return 1000 * Level * Level;
                case "extraordinary":
                    return 2000 * Level * Level;
                case "deadly":
                    return 5000 * Level * Level;
                case "arcane":
                    return 12000 * Level * Level;
                case "mythical":
                    return 20000 * Level * Level;
                case "celestial":
                    return 32000 * Level * Level;
                default:
                    return 1000 * Level * Level;
            }
        }
        public virtual void EndCombat()
        {
            for(int staEff = 0; staEff < ActiveEffects.Length; staEff++)
            {
                if (ActiveEffects[staEff].RemoveCombatEnd) { RemoveEffect(ActiveEffects[staEff].InternalName); }
            }
        }


        //Stats and leveling
        public void TryLevelUp()
        {
            while (true)
            {
                double experienceRequired = GetRequiredExp(Level + 1);
                if (experienceAt >= experienceRequired)
                {
                    experienceAt -= experienceRequired;
                    creatureLevel++;
                    totalPointsGiven += creatureLevel;
                    FullHeal();
                    m_species.Event_LevelUp(this);
                }
                else
                {
                    break;
                }
            }
        }
        public static double GetRequiredExp(int level)
        {
            return (level - 1) * (Math.Pow(level, 3) + 1000);
        }
        public void TryUpgradeStat(SQCreatureStat stat)
        {
            if(StatPointsAvailable > 0)
            {
                switch (stat)
                {
                    case SQCreatureStat.Health:
                        stat_advanceHealth = StatUpgradeNewValue(stat_advanceHealth);
                        dynamic_Health = StatUpgradeNewValue(dynamic_Health);
                        pointsU_Health++;
                        break;
                    case SQCreatureStat.Defense:
                        stat_advanceDefense = StatUpgradeNewValue(stat_advanceDefense);
                        dynamic_Defense = StatUpgradeNewValue(dynamic_Defense);
                        pointsU_Defense++;
                        break;
                    case SQCreatureStat.Attack:
                        stat_advanceAttack = StatUpgradeNewValue(stat_advanceAttack);
                        dynamic_Attack = StatUpgradeNewValue(dynamic_Attack);
                        pointsU_Attack++;
                        break;
                    case SQCreatureStat.Stamina:
                        stat_advanceStamina = StatUpgradeNewValue(stat_advanceStamina);
                        dynamic_Stamina = StatUpgradeNewValue(dynamic_Stamina);
                        pointsU_Stamina++;
                        break;
                    case SQCreatureStat.Evade:
                        stat_advanceEvade = StatUpgradeNewValue(stat_advanceEvade);
                        dynamic_Evade = StatUpgradeNewValue(dynamic_Evade);
                        pointsU_Evade++;
                        break;
                    case SQCreatureStat.Control:
                        stat_advanceControl = StatUpgradeNewValue(stat_advanceControl);
                        dynamic_Control = StatUpgradeNewValue(dynamic_Control);
                        pointsU_Control++;
                        break;
                }
            }
            UpdateAllStatRanks();
        }
        private double StatUpgradeNewValue(double starting)
        {
            return starting * 1.05;
        }
        public SQStatUpgradeInfo CanUpgradeStats()
        {
            SQStatUpgradeInfo info;
            info.canUpgrade = false;
            info.newRank = new StatMods.Ordinary();

            SQStatMod currentStatCreature; int currentPower;
            if(SQWorld.SQWorldStatModList.TryGetValue(statMod, out currentStatCreature))
            {
                currentPower = currentStatCreature.StatModPower;
                int requiredMatch = currentPower + 1;

                //all statMods need to have greater or equal power to "requiredMatch"
                SQStatMod statHealth ;
                SQStatMod statDefense;
                SQStatMod statAttack ;
                SQStatMod statStamina;
                SQStatMod statEvade  ;
                SQStatMod statControl;

                if(    SQWorld.SQWorldStatModList.TryGetValue(statRank_Health,  out statHealth )
                    && SQWorld.SQWorldStatModList.TryGetValue(statRank_Defense, out statDefense)
                    && SQWorld.SQWorldStatModList.TryGetValue(statRank_Attack,  out statAttack )
                    && SQWorld.SQWorldStatModList.TryGetValue(statRank_Stamina, out statStamina)
                    && SQWorld.SQWorldStatModList.TryGetValue(statRank_Evade,   out statEvade  )
                    && SQWorld.SQWorldStatModList.TryGetValue(statRank_Control, out statControl))
                {
                    if(    statHealth .StatModPower >= requiredMatch
                        && statDefense.StatModPower >= requiredMatch
                        && statAttack .StatModPower >= requiredMatch
                        && statStamina.StatModPower >= requiredMatch
                        && statEvade  .StatModPower >= requiredMatch
                        && statControl.StatModPower >= requiredMatch)
                    {
                        SQStatMod[] statModList = new SQStatMod[SQWorld.SQWorldStatModList.Count];
                        SQWorld.SQWorldStatModList.Values.CopyTo(statModList, 0);
                        for (int look = 0; look < statModList.Length; look++)
                        {
                            if(statModList[look].StatModPower == requiredMatch)
                            {
                                info.newRank = statModList[look];
                                break;
                            }
                        }
                        info.canUpgrade = true; return info;
                    }
                    else { info.canUpgrade = false; return info; }
                }
                else { info.canUpgrade = false; return info; }
            }
            info.canUpgrade = false; return info;
        }
        public void GrantStatPoints(int count)
        {
            if(count > 0)
            {
                totalPointsGiven += count;
            }
        }
        public void DoLevelTo(int levelstop)
        {
            if(levelstop > Level)
            {
                while(Level < levelstop)
                {
                    double expreq = GetRequiredExp(Level + 1);
                    GiveExperience(expreq);
                }
            }
        }
        public void UpgradeRank(SQStatUpgradeInfo info)
        {
            if (info.canUpgrade)
            {
                statMod = info.newRank.InternalID;
                upgraded = true;
            }
        }
    }

    public enum SQCreatureStat
    {
        Health = 0,
        Defense = 1,
        Attack = 2,
        Stamina = 3,
        Evade = 4,
        Control = 5
    }

    public enum SQCreatureState
    {
        Dead = 0,
        Blackout = 1,
        Nominal = 2,
        Awakened = 3,
        Ghost = 4
    }

    public struct SQStatUpgradeInfo
    {
        public bool canUpgrade;
        public SQStatMod newRank;
    }

    public struct SQAbilityInfo
    {
        public SQAbilityError ErrorCode;
        public SQType[] abilityType;
        public string abilityDisplay;
        public string flavorText;
        public bool criticalHit;
        public double outgoingEffector;//TODO Add This
        public double incomingEffector;//TODO Add This
        public double doDamageTarget;
        public double doDamageSelf;
        public double doHealTarget;
        public double doHealSelf;
        public double doStaminaTarget;
        public double doStaminaSelf;
        public double abilityDodgeChance;
        public double senderControl;
        public double senderAbilityMultiplier;
        public double senderLevel;
        public double experienceForUse;
        public bool targetDodges;
        public SQDamageSource source;
    }

    public enum SQDamageSource
    {
        Ability,
        Recoil,
        Effect,
        Hazard
    }

    public struct SQDamageInfo
    {
        public bool failed;
        public bool evade;
        public double effectivity;
        public double damageDone;
        public SQCreatureState stateAfter;
    }

    public struct SQHealInfo
    {
        public bool failed;
        public double effectivity;
        public double healthHealed;
        public SQCreatureState stateAfter;
    }

    public enum SQGender
    {
        Genderless  = 0,
        Agender     = 1,
        Androgyne   = 2,
        Bigender    = 3,
        Genderfluid = 4,
        Nonbinary   = 5,
        Omnigender  = 6,
        Polygender  = 7,
        Twospirit   = 8,
        Female      = 9,
        Male        = 10
    }

    public enum SQAbilityError
    {
        didNotAttempt = -5,
        worldRegisterError = -3,
        accessPermissionError = -2,
        abilityNotLearnedError = -1,
        failed = 0,
        noError = 1,
        notEnoughEnergy = 40
    }
}
