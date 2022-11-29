using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SoliaQuestClassic.Render;

namespace SoliaQuestClassic.Render.Worlds
{
    public class PlanetWorld : RenderWorld
    {
        public static GameLevel[] Levels = new GameLevel[0];
        public static int PlanetWorldID { get { return 2; } }
        public static readonly bool ENABLE_LEVELEDITOR = true;
        private static int tilesCount = 0;
        private static int backgroundsCount = 0;

        public override void Init()
        {
            Texture2D.RegisterNew(ResourcePath + "World.Backgrounds.yikjtae_city_icemulti.png", "yikjtae_icemulti", this);
            backgroundsCount = 1;

            Texture2D.RegisterNew(ResourcePath + "World.Tiles.path_darktiles.png", "path.darktiles", this, 9, 8);
            tilesCount = 1;
            
            ActiveGameLevel = 0;
            Levels = new GameLevel[1];
            Levels[0] = new GameLevel("demo", -1, 128, 128, PlanetWorldID);
            Levels[0].Load(this);
        }

        public static int TileIDForward(int tileID)
        {
            return tileID += backgroundsCount;
        }

        public static int ActiveGameLevel = -1;
        public override void Render()
        {
            if(ActiveGameLevel < Levels.Length && ActiveGameLevel >= 0)
            {
                Levels[ActiveGameLevel].Render(MainCamera);
            }
        }

