using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;
using System.IO;

using Kirali.Framework;


namespace SoliaQuestClassic.SoulForge
{
    public class SQWorld
    {
        //species types list
        private static Dictionary<string, SQType> typeList = new Dictionary<string, SQType>();
        public static Dictionary<string, SQType> SQWorldTypeList
        {
            get { return typeList; }
        }
        public static int GetTypesCount { get { return typeList.Count; } }
        private static string[] typesNames = new string[0];
        public static string[] TypesNames { get { return typesNames; } }


        //ability list
        private static Dictionary<string, SQAbility> abilityList = new Dictionary<string, SQAbility>();
        public static Dictionary<string, SQAbility> SQWorldAbilityList
        {
            get { return abilityList; }
        }
        public static int GetAbilitiesCount { get { return abilityList.Count; } }
        private static string[] abilityNames = new string[0];
        public static string[] AbilityNames { get { return abilityNames; } }


        //stat mod list
        private static Dictionary<string, SQStatMod> statModList = new Dictionary<string, SQStatMod>();
        public static Dictionary<string, SQStatMod> SQWorldStatModList
        {
            get { return statModList; }
        }
        public static int GetStatModsCount { get { return statModList.Count; } }
        private static string[] statModsNames = new string[0];
        public static string[] StatModsNames { get { return statModsNames; } }


        //color mod list
        private static Dictionary<string, SQColorMod> colorModList = new Dictionary<string, SQColorMod>();
        public static Dictionary<string, SQColorMod> SQWorldColorModList
        {
            get { return colorModList; }
        }
        public static int GetColorModsCount { get { return colorModList.Count; } }
        private static string[] colorModsNames = new string[0];
        public static string[] ColorModsNames { get { return colorModsNames; } }


        //item families
        private static Dictionary<int, SQItemFamily> itemFamilyList = new Dictionary<int, SQItemFamily>();
        public static Dictionary<int, SQItemFamily> SQWorlditemFamilyList
        {
            get { return itemFamilyList; }
        }
        public static int GetitemFamilyCount { get { return itemFamilyList.Count; } }
        private static int[] itemFamilyIDs = new int[0];
        public static int[] ItemFamilyIDs { get { return itemFamilyIDs; } }


        //species list dictionaries
        private static Dictionary<string, SQSpecies> speciesList = new Dictionary<string, SQSpecies>();
        public static Dictionary<string, SQSpecies> SQWorldSpeciesList
        {
            get { return speciesList; }
        }
        private static string[] speciesInternals;

        public static SQType[] GetTrueTypes(string[] internals)
        {
            SQType[] typesReal = new SQType[internals.Length];
            int failed = 0;
            for(int p = 0; p < internals.Length; p++)
            {
                if (!SQWorldTypeList.TryGetValue(internals[p], out typesReal[p - failed])) { failed++; }
            }
            if(failed > 0)
            {
                SQType[] reduced = new SQType[internals.Length - failed];
                for (int p = 0; p < (internals.Length - failed); p++)
                {
                    reduced[p] = typesReal[p];
                }
                return reduced;
            }
            else
            {
                return typesReal;
            }
        }

        private static void WriteAllResources()
        {
            string[] names = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            for (int o = 0; o < names.Length; o++)
            {
                Console.WriteLine(names[o]);
            }
        }

        public static void AllocSetupAll()
        {
            WriteAllResources();

            //Register Types
            Types.Air.RegisterSpeciesType();
            Types.Crystal.RegisterSpeciesType();
            Types.Dark.RegisterSpeciesType();
            Types.Fire.RegisterSpeciesType();
            Types.Ice.RegisterSpeciesType();
            Types.Light.RegisterSpeciesType();
            Types.Metal.RegisterSpeciesType();
            Types.Plasma.RegisterSpeciesType();
            Types.Spirit.RegisterSpeciesType();
            Types.Stone.RegisterSpeciesType();
            Types.Typeless.RegisterSpeciesType();
            Types.Water.RegisterSpeciesType();

            //Register Creature Abilities
            Abilities.UseItem.RegisterAbility();
            Abilities.Scratch.RegisterAbility();

            Abilities.Swish.RegisterAbility();

            Abilities.Mirror.RegisterAbility();

            Abilities.CrystalTalon.RegisterAbility();
            Abilities.PrismSlash.RegisterAbility();
            Abilities.Opalium.RegisterAbility();
            Abilities.Shatter.RegisterAbility();
            Abilities.CrystalStorm.RegisterAbility();

            //Register Stat Modifiers
            StatMods.Ordinary.RegisterStatMod();
            StatMods.Unimpressive.RegisterStatMod();
            StatMods.Extraordinary.RegisterStatMod();
            StatMods.Deadly.RegisterStatMod();
            StatMods.Arcane.RegisterStatMod();
            StatMods.Mythical.RegisterStatMod();
            StatMods.Celestial.RegisterStatMod();

            //Register Color Modifiers
            ColorMods.Default.RegisterColorMod();
            ColorMods.Unusual.RegisterColorMod();
            ColorMods.Leucistic.RegisterColorMod();
            ColorMods.Vibrant.RegisterColorMod();
            ColorMods.Negative.RegisterColorMod();
            ColorMods.Prismatic.RegisterColorMod();
            ColorMods.Cosmic.RegisterColorMod();

            //register item families :)
            ItemFamilies.Unitemized.Register();
            ItemFamilies.HealingItems.Register();
            ItemFamilies.FoodItems.Register();

            //Register Species (do this last :))
            Species.Acyltri.RegisterSpecies();
            Species.AvieaDer.RegisterSpecies();
            Species.Silvertail.RegisterSpecies();
        }

        public static int Register(SQSpecies species)
        {
            try
            {
                speciesList.Add(species.InternalName, species); 
                speciesInternals = ArrayHandler.append(speciesInternals, species.InternalName);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public static int Register(SQType newtype)
        {
            try
            {
                typeList.Add(newtype.Internal, newtype);
                typesNames = ArrayHandler.append(typesNames, newtype.Internal);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public static int Register(SQAbility ability)
        {
            try
            {
                abilityList.Add(ability.InternalName, ability);
                abilityNames = ArrayHandler.append(abilityNames, ability.InternalName);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public static int Register(SQStatMod statMod)
        {
            try
            {
                statModList.Add(statMod.InternalID, statMod);
                statModsNames = ArrayHandler.append(statModsNames, statMod.InternalID);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public static int Register(SQColorMod colorMod)
        {
            try
            {
                colorModList.Add(colorMod.InternalID, colorMod);
                colorModsNames = ArrayHandler.append(ColorModsNames, colorMod.InternalID);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public static int Register(SQItemFamily itemFamily)
        {
            try
            {
                itemFamilyList.Add(itemFamily.FamilyID, itemFamily);
                itemFamilyIDs = ArrayHandler.append(itemFamilyIDs, itemFamily.FamilyID);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        //item searches:
        public static SQItem GetItem(int familyID, int itemID)
        {
            SQItemFamily family;
            if(SQWorlditemFamilyList.TryGetValue(familyID, out family))
            {
                SQItem result = family.TryGetItem(itemID);
                if(result == null)
                {
                    return GetItem(0, 0);
                }
                else { return result; }
            }
            else
            {
                //hmmm
                return GetItem(0, 0);
            }
        }


        //image grabbing
        public static Bitmap LoadResourceImage(string resourcePath)
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream(resourcePath);
            Bitmap image = new Bitmap(myStream);
            return image;
        }


        public SQWorld()
        {

        }

    }
}
