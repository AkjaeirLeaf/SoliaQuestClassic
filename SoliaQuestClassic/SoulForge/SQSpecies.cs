using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kirali.Framework;

namespace SoliaQuestClassic.SoulForge
{
    public partial class SQSpecies
    {
        
        private string Nspecies  = "";
        private string Ninternal = "";
        protected string description = "";
        
        protected double statHealth    = 100.0;
        protected double statDefense   =   2.0;
        protected double statAttack    =  10.0;
        protected double statStamina   =  20.0;
        protected double statEvade     =   1.0;
        protected double statControl   =   0.5;

        private string[] usespeciesTypes = new string[0];
        private string[] usestatMod = new string[0];
        private string[] usecolorMod = new string[0];

        private string[] defaultAbilities = new string[0];
        public string[] InitialAbilities { get { return defaultAbilities; } }
        protected int AddInitialAbility(SQAbility newAbility, bool overwrite = true)
        {
            int position = 0;
            if (defaultAbilities.Length > 0)
            {
                position = -1;
                for (int p = 0; p < defaultAbilities.Length; p++)
                {
                    //if the internal id already exists in the list of abilities, overwrite it.
                    if (defaultAbilities[p] == newAbility.InternalName) { position = p; }
                }
                if (position != -1)
                {
                    if (overwrite)
                    {
                        defaultAbilities[position] = newAbility.InternalName;
                        return 2; //ability found, overwritten.
                    }
                    else { return -2; } //return -2: ability internalid found in the creature's knowledge base
                    //already, permission not granted to overwrite.
                }
            }
            //ability not found in array, must append.
            try
            {
                defaultAbilities = ArrayHandler.append(defaultAbilities, newAbility.InternalName);
                return 1; //ability written to creature.
            }
            catch
            {
                return 0;
            }
        }
        protected int AddInitialAbility(string abilityInternalID, bool overwrite = true)
        {
            int position = 0;
            if (defaultAbilities.Length > 0)
            {
                position = -1;
                for (int p = 0; p < defaultAbilities.Length; p++)
                {
                    //if the internal id already exists in the list of abilities, overwrite it.
                    if (defaultAbilities[p] == abilityInternalID) { position = p; }
                }
                if (position != -1)
                {
                    if (overwrite)
                    {
                        defaultAbilities[position] = abilityInternalID;
                        return 2; //ability found, overwritten.
                    }
                    else { return -2; } //return -2: ability internalid found in the creature's knowledge base
                    //already, permission not granted to overwrite.
                }
            }
            //ability not found in array, must append.
            try
            {
                defaultAbilities = ArrayHandler.append(defaultAbilities, abilityInternalID);
                return 1; //ability written to creature.
            }
            catch
            {
                return 0;
            }
        }

        public string SpeciesName { get { return Nspecies; } }
        public string InternalName { get { return Ninternal; } }
        public string Description { get { return description; } }

        public double BaseStatHealth { get { return statHealth; } }
        public double BaseStatDefense { get { return statDefense; } }
        public double BaseStatAttack { get { return statAttack; } }
        public double BaseStatStamina { get { return statStamina; } }
        public double BaseStatEvade { get { return statEvade; } }
        public double BaseStatControl { get { return statControl; } }

        public string[] UseSpeciesTypes { get { return usespeciesTypes; } }
        public string[] UseStatMod { get { return usestatMod; } }
        public string[] UseColorMod { get { return usecolorMod; } }

        public SQSpecies()
        {
            SetValuesFill();
        }
        public SQSpecies(string speciesName, string speciesInternal)
        {
            Nspecies = speciesName;
            Ninternal = speciesInternal;
            SetValuesFill();
        }
        
        private void SetValuesFill()
        {
            
        }

        protected int ModifySpeciesReference(string speciesName, string speciesInternal)
        {
            try
            {
                Nspecies = speciesName;
                Ninternal = speciesInternal;
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int ModifyBaseStats(double health, double defense, double attack, double stamina, double evade, double control)
        {
            try
            {
                statHealth = health;
                statDefense = defense;
                statAttack = attack;
                statStamina = stamina;
                statEvade = evade;
                statControl = control;
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int ModifyUseSpeciesTypes(string[] useTypes)
        {
            if (useTypes.Length == SQWorld.GetTypesCount)
            {
                try
                {
                    usespeciesTypes = useTypes;
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        public int ModifyUseStatMod(string[] useMods)
        {
            if (useMods.Length == SQWorld.GetStatModsCount)
            {
                try
                {
                    usestatMod = useMods;
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        public int ModifyUseColorMod(string[] useMods)
        {
            if (useMods.Length == SQWorld.GetColorModsCount)
            {
                try
                {
                    usecolorMod = useMods;
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        //todo support string type reference
        public int SetSpeciesType(string typeInternal, bool enable = true)
        {
            try
            {
                if (enable)
                {
                    for (int typeSearch = 0; typeSearch < usespeciesTypes.Length; typeSearch++)
                    {
                        if (usespeciesTypes[typeSearch] == typeInternal) { Console.WriteLine("Failed to add type, type already added."); return 2; }
                    }
                    usespeciesTypes = ArrayHandler.append(usespeciesTypes, typeInternal);
                    return 1;
                }
                else
                {
                    //TODO remove type (why would you do this??)
                    return 1;
                }
            }
            catch
            {
                return 0;
            }
        }

        public int SetSpeciesType(SQType speciesType, bool enable = true)
        {
            try
            {
                if (enable)
                {
                    for (int typeSearch = 0; typeSearch < usespeciesTypes.Length; typeSearch++)
                    {
                        if (usespeciesTypes[typeSearch] == speciesType.Internal) { Console.WriteLine("Failed to add type, type already added."); return 2; }
                    }
                    usespeciesTypes = ArrayHandler.append(usespeciesTypes, speciesType.Internal);
                    return 1;
                }
                else
                {
                    //TODO remove type (why would you do this??)
                    return 1;
                }
            }
            catch
            {
                return 0;
            }
        }


        //virtuals
        public virtual SQCreature NewCreatureOf()
        {
            return new SQCreature(this);
        }


        public virtual void Event_LevelUp(SQCreature sender)
        {

        }
    }
}
