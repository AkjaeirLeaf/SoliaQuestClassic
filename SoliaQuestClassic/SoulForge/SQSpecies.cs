using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using SoliaQuestClassic.IO;
using SoliaQuestClassic.Render;

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

        // MESH
        private Object3D model_default;
        public Object3D CreatureModel { get { return model_default; } set { model_default = value; hasModel = true; } }
        private bool hasModel = false;
        public Texture2D[] CreatureTextures = new Texture2D[0];
        public int RegisterTexture(Texture2D texture2D, string textureName)
        {
            if (CreatureTextures.Length == 0)
            {
                CreatureTextures = new Texture2D[] { texture2D };
            }
            else
            {
                Texture2D[] temp_texs = new Texture2D[CreatureTextures.Length + 1];
                for (int k = 0; k < CreatureTextures.Length; k++)
                {
                    temp_texs[k] = CreatureTextures[k];

                }
                temp_texs[CreatureTextures.Length] = texture2D;
                CreatureTextures = temp_texs;
            }
            return 0;
        }
        /// <summary>
        /// <tooltip>To be called on register, place model loading and texture loading here.</tooltip>
        /// </summary>
        public virtual void LoadSpeciesModel()
        {
            CreatureModel = new Object3D();

        }
        public virtual Object3D GetModel()
        {
            return CreatureModel;
        }
        public virtual Texture2D[] GetTextures()
        {
            return CreatureTextures;
        }


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

        //Render and Image Display
        private SpeciesImageReference[] species_images = new SpeciesImageReference[0];
        protected void AddSpeciesImage(string display_container = "frame", string age = "middle", string pose = "p0", string colorID = "default")
        {
            string resourcepath = "SoliaQuestClassic.Resources.CreatureImages." + InternalName + "." +
                display_container + "_" + age + "_" + pose + "_" + colorID + ".png";
            SpeciesImageReference SI_ref = new SpeciesImageReference();
            Bitmap bmp = SQWorld.LoadResourceImage(resourcepath);

            SI_ref.disp_container = display_container;
            SI_ref.age = age;
            SI_ref.pose = pose;
            SI_ref.colorID = colorID;
            SI_ref.resource_path = resourcepath;
            SI_ref.image_data = bmp;

            SpeciesImageReference[] tmp = new SpeciesImageReference[species_images.Length + 1];
            for(int ix = 0; ix < tmp.Length - 1; ix++)
            {
                tmp[ix] = species_images[ix];
            }
            tmp[species_images.Length] = SI_ref;
            species_images = tmp;
        }
        public virtual void LoadSpeciesImages()
        {

        }
        public virtual bool TryGetImage(string display_container, string age, string pose, string colorID, out SpeciesImageReference image)
        {
            for(int ix = 0; ix < species_images.Length; ix++)
            {
                if(SI_refsMatch(species_images[ix], display_container, age, pose, colorID))
                {
                    image = species_images[ix];
                    return true;
                }
            }
            image = new SpeciesImageReference();
            return false;
        }
        protected static bool SI_refsMatch(SpeciesImageReference SI_ref, string display_container, string age, string pose, string colorID)
        {
            bool ismatch = true;
            if(SI_ref.disp_container != display_container) { ismatch = false; }
            if(SI_ref.age != age) { ismatch = false; }
            if(SI_ref.pose != pose) { ismatch = false; }
            if(SI_ref.colorID != colorID) { ismatch = false; }
            return ismatch;
        }
    }

    public struct SpeciesImageReference
    {
        public string disp_container;
        public string age;
        public string pose;
        public string colorID;
        public string resource_path;
        public Bitmap image_data;
    }
}
