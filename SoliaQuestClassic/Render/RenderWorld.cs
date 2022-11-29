using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.Render
{
    // Render world contains texture register
    // Examples:
    // Main Menu
    // Battle
    // Planet
    // 
    public partial class RenderWorld
    {
        //Static and error handling
        public static Texture2D ErrorImage;

        //Object Storage
        private static string resourcePath = "SoliaQuestClassic.Resources.";
        public static string ResourcePath { get { return resourcePath; } }
        public Camera MainCamera;

        private int TextureStorageFill = 0;
        private string[] TextureStorageCallstrings = new string[0];
        private int[] TextureStorageCallints = new int[0];
        public Texture2D[] TextureStorage = new Texture2D[0];


        public RenderWorld()
        {
            MainCamera = new Camera();
            Init();
        }

        public RenderWorld(int width, int height)
        {
            MainCamera = new Camera(Kirali.MathR.Vector3.Zero, width, height);
            Init();
        }

        public virtual void Init()
        {
            // This is where we load all textures in!
        }

        public virtual int GetTextureID(int worldTextureID)
        {
            if(worldTextureID < TextureStorageCallints.Length || worldTextureID >= 0)
            {
                return TextureStorageCallints[worldTextureID];
            }
            else
            {
                return ErrorImage.ID;
            }
        }

        public virtual Texture2D GetTexture(int worldTextureID)
        {
            if (worldTextureID < TextureStorageCallints.Length || worldTextureID >= 0)
            {
                return TextureStorage[worldTextureID];
            }
            else
            {
                return ErrorImage;
            }
        }

        public virtual int GetTextureID(string textureName)
        {
            for(int ix = 0; ix < TextureStorageCallstrings.Length; ix++)
            {
                if(textureName == TextureStorageCallstrings[ix])
                {
                    return TextureStorageCallints[ix];
                }
            }
            return ErrorImage.ID;
        }

        public int RegisterTexture(Texture2D texture2D, string textureName)
        {
            if (TextureStorage.Length == 0)
            {
                TextureStorage = new Texture2D[] { texture2D };
                TextureStorageCallints = new int[] { texture2D.ID };
                TextureStorageCallstrings = new string[] { textureName };
            }
            else
            {
                Texture2D[] temp_texs = new Texture2D[TextureStorage.Length + 1];
                int[] temp_texs_intCall = new int[TextureStorage.Length + 1];
                string[] temp_texs_strCall = new string[TextureStorage.Length + 1];
                for (int k = 0; k < TextureStorage.Length; k++)
                {
                    temp_texs[k] = TextureStorage[k];
                    temp_texs_intCall[k] = TextureStorageCallints[k];
                    temp_texs_strCall[k] = TextureStorageCallstrings[k];

                }
                temp_texs[TextureStorage.Length] = texture2D;
                temp_texs_intCall[TextureStorage.Length] = texture2D.ID;
                temp_texs_strCall[TextureStorage.Length] = textureName;
                TextureStorage = temp_texs;
                TextureStorageCallints = temp_texs_intCall;
                TextureStorageCallstrings = temp_texs_strCall;
                TextureStorageFill++;
            }
            return 0;
        }


        public string[] TextureSearchQuery(string search, TextureRefType texture_category, out int[] refs)
        {
            string[] result_names;
            int[] result_refs;

            int counted_match = 0;

            switch (texture_category)
            {
                case TextureRefType.TILE_PATH:
                    bool doall = (search == String.Empty);
                    //first count how many
                    for (int ix = 0; ix < TextureStorageCallstrings.Length; ix++)
                    {
                        if ((TextureStorageCallstrings[ix].Contains(search) && TextureStorageCallstrings[ix].Contains("path.")) ||
                            (TextureStorageCallstrings[ix].Contains("path.") && doall))
                        {
                            counted_match++;
                        }
                    }
                    result_names = new string[counted_match];
                    result_refs = new int[counted_match];
                    // then actually enter them
                    int fillct = 0;
                    for (int ix = 0; ix < TextureStorageCallstrings.Length; ix++)
                    {
                        if ((TextureStorageCallstrings[ix].Contains(search) && TextureStorageCallstrings[ix].Contains("path.")) ||
                            (TextureStorageCallstrings[ix].Contains("path.") && doall))
                        {
                            result_names[fillct] = TextureStorageCallstrings[ix];
                            result_refs[fillct] = ix;
                            fillct++;
                        }
                    }
                    refs = result_refs;
                    return result_names;
                default:
                    refs = new int[0];
                    return new string[0];
                    break;
            }
            
        }



        // RENDERING
        public virtual void Render()
        {

        }

        // Call this when resize window or on load / reload World
        public virtual void ResizeLimits(int x, int y)
        {
            MainCamera.ModifyCameraDimensions(x, y);
        }
    }

    public enum TextureRefType
    {
        CHARACTER,
        BACK_CHAR,
        FORE_CHAR,
        TILE_PATH,
        TILE_GROUND,
        MAP_OBJECT,
        BUILDING,
        UI_ENTITY,
        TEXT,
        EFFECT,
        PARTICLE
    }
}
