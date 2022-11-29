using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Kirali.MathR;

using SoliaQuestClassic.Render.Worlds;

namespace SoliaQuestClassic.Render
{
    public class GameLevel
    {
        private int width, height;
        public int Width { get { return width; } }
        public int Height { get { return height; } }

        public int RenderWorldPointer = -1; // Set numbers ref render world

        public Vector3 CameraSpawnPosition;


        public int BackgroundTexture = -1;
        
        public int[,] groundTiles;  // lowest texture after background
        public int[,] groundTiles_sub;
        public int[,] pathTiles;    // on top of ground tiles
        public int[,] pathTiles_sub;
        public int[,] objects_low;  // (grass or small plants)
        public int[,] objects_low_sub;
        public int[,] objects_high; // (in front of or behind player or other depending on position)
        public int[,] objects_high_sub;
        public int[,] sky;          // (things that are always in front of player)
        public int[,] sky_sub;

        // sub array refers to sub tile type;

        public int[] UI_elements0;  // (ui backgrounds and windows)
        public int[] UI_elements1;  // (ui foreground like text or buttons)

        private string level_name = "";
        public string Level_Name { get { return level_name; } }


        public GameLevel(string name, int background, int width, int height, int renderWorldMember)
        {
            level_name = name;
            BackgroundTexture = background;
            RenderWorldPointer = renderWorldMember;
            this.width  = width;
            this.height = height;

            groundTiles   = new int[width, height];
            pathTiles     = new int[width, height];
            objects_low   = new int[width, height];
            objects_high  = new int[width, height];
            sky           = new int[width, height];


            groundTiles_sub   = new int[width, height];
            pathTiles_sub     = new int[width, height];
            objects_low_sub   = new int[width, height];
            objects_high_sub  = new int[width, height];
            sky_sub           = new int[width, height];

            CameraSpawnPosition = new Vector3(width / 2, height / 2, 0);

            Construct();
        }

        public void Load(RenderWorld world)
        {
            world.MainCamera.position = CameraSpawnPosition;
        }

        public void Export(string path)
        {

        }


        public void Construct()
        {
            // Build the level here!
            BackgroundTexture = 0;

            
        }


        public void Render(Camera MainCamera)
        {
            RenderWorld world = SQGameWindow.GetRenderWorld(RenderWorldPointer);
            Color tint = Color.White;

            if (BackgroundTexture >= 0)
            {
                Texture2D back = world.GetTexture(BackgroundTexture);
                back.DrawAsBackground(Width, Height, tint, MainCamera);
            }

            for(int y = 0; y < Height; y++)
            {
                for(int x = 0; x < Width; x++)
                {
                    if (pathTiles[x, y] > 0)
                    {
                        Texture2D tile = world.GetTexture(PlanetWorld.TileIDForward(pathTiles[x, y] - 1));
                        int remains = pathTiles_sub[x, y];
                        int tile_x = 0;
                        int tile_y = 0;
                        while (remains >= tile.Tiles_X)
                        {
                            remains -= tile.Tiles_X;
                            tile_y++;
                        }
                        tile_x = remains;
                        tile.Draw(x, y, tile_x, tile_y, tint, MainCamera);
                    }
                }
            }




        }



        //MOD

        public void ModifyLevelName(string newName)
        {
            level_name = newName;
        }
    }
}