        public static void Click(int x, int y, Camera MainCamera, OpenTK.Input.MouseButtonEventArgs args)
        {
            GameLevel level = Levels[ActiveGameLevel];
            int currentEditLevel = 0;
            double screen = (double)MainCamera.Height / MainCamera.Width;

            int left  = (int)(MainCamera.position.X +  MainCamera.zoom * -0.5);
            int right = (int)(MainCamera.position.X +  MainCamera.zoom *  0.5);

            //Get tile pos at mouse
            double xpercent = (double)x / MainCamera.Width;
            double ypercent = (double)y / MainCamera.Height;
            double xrel = MainCamera.zoom * (xpercent - 0.5) * 2;
            double yrel = MainCamera.zoom * (0.5 - ypercent) * 2 * screen;
            int tile_x = (int)(MainCamera.position.X + xrel);
            int tile_y = (int)(MainCamera.position.Y + yrel);

            //place tiles if in edit mode
            if (ENABLE_LEVELEDITOR)
            {
                if(LevelEditorWindow.EDITOR_MODE == LevelEditMode.TILES_PATH)
                {
                    if(LevelEditorWindow.PLACE_TILE_MODE == TilePlacementMode.CYCLE)
                    {
                        if (tile_x < level.Width && tile_x >= 0 && tile_y < level.Height && tile_y >= 0)
                        {
                            if (args.Button == OpenTK.Input.MouseButton.Left)
                            {
                                //cycle tiles
                                Levels[currentEditLevel].pathTiles[tile_x, tile_y]++;
                                if (Levels[currentEditLevel].pathTiles[tile_x, tile_y] > 1) { Levels[currentEditLevel].pathTiles[tile_x, tile_y] = 0; }
                            }
                            if (args.Button == OpenTK.Input.MouseButton.Right)
                            {
                                //cycle tile shape
                                Levels[currentEditLevel].pathTiles_sub[tile_x, tile_y]++;
                                if (Levels[currentEditLevel].pathTiles_sub[tile_x, tile_y] >= 9 * 8) { Levels[currentEditLevel].pathTiles_sub[tile_x, tile_y] = 0; }
                            }
                        }
                    }
                    //others
                    if (LevelEditorWindow.PLACE_TILE_MODE == TilePlacementMode.AUTOMATIC)
                    {
                        //check if showing or removing
                        if (args.Button == OpenTK.Input.MouseButton.Left)
                        {
                            //cycle tiles
                            Levels[currentEditLevel].pathTiles[tile_x, tile_y]++;
                            if (Levels[currentEditLevel].pathTiles[tile_x, tile_y] > 1) { Levels[currentEditLevel].pathTiles[tile_x, tile_y] = 0; }
                            //check if adding or removing
                            if (Levels[currentEditLevel].pathTiles[tile_x, tile_y] == 0) { Levels[currentEditLevel].pathTiles_sub[tile_x, tile_y] = 0; }
                            else
                            {
                                //auto set tile shape
                                AutoPlaceTile(tile_x, tile_y, currentEditLevel, Levels[currentEditLevel].pathTiles[tile_x, tile_y], LevelEditorWindow.TILE_PREFER_SMOOTH, LevelEditorWindow.TILE_PREFER_SHARP);

                            }
                            // check surrounding
                            AutoPlaceTile(tile_x - 1, tile_y - 1, currentEditLevel, Levels[currentEditLevel].pathTiles[tile_x, tile_y], LevelEditorWindow.TILE_PREFER_SMOOTH, LevelEditorWindow.TILE_PREFER_SHARP);
                            AutoPlaceTile(tile_x + 1, tile_y - 1, currentEditLevel, Levels[currentEditLevel].pathTiles[tile_x, tile_y], LevelEditorWindow.TILE_PREFER_SMOOTH, LevelEditorWindow.TILE_PREFER_SHARP);
                            AutoPlaceTile(tile_x + 1, tile_y + 1, currentEditLevel, Levels[currentEditLevel].pathTiles[tile_x, tile_y], LevelEditorWindow.TILE_PREFER_SMOOTH, LevelEditorWindow.TILE_PREFER_SHARP);
                            AutoPlaceTile(tile_x - 1, tile_y + 1, currentEditLevel, Levels[currentEditLevel].pathTiles[tile_x, tile_y], LevelEditorWindow.TILE_PREFER_SMOOTH, LevelEditorWindow.TILE_PREFER_SHARP);
                            AutoPlaceTile(tile_x + 1, tile_y, currentEditLevel, Levels[currentEditLevel].pathTiles[tile_x, tile_y], LevelEditorWindow.TILE_PREFER_SMOOTH, LevelEditorWindow.TILE_PREFER_SHARP);
                            AutoPlaceTile(tile_x, tile_y + 1, currentEditLevel, Levels[currentEditLevel].pathTiles[tile_x, tile_y], LevelEditorWindow.TILE_PREFER_SMOOTH, LevelEditorWindow.TILE_PREFER_SHARP);
                            AutoPlaceTile(tile_x - 1, tile_y, currentEditLevel, Levels[currentEditLevel].pathTiles[tile_x, tile_y], LevelEditorWindow.TILE_PREFER_SMOOTH, LevelEditorWindow.TILE_PREFER_SHARP);
                            AutoPlaceTile(tile_x, tile_y - 1, currentEditLevel, Levels[currentEditLevel].pathTiles[tile_x, tile_y], LevelEditorWindow.TILE_PREFER_SMOOTH, LevelEditorWindow.TILE_PREFER_SHARP);

                        }
                        
                    }
                }
                
            }
            

            //Console.WriteLine("camera: " + MainCamera.position.ToString());
            //Console.WriteLine(tile_x + " " + tile_y);
            //Console.WriteLine(xrel + " " + yrel);
        }

