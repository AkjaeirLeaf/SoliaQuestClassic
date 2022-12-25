using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SoliaQuestClassic.IO;
using SoliaQuestClassic.Render;
using SoliaQuestClassic.SoulForge;
using SoliaQuestClassic.SoulForge.Types;

namespace SoliaQuestClassic.SoulForge.Species
{
    public class Qesota : SQSpecies
    {
        public Qesota()
        {
            //Set creature ref and name
            ModifySpeciesReference("Qesota", "qesota");

            //Set creature type
            SetSpeciesType("spirit");
            SetSpeciesType("air");

            //Set base stats
            statHealth  = 210.0;
            statDefense =  10.0;
            statAttack  =   1.1;
            statStamina =  44.0;
            statEvade   =   2.8;
            statControl =   0.5;

            //add initially known abilities:
            AddInitialAbility("useItem");
            AddInitialAbility("haunt");

            //Setup which stat / color mods options to use



        }

        public override void Event_LevelUp(SQCreature sender)
        {
            switch (sender.Level)
            {
                case 3:
                    
                    break;
                case 5:
                    
                    break;
                case 10:
                    
                    break;
                default:

                    break;
            }

            base.Event_LevelUp(sender);
        }

        public override void LoadSpeciesModel()
        {
            if (SQGameWindow.DEBUG_MODELSFROMRESOURCE)
            {
                CreatureModel = Object3D.FromJsonResource(RenderWorld.ResourcePath + "Creatures.qesota.default.sqcj");
            }
            else
            {
                CreatureModel = Object3D.FromJsonExternal("external_models\\" + InternalName + "_mesh\\default.sqcj");
            }
            
            LoadSpeciesImages();
        }

        public override void LoadSpeciesImages()
        {
            SQSpecies species;
            if (SQWorld.SQWorldSpeciesList.TryGetValue(InternalName, out species))
            {
                Texture2D.RegisterNew(RenderWorld.ResourcePath + "Creatures.qesota.color_default.png",   "species_qesota_tex_def", species);
                Texture2D.RegisterNew(RenderWorld.ResourcePath + "Creatures.qesota.color_vibrant.png",   "species_qesota_tex_vib", species);
                Texture2D.RegisterNew(RenderWorld.ResourcePath + "Creatures.qesota.color_unusual.png",   "species_qesota_tex_unu", species);
                Texture2D.RegisterNew(RenderWorld.ResourcePath + "Creatures.qesota.color_leucistic.png", "species_qesota_tex_leu", species);
                Texture2D.RegisterNew(RenderWorld.ResourcePath + "Creatures.qesota.color_negative.png",  "species_qesota_tex_neg", species);
                Texture2D.RegisterNew(RenderWorld.ResourcePath + "Creatures.qesota.color_prismatic.png", "species_qesota_tex_pri", species);
                Texture2D.RegisterNew(RenderWorld.ResourcePath + "Creatures.qesota.color_cosmic.png",    "species_qesota_tex_cos", species);
            }
        }

        public static int RegisterSpecies()
        {
            SQWorld.Register(new Qesota());
            return 1;
        }


        public override SQCreature NewCreatureOf()
        {
            return new SQCreature(new Qesota());
        }
    }
}
