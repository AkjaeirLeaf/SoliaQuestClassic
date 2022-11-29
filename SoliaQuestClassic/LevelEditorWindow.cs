using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SoliaQuestClassic.Render;
using SoliaQuestClassic.Render.Worlds;

namespace SoliaQuestClassic
{
    public partial class LevelEditorWindow : Form
    {
        public static LevelEditMode EDITOR_MODE = LevelEditMode.TILES_PATH;
        public static TilePlacementMode PLACE_TILE_MODE = TilePlacementMode.SPECIFY;

        public static bool TILE_PREFER_SMOOTH = true;
        public static bool TILE_PREFER_SHARP  = false;

        public string[] SearchBox_Strings;
        public int[] SearchBox_IDs;
        public bool DoUpdateSearchList = false;

        public LevelEditorWindow()
        {
            InitializeComponent();
            EDITOR_MODE = LevelEditMode.TILES_PATH;
            PLACE_TILE_MODE = TilePlacementMode.AUTOMATIC;

            //setup ui props
            CurrentLayerBox.Items.Clear();
            CurrentLayerBox.Items.Add("Ground Tiles");
            CurrentLayerBox.Items.Add("Path Tiles");
            CurrentLayerBox.SelectedIndex = 0;

            if (TILE_PREFER_SMOOTH) { SmoothSidesRadio.Checked = true; RoughSidesRadio.Checked = false; }
            if (!TILE_PREFER_SHARP) { SmoothCornersRadioBuutton.Checked = true; SharpCornersRadioButton.Checked = false; }


        }

        private void CurrentLayerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CurrentLayerBox.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    EDITOR_MODE = LevelEditMode.TILES_PATH;
                    SearchBox_Strings = SQGameWindow.planet_levels.TextureSearchQuery(ObjectSearchBox.Text, TextureRefType.TILE_PATH, out SearchBox_IDs);
                    DoUpdateSearchList = true;

                    break;
                default:
                    break;
            }

            if (DoUpdateSearchList)
            {
                SelectObjectListBox.Items.Clear();
                if (SearchBox_IDs.Length > 0 && SearchBox_Strings.Length > 0)
                {
                    for (int ix = 0; ix < SearchBox_IDs.Length; ix++)
                    {
                        SelectObjectListBox.Items.Add(SearchBox_IDs[ix] + ": " + SearchBox_Strings[ix]);
                    }
                }
                DoUpdateSearchList = false;
            }
        }

        private void SmoothCornersRadioBuutton_CheckedChanged(object sender, EventArgs e)
        {
            if(TILE_PREFER_SHARP) { SharpCornersRadioButton.Checked = false; TILE_PREFER_SHARP = false; }
        }

        private void SharpCornersRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!TILE_PREFER_SHARP) { SmoothCornersRadioBuutton.Checked = false; TILE_PREFER_SHARP = true; }
        }

        private void SmoothSidesRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (!TILE_PREFER_SMOOTH) { RoughSidesRadio.Checked = false; TILE_PREFER_SMOOTH = true; }
        }

        private void RoughSidesRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (TILE_PREFER_SMOOTH) { SmoothSidesRadio.Checked = false; TILE_PREFER_SMOOTH = false; }
        }

        private void SelectObjectListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (EDITOR_MODE)
            {

                default:
                    break;
            }
        }
    }

    public enum LevelEditMode
    {
        TILES_PATH
    }

    public enum TilePlacementMode
    {
        CYCLE,
        SPECIFY,
        AUTOMATIC
    }

}