        private static int DoTileQuery(int x, int y, int editLevel, int tileID)
        {
            // 0 no tile or tile of different type
            // 1 tile is full ( shape 0 )
            // 2 tile connects on four sides but is not "full"
            // 3 tile connects on three sides
            // 4 tile connects on two adjacent sides
            // 5 tile connects on two opposing sides
            // 6 one side connects
            // 7 no sides connect
            if(isInMapBounds(x, y, editLevel))
            {
                int typ = Levels[editLevel].pathTiles[x, y];

                if (typ == tileID)
                {
                    int shape = Levels[editLevel].pathTiles_sub[x, y];
                    if (shape == 0) { return 1; }
                    else if (shape == 9) { return 7; }
                    else if (shape == 18 || shape == 27) { return 5; }
                    else if (shape == 7 || shape == 8 || shape == 16 || shape == 17) { return 3; }
                    else if (shape == 25 || shape == 26 || shape == 34 || shape == 35) { return 6; }
                    else if (shape == 19 || shape == 20 || shape == 28 || shape == 29 ||
                        shape == 21 || shape == 22 || shape == 30 || shape == 31) { return 2; }
                    else { return 4; }
                    // 1, 2, 10, 11
                    // 3, 4, 12, 13
                    // 5, 6, 14, 15
                    // 23, 24, 32, 33
                }
                else { return 0; }
            }
            else { return 0; }
        }
        private static int[] DoTileQueryFull(int x, int y, int editLevel, int tileID)
        {
            int[] query_array = new int[8];

            query_array[0] = DoTileQuery(x - 1, y - 1, editLevel, tileID);
            query_array[1] = DoTileQuery(x + 0, y - 1, editLevel, tileID);
            query_array[2] = DoTileQuery(x + 1, y - 1, editLevel, tileID);
            query_array[3] = DoTileQuery(x + 1, y + 0, editLevel, tileID);
            query_array[4] = DoTileQuery(x + 1, y + 1, editLevel, tileID);
            query_array[5] = DoTileQuery(x + 0, y + 1, editLevel, tileID);
            query_array[6] = DoTileQuery(x - 1, y + 1, editLevel, tileID);
            query_array[7] = DoTileQuery(x - 1, y + 0, editLevel, tileID);

            return query_array;
        }
        private static bool TestRotationsEqual(int[] surround, TileAutoSetAmbiguous sample, out int orientation)
        {
            if(surround.Length == 8)
            {
                int[] q0 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
                int[] q1 = new int[] { 6, 7, 0, 1, 2, 3, 4, 5 };
                int[] q2 = new int[] { 4, 5, 6, 7, 0, 1, 2, 3 };
                int[] q3 = new int[] { 2, 3, 4, 5, 6, 7, 0, 1 };

                bool iseq0 = false;
                bool iseq1 = false;
                bool iseq2 = false;
                bool iseq3 = false;

                bool didCorr = false;

                if (sample.Correlate)
                {
                    // Correlate is more complicated because it means that the multiple-set tiles must
                    // correlate in index to one-another in order to be considered an example of the set.

                    int correlator_size = 1;

                    int[] q_length = new int[8];

                    // ALL MULTI-ENTRY SPACES MUST MUST MUST BE THE SAME LENGTH TO CORRELATE!!!!!!!!!!!
                    bool inconsistent = false;

                    q_length[0] = sample.EntryCount(0);
                    q_length[1] = sample.EntryCount(1);
                    q_length[2] = sample.EntryCount(2);
                    q_length[3] = sample.EntryCount(3);
                    q_length[4] = sample.EntryCount(4);
                    q_length[5] = sample.EntryCount(5);
                    q_length[6] = sample.EntryCount(6);
                    q_length[7] = sample.EntryCount(7);

                    for(int ix = 0; ix < q_length.Length; ix++)
                    {
                        if (q_length[ix] > 1)
                        {
                            if (correlator_size == 1) { correlator_size = q_length[ix]; }
                            else if (correlator_size == q_length[ix]) { } //good
                            else { inconsistent = true; break; }
                        }
                    }

                    if (inconsistent) { Console.WriteLine("A correlated type tileset sample was tested, but the multi entry tiles could not be correlated due to differing alternatives."); }
                    else if (correlator_size != 1 && !inconsistent)
                    {
                        // oh here's where it gets *sadface* complexicated

                        // first maybe try to see the quarter rotations tests?
                        // prob should save which ones work...
                        // here:

                        iseq0 = true;
                        iseq1 = true;
                        iseq2 = true;
                        iseq3 = true;

                        bool did_Multi_any0 = false;
                        bool did_Multi_any1 = false;
                        bool did_Multi_any2 = false;
                        bool did_Multi_any3 = false;

                        bool[] qtr_0 = new bool[correlator_size]; 
                        bool[] qtr_1 = new bool[correlator_size]; 
                        bool[] qtr_2 = new bool[correlator_size]; 
                        bool[] qtr_3 = new bool[correlator_size];

                        // set all to true for now.
                        for (int pv = 0; pv < correlator_size; pv++)
                        {
                            qtr_0[pv] = true;
                            qtr_1[pv] = true;
                            qtr_2[pv] = true;
                            qtr_3[pv] = true;
                        }

                        bool[] temp_testwork;
                        
                        // region q0
                        temp_testwork = new bool[8];
                        for (int ix = 0; ix < q0.Length; ix++)
                        {
                            int[] q_s = sample.GetValue(q0[ix]); // use quarters as pointer to sample place
                            if (q_s.Length == 1)
                            {
                                // proceed as normal
                                if( q_s[0] == surround[ix] ) { temp_testwork[ix] = true; }
                                else { temp_testwork[ix] = false; break; }
                            }
                            else
                            {
                                for (int ixa = 0; ixa < q_s.Length; ixa++)
                                {
                                    // test if NOT equal 
                                    if(q_s[ixa] == surround[ix])
                                    {
                                        qtr_0[ixa] = false;
                                    } // do nothing if they are equal.
                                }
                                // pretend it works, for now....
                                temp_testwork[ix] = true;
                            }
                        }

                        for (int a = 0; a < 8; a++)
                        {
                            if (!temp_testwork[a]) { iseq0 = false; }
                        }

                        for (int b = 0; b < correlator_size; b++)
                        {
                            if (qtr_0[b]) { did_Multi_any0 = true; break; }
                        }
                        if (!did_Multi_any0) { iseq0 = false; }
                        //phew now do this three more times

                        // region q1
                        temp_testwork = new bool[8];
                        for (int ix = 0; ix < q1.Length; ix++)
                        {
                            int[] q_s = sample.GetValue(q1[ix]); // use quarters as pointer to sample place
                            if (q_s.Length == 1)
                            {
                                // proceed as normal
                                if (q_s[0] == surround[ix]) { temp_testwork[ix] = true; }
                                else { temp_testwork[ix] = false; break; }
                            }
                            else
                            {
                                for (int ixa = 0; ixa < q_s.Length; ixa++)
                                {
                                    // test if NOT equal 
                                    if (q_s[ixa] == surround[ix])
                                    {
                                        qtr_1[ixa] = false;
                                    } // do nothing if they are equal.
                                }
                                // pretend it works, for now....
                                temp_testwork[ix] = true;
                            }
                        }

                        for (int a = 0; a < 8; a++)
                        {
                            if (!temp_testwork[a]) { iseq1 = false; }
                        }

                        for (int b = 0; b < correlator_size; b++)
                        {
                            if (qtr_1[b]) { did_Multi_any1 = true; break; }
                        }
                        if (!did_Multi_any1) { iseq1 = false; }

                        // region q2
                        temp_testwork = new bool[8];
                        for (int ix = 0; ix < q2.Length; ix++)
                        {
                            int[] q_s = sample.GetValue(q2[ix]); // use quarters as pointer to sample place
                            if (q_s.Length == 1)
                            {
                                // proceed as normal
                                if (q_s[0] == surround[ix]) { temp_testwork[ix] = true; }
                                else { temp_testwork[ix] = false; break; }
                            }
                            else
                            {
                                for (int ixa = 0; ixa < q_s.Length; ixa++)
                                {
                                    // test if NOT equal 
                                    if (q_s[ixa] == surround[ix])
                                    {
                                        qtr_2[ixa] = false;
                                    } // do nothing if they are equal.
                                }
                                // pretend it works, for now....
                                temp_testwork[ix] = true;
                            }
                        }

                        for (int a = 0; a < 8; a++)
                        {
                            if (!temp_testwork[a]) { iseq2 = false; }
                        }

                        for (int b = 0; b < correlator_size; b++)
                        {
                            if (qtr_2[b]) { did_Multi_any2 = true; break; }
                        }
                        if (!did_Multi_any2) { iseq2 = false; }

                        // region q3
                        temp_testwork = new bool[8];
                        for (int ix = 0; ix < q3.Length; ix++)
                        {
                            int[] q_s = sample.GetValue(q3[ix]); // use quarters as pointer to sample place
                            if (q_s.Length == 1)
                            {
                                // proceed as normal
                                if (q_s[0] == surround[ix]) { temp_testwork[ix] = true; }
                                else { temp_testwork[ix] = false; break; }
                            }
                            else
                            {
                                for (int ixa = 0; ixa < q_s.Length; ixa++)
                                {
                                    // test if NOT equal 
                                    if (q_s[ixa] == surround[ix])
                                    {
                                        qtr_3[ixa] = false;
                                    } // do nothing if they are equal.
                                }
                                // pretend it works, for now....
                                temp_testwork[ix] = true;
                            }
                        }

                        for (int a = 0; a < 8; a++)
                        {
                            if (!temp_testwork[a]) { iseq3 = false; }
                        }

                        for (int b = 0; b < correlator_size; b++)
                        {
                            if (qtr_3[b]) { did_Multi_any3 = true; break; }
                        }
                        if (!did_Multi_any3) { iseq3 = false; }

                        // hopefully this shitshow works ;-;
                        didCorr = true;
                    }
                    //else break into normal operation as if correlation = false;
                }
                if (!didCorr)
                {

                    // DEFAULT action, continue as if correlated didnt work :( ;-; or just correlate was off anyways

                    for (int ix = 0; ix < q0.Length; ix++)
                    {
                        int[] q_s = sample.GetValue(q0[ix]); // use quarters as pointer to sample place
                        for (int ixa = 0; ixa < q_s.Length; ixa++)
                        {
                            if (q_s[ixa] == surround[ix] || q_s[ixa] == -1) { iseq0 = true; break; }
                        }
                    }

                    for (int ix = 0; ix < q1.Length; ix++)
                    {
                        int[] q_s = sample.GetValue(q1[ix]);
                        for (int ixa = 0; ixa < q_s.Length; ixa++)
                        {
                            if (q_s[ixa] == surround[ix] || q_s[ixa] == -1) { iseq1 = true; break; }
                        }
                    }

                    for (int ix = 0; ix < q2.Length; ix++)
                    {
                        int[] q_s = sample.GetValue(q2[ix]);
                        for (int ixa = 0; ixa < q_s.Length; ixa++)
                        {
                            if (q_s[ixa] == surround[ix] || q_s[ixa] == -1) { iseq2 = true; break; }
                        }
                    }

                    for (int ix = 0; ix < q3.Length; ix++)
                    {
                        int[] q_s = sample.GetValue(q3[ix]);
                        for (int ixa = 0; ixa < q_s.Length; ixa++)
                        {
                            if (q_s[ixa] == surround[ix] || q_s[ixa] == -1) { iseq3 = true; break; }
                        }
                    }


                    
                }
                // do this whether correlated or not at the end

                orientation = -1;
                if (iseq0 && iseq2) { orientation = 0; }
                else if (iseq1 && iseq3) { orientation = 1; }
                else if (iseq0) { orientation = 0; }
                else if (iseq1) { orientation = 1; }
                else if (iseq2) { orientation = 2; }
                else if (iseq3) { orientation = 3; }

                if (iseq0 || iseq1 || iseq2 || iseq3) { return true; } else { return false; }
            }
            else
            {
                orientation = -1;
                return false;
            }
        }



