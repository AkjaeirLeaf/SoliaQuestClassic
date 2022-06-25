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


        //REGISTRATION
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
            Abilities.BlankStare.RegisterAbility();
            Abilities.UseItem.RegisterAbility();
            Abilities.Scratch.RegisterAbility();
            Abilities.ScratchII.RegisterAbility();

            Abilities.Swish.RegisterAbility();

            Abilities.Torch.RegisterAbility();
            Abilities.Stunlight.RegisterAbility();
            Abilities.Mirage.RegisterAbility();
            Abilities.Mirror.RegisterAbility();
            Abilities.Source.RegisterAbility();

            Abilities.CrystalTalon.RegisterAbility();
            Abilities.PrismSlash.RegisterAbility();
            Abilities.Opalium.RegisterAbility();
            Abilities.Opalescence.RegisterAbility();
            Abilities.OpaliumUltimatum.RegisterAbility();
            Abilities.Shatter.RegisterAbility();
            Abilities.CrystalStorm.RegisterAbility();

            Abilities.Infinity.RegisterAbility();

            Abilities.CryonicBlast.RegisterAbility();

            Abilities.RockArmor.RegisterAbility();

            Abilities.Brush.RegisterAbility();
            Abilities.Whisper.RegisterAbility();
            Abilities.Curse.RegisterAbility();
            Abilities.Haunt.RegisterAbility();
            Abilities.StarPath.RegisterAbility();
            Abilities.Sacrifice.RegisterAbility();
            Abilities.PrismTrap.RegisterAbility();
            Abilities.Blessing.RegisterAbility();
            Abilities.SharedFate.RegisterAbility();
            Abilities.Shell.RegisterAbility();
            Abilities.Rebirth.RegisterAbility();

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
            Species.TrainingDummy.RegisterSpecies();
            Species.Acyltri.RegisterSpecies();
            Species.AvieaDer.RegisterSpecies();
            Species.DaecaserDer.RegisterSpecies();
            Species.EaltaeQhota.RegisterSpecies();
            Species.NoctaelQhota.RegisterSpecies();
            Species.Silvertail.RegisterSpecies();
            Species.Ufim.RegisterSpecies();
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
        private static void WriteAllResources()
        {
            string[] names = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            for (int o = 0; o < names.Length; o++)
            {
                Console.WriteLine(names[o]);
            }
        }
        public static Bitmap LoadResourceImage(string resourcePath)
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream(resourcePath);
            Bitmap image = new Bitmap(myStream);
            return image;
        }


        //calculations stuff
        public static string C_FindMostEffective(string[] CreatureSenderTypes, string[] CreatureTargetTypes, int typesCt = 1)
        {
            double max = -1;
            string maxs = "";
            switch (typesCt)
            {
                case 1:
                    for (int y = 0; y < SQWorld.TypesNames.Length; y++)
                    {
                        double eff = SQWorld.C_AbilityEffective(CreatureSenderTypes, new string[] { SQWorld.TypesNames[y] }, CreatureTargetTypes);
                        if (eff > max) { max = eff; maxs = SQWorld.TypesNames[y] + " effectiveness: " + max; }
                    }
                    break;
                case 2:
                    for (int x = 0; x < SQWorld.TypesNames.Length; x++)
                    {
                        for (int y = 0; y < SQWorld.TypesNames.Length; y++)
                        {
                            if (x != y)
                            {
                                double eff = SQWorld.C_AbilityEffective(CreatureSenderTypes, new string[] { SQWorld.TypesNames[x], SQWorld.TypesNames[y] }, CreatureTargetTypes);
                                if (eff > max) { max = eff; maxs = SQWorld.TypesNames[x] + "/" + SQWorld.TypesNames[y] + " effectiveness: " + max; }

                            }
                        }
                    }
                    break;
                case 3:
                    for (int w = 0; w < SQWorld.TypesNames.Length; w++)
                    {
                        for (int x = 0; x < SQWorld.TypesNames.Length; x++)
                        {
                            for (int y = 0; y < SQWorld.TypesNames.Length; y++)
                            {
                                if (x != w && x != y && w != y)
                                {
                                    double eff = SQWorld.C_AbilityEffective(CreatureSenderTypes, new string[] { SQWorld.TypesNames[w], SQWorld.TypesNames[x], SQWorld.TypesNames[y] }, CreatureTargetTypes);
                                    if (eff > max) { max = eff; maxs = SQWorld.TypesNames[w] + "/" + SQWorld.TypesNames[x] + "/" + SQWorld.TypesNames[y] + " effectiveness: " + max; }

                                }
                            }
                        }
                    }
                    break;
                default:
                    for (int y = 0; y < SQWorld.TypesNames.Length; y++)
                    {
                        double eff = SQWorld.C_AbilityEffective(CreatureSenderTypes, new string[] { SQWorld.TypesNames[y] }, CreatureTargetTypes);
                        if (eff > max) { max = eff; maxs = SQWorld.TypesNames[y] + " effectiveness: " + max; }
                    }
                    break;
            }
            return maxs;

            //on its own, crystal is most effective
            // 2 types: crystal / dark
            // 3 types: crystal / dark / spirit
        }
        public static double C_AbilityEffective(string[] typesSender, string[] typesAbility, string[] typesTarget)
        {
            if (typesSender.Length > 0)
            {
                //list each type here, then compare to provided sender type
                double modify = 0.0;
                int totalDiv = 0;
                for (int totalSend = 0; totalSend < typesSender.Length; totalSend++)
                {
                    SQType thisType;
                    if (SQWorld.SQWorldTypeList.TryGetValue(typesSender[totalSend], out thisType))
                    {
                        //cycle through ability's types for effectiveness comparison
                        for (int subTypes = 0; subTypes < typesAbility.Length; subTypes++)
                        {
                            //modify += effectorsOf[subTypes] * thisType.GetModifyDamageOutgoing(actionType[subTypes]);
                            modify += 1 * thisType.GetModifyDamageOutgoing(typesAbility[subTypes]);
                            totalDiv++;
                        }
                    }
                    else { modify += 1.0; totalDiv += 1; }
                }
                double avgMod = modify / totalDiv;


                //incoming

                double modify2 = 0.0;
                int typeTotal = 0;
                for (int typeCt = 0; typeCt < typesTarget.Length; typeCt++)
                {
                    //modify = attacks[attackIndex].damageType.GetModifyDamageOutgoing(m_species.UseSpeciesTypes[typeCt]);
                    SQType thisType;
                    if (SQWorld.SQWorldTypeList.TryGetValue(typesTarget[typeCt], out thisType))
                    {
                        double subModify = 0.0; int h = 0;
                        for (h = 0; h < typesAbility.Length; h++)
                        {
                            subModify += thisType.GetModifyDamageIncoming(typesAbility[h]);
                        }
                        modify2 += (subModify / h);
                    }
                    else { modify2 += 1.0; }

                    typeTotal++;
                }
                modify2 /= typeTotal;

                return avgMod * modify2;
            }
            else
            {
                return 1.0;
            }
        }

        //Pronounssss
        public enum PronounType
        {
            Subject,
            Object,
            PossessiveAdj,
            Possessive,
            Reflexive
        }
        public static string GetPronoun(SQGender gender, PronounType pronounType)
        {
            if(pronounType == PronounType.Subject)
            {
                switch (gender)
                {
                    case SQGender.Genderless:
                    return "they";
                    case SQGender.Agender:
                    return "they";
                    case SQGender.Androgyne:
                    return "they";
                    case SQGender.Bigender:
                    return "they";
                    case SQGender.Genderfluid:
                    return "they";
                    case SQGender.Nonbinary:
                    return "they";
                    case SQGender.Omnigender:
                    return "they";
                    case SQGender.Polygender:
                    return "they";
                    case SQGender.Twospirit:
                    return "they";
                    case SQGender.Female:
                    return "her";
                    case SQGender.Male:
                    return "he";
                    default:
                    return "they";
                }
            }
            else if (pronounType == PronounType.Object)
            {
                switch (gender)
                {
                    case SQGender.Genderless:
                    return "them";
                    case SQGender.Agender:
                    return "them";
                    case SQGender.Androgyne:
                    return "them";
                    case SQGender.Bigender:
                    return "them";
                    case SQGender.Genderfluid:
                    return "them";
                    case SQGender.Nonbinary:
                    return "them";
                    case SQGender.Omnigender:
                    return "them";
                    case SQGender.Polygender:
                    return "them";
                    case SQGender.Twospirit:
                    return "them";
                    case SQGender.Female:
                    return "her";
                    case SQGender.Male:
                    return "him";
                    default:
                    return "them";
                }
            }
            else if (pronounType == PronounType.PossessiveAdj)
            {
                switch (gender)
                {
                    case SQGender.Genderless:
                    return "their";
                    case SQGender.Agender:
                    return "their";
                    case SQGender.Androgyne:
                    return "their";
                    case SQGender.Bigender:
                    return "their";
                    case SQGender.Genderfluid:
                    return "their";
                    case SQGender.Nonbinary:
                    return "their";
                    case SQGender.Omnigender:
                    return "their";
                    case SQGender.Polygender:
                    return "their";
                    case SQGender.Twospirit:
                    return "their";
                    case SQGender.Female:
                    return "her";
                    case SQGender.Male:
                    return "his";
                    default:
                    return "their";
                }
            }
            else if (pronounType == PronounType.Possessive)
            {
                switch (gender)
                {
                    case SQGender.Genderless:
                    return "theirs";
                    case SQGender.Agender:
                    return "theirs";
                    case SQGender.Androgyne:
                    return "theirs";
                    case SQGender.Bigender:
                    return "theirs";
                    case SQGender.Genderfluid:
                    return "theirs";
                    case SQGender.Nonbinary:
                    return "theirs";
                    case SQGender.Omnigender:
                    return "theirs";
                    case SQGender.Polygender:
                    return "theirs";
                    case SQGender.Twospirit:
                    return "theirs";
                    case SQGender.Female:
                    return "hers";
                    case SQGender.Male:
                    return "his";
                    default:
                    return "theirs";
                }
            }
            else //(pronounType == PronounType.Reflexive)
            {
                switch (gender)
                {
                    case SQGender.Genderless:
                    return "themself";
                    case SQGender.Agender:
                    return "themself";
                    case SQGender.Androgyne:
                    return "themself";
                    case SQGender.Bigender:
                    return "themself";
                    case SQGender.Genderfluid:
                    return "themself";
                    case SQGender.Nonbinary:
                    return "themself";
                    case SQGender.Omnigender:
                    return "themself";
                    case SQGender.Polygender:
                    return "themself";
                    case SQGender.Twospirit:
                    return "themself";
                    case SQGender.Female:
                    return "herself";
                    case SQGender.Male:
                    return "himself";
                    default:
                    return "themself";
                }
            }
            
        }


        public SQWorld()
        {

        }

    }
}