        private static void AutoPlaceTile(int x, int y, int editLevel, int tileID, bool smooth_sides, bool sharp_corners)
        {
            // first is the tile within the map?
            if(isInMapBounds(x, y, editLevel))
            {
                if(Levels[editLevel].pathTiles[x, y] == tileID)
                {
                    //next we do a tile query of the surrounding tiles:
                    int[] query_s = DoTileQueryFull(x, y, editLevel, tileID);
                    int resulting = -1;

                    int rot = -1;
                    if (TestRotationsEqual(query_s, TileAutoSetAmbiguous.AloneTileQuery, out _))
                    {  // result MUST be alone tile
                        resulting = 9; // (shape 9, isolated)
                    }
                    else if (TestRotationsEqual(query_s, TileAutoSetAmbiguous.FullTileQueries, out _))
                    {  // result MUST be full tile
                        resulting = 0; // (shape 0, full tile)
                    }
                    else if (TestRotationsEqual(query_s, TileAutoSetAmbiguous.TwoSidedOppThin, out rot))
                    {  // thin line bar
                        if (rot == 0) { resulting = 17; }
                        else { resulting = 27; }
                    }
                    else if (TestRotationsEqual(query_s, TileAutoSetAmbiguous.TwoSidedAdjCutout, out rot))
                    {  // thin line bar, curved
                        if (sharp_corners)
                        {
                            if (rot == 0) { resulting = 14; }
                            else if (rot == 1) { resulting = 05; }
                            else if (rot == 1) { resulting = 06; }
                            else { resulting = 15; }
                        }
                        else
                        {
                            if (rot == 0) { resulting = 32; }
                            else if (rot == 1) { resulting = 23; }
                            else if (rot == 1) { resulting = 24; }
                            else { resulting = 33; }
                        }
                    }
                    else if (TestRotationsEqual(query_s, TileAutoSetAmbiguous.OneSidedQueries, out rot))
                    {  // one side bar
                        if (rot == 0) { resulting = 26; }
                        else if (rot == 1) { resulting = 34; }
                        else if (rot == 1) { resulting = 25; }
                        else { resulting = 35; }
                    }


                    //set tile
                    if (resulting != -1)
                    {
                        if (!smooth_sides) { resulting += 9 * 4; }
                        Levels[editLevel].pathTiles[x, y] = tileID;
                        Levels[editLevel].pathTiles_sub[x, y] = resulting;
                    }
                }
            }
        }

        private static bool isInMapBounds(int x, int y, int level)
        {
            if(y > Levels[level].Height || y < 0 || x > Levels[level].Width || x < 0)
            {
                return false;
            }
            else { return true; }
        }

        private static int[] shapes_isfull_upw = new int[] { 0, 8, 10, 11, 12, 13, 14, 15, 16, 17, 19, 20, 21, 22, 26, 27, 28, 29, 30, 31, 32, 33 } ;
        private static int[] shapes_isfull_dwn = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 16, 17, 19, 20, 21, 22, 23, 24, 25, 27, 28, 29, 30, 31 } ;
        private static int[] shapes_isfull_rih = new int[] { 0, 3, 5, 7, 8, 10, 12, 14, 16, 18, 19, 20, 21, 22, 23, 28, 29, 30, 31, 32, 34 } ;
        private static int[] shapes_isfull_lef = new int[] { 0, 2, 4, 6, 7, 8, 11, 13, 15, 17, 18, 19, 20, 21, 22, 24, 28, 29, 30, 31, 33, 35 } ;

        //sample tile groupings, put -1 wherever the shape does not matter. must be of length 8.
        //private static int[] tg_groupof_allsfulls = new int[] { -1, 1, -1, 1, -1, 1, -1, 1 };
        //private static int[] tg_groupof_oppofulls = new int[] { -1, 1, -1, 0, -1, 1, -1, 0 };
        //private static int[] tg_groupof_cornfulls = new int[] { -1, 1, -1, 1, -1, 0, -1, 0 };


    }

    public class TileAutoSetAmbiguous
    {
        public static TileAutoSetAmbiguous AloneTileQuery
        {
            get
            {
                TileAutoSetAmbiguous s = new TileAutoSetAmbiguous(
                    new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }
                    );
                return s;
            }
        }
        public static TileAutoSetAmbiguous FullTileQueries
        {
            get
            {
                TileAutoSetAmbiguous s = new TileAutoSetAmbiguous(
                    new int[] { -1, 1, -1, 1, -1, 1, -1, 1 }
                    );
                s.DeepSet(new int[] { 0, 1, 1, 1 }, 3);
                s.DeepSet(new int[] { 0, 0, 1, 0 }, 5);
                s.DeepSet(new int[] { 0, 1, 0, 0 }, 7);
                s.Correlate = true;
                return s;
            }
        }
        public static TileAutoSetAmbiguous OneSidedQueries
        {
            get
            {
                TileAutoSetAmbiguous s = new TileAutoSetAmbiguous(
                    new int[] { -1, -2, -1, 0, -1, 0, -1, 0 }
                    );
                s.DeepSet(new int[] { 4, 5, 6 }, 1);
                s.Correlate = false;
                return s;
            }
        }
        public static TileAutoSetAmbiguous TwoSidedAdjCutout
        {
            get
            {
                TileAutoSetAmbiguous s = new TileAutoSetAmbiguous(
                    new int[] { 0, -2, 0, -2, 0, 0, -1, 0 }
                    );
                s.DeepSet(new int[] { 6, 7, 9 }, 1);
                s.DeepSet(new int[] { 6, 7, 9 }, 3);
                s.Correlate = false;
                return s;
            }
        }
        public static TileAutoSetAmbiguous TwoSidedOppThin
        {
            get
            {
                TileAutoSetAmbiguous s = new TileAutoSetAmbiguous(
                    new int[] { -1, -2, -1, 0, -1, -2, -1, 0 }
                    );
                s.DeepSet(new int[] { 4, 5, 6, 7 }, 1);
                s.DeepSet(new int[] { 4, 5, 6, 7 }, 5);
                s.Correlate = false;
                return s;
            }
        }


        private void ST(int i, int pl)
        {
            if (pl >= 0 && pl < 8)
            {
                switch (pl)
                {
                    case 0: q0 = new int[] { i }; break;
                    case 1: q1 = new int[] { i }; break;
                    case 2: q2 = new int[] { i }; break;
                    case 3: q3 = new int[] { i }; break;
                    case 4: q4 = new int[] { i }; break;
                    case 5: q5 = new int[] { i }; break;
                    case 6: q6 = new int[] { i }; break;
                    case 7: q7 = new int[] { i }; break;
                }
            }
        }

        private void ST(int[] i, int pl)
        {
            if (pl >= 0 && pl < 8)
            {
                switch (pl)
                {
                    case 0: q0 = i; break;
                    case 1: q1 = i; break;
                    case 2: q2 = i; break;
                    case 3: q3 = i; break;
                    case 4: q4 = i; break;
                    case 5: q5 = i; break;
                    case 6: q6 = i; break;
                    case 7: q7 = i; break;
                }
            }
        }


        private int[] q0 = new int[1];
        private int[] q1 = new int[1];
        private int[] q2 = new int[1];
        private int[] q3 = new int[1];
        private int[] q4 = new int[1];
        private int[] q5 = new int[1];
        private int[] q6 = new int[1];
        private int[] q7 = new int[1];

        public bool Correlate = false;

        public TileAutoSetAmbiguous(int[] setDetails)
        {
            q0 = new int[] { setDetails[0] };
            q1 = new int[] { setDetails[1] };
            q2 = new int[] { setDetails[2] };
            q3 = new int[] { setDetails[3] };
            q4 = new int[] { setDetails[4] };
            q5 = new int[] { setDetails[5] };
            q6 = new int[] { setDetails[6] };
            q7 = new int[] { setDetails[7] };
        }
        public void DeepSet(int[] setDetails, int place)
        {
            if (place >= 0 && place < 8)
            {
                switch (place)
                {
                    case 0: q0 = setDetails; break;
                    case 1: q1 = setDetails; break;
                    case 2: q2 = setDetails; break;
                    case 3: q3 = setDetails; break;
                    case 4: q4 = setDetails; break;
                    case 5: q5 = setDetails; break;
                    case 6: q6 = setDetails; break;
                    case 7: q7 = setDetails; break;
                }
            }
        }
        public int[] GetValue(int place)
        {
            if (place >= 0 && place < 8)
            {
                switch (place)
                {
                    case 0: return q0;
                    case 1: return q1;
                    case 2: return q2;
                    case 3: return q3;
                    case 4: return q4;
                    case 5: return q5;
                    case 6: return q6;
                    case 7: return q7;
                }
            }
            return new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        }
        public int EntryCount(int place)
        {
            if (place >= 0 && place < 8)
            {
                switch (place)
                {
                    case 0: return q0.Length;
                    case 1: return q1.Length;
                    case 2: return q2.Length;
                    case 3: return q3.Length;
                    case 4: return q4.Length;
                    case 5: return q5.Length;
                    case 6: return q6.Length;
                    case 7: return q7.Length;
                }
            }
            return -1;
        }
    }

    public enum TileTranslateDirection
    {
        UPW,
        DWN,
        LEF,
        RIH
    }
}
