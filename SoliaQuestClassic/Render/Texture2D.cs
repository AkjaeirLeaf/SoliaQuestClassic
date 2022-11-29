using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Drawing.Imaging;


using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;

namespace SoliaQuestClassic.Render
{
    public partial class Texture2D
    {
        private int handle;
        private int width, height;

        private float x;
        private float y;
        private float angle;

        private int x_sub = 1; // Tile dimensions / divisions
        private int y_sub = 1; // 

        public int Tiles_X { get { return x_sub; } }
        public int Tiles_Y { get { return y_sub; } }

        private string ResourcePath;
        private bool isCompiledResource = true;

        public int ID { get { return handle; } }
        public int Width { get { return width; } }
        public int Height { get { return height; } }

        public Texture2D(string resourcePath, string textureName, RenderWorld worldSender)
        {
            ResourcePath = resourcePath;
            isCompiledResource = true;
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream(resourcePath);
            Bitmap bmp = new Bitmap(myStream);

            handle = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, handle);

            width = bmp.Width;
            height = bmp.Height;

            BitmapData bmpData = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height, 0,
                          OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMinFilter.Nearest);

            bmp.UnlockBits(bmpData);

            worldSender.RegisterTexture(this, textureName);
        }

        private Texture2D() { }

        public static Texture2D RegisterNew(string resourcePath, string textureName, RenderWorld worldSender, int x_subdivision = 1, int y_subdivision = 1)
        {
            Texture2D t2d = new Texture2D();
            t2d.ResourcePath = resourcePath;
            t2d.isCompiledResource = true;
            t2d.x_sub = x_subdivision;
            t2d.y_sub = y_subdivision;

            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream(resourcePath);
            Bitmap bmp = new Bitmap(myStream);

            t2d.handle = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, t2d.handle);

            t2d.width = bmp.Width;
            t2d.height = bmp.Height;

            BitmapData bmpData = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height, 0,
                          OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMinFilter.Nearest);

            bmp.UnlockBits(bmpData);

            worldSender.RegisterTexture(t2d, textureName);
            return t2d;
        }

        public Texture2D(string resourcePath)
        {
            ResourcePath = resourcePath;
            isCompiledResource = true;
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream(resourcePath);
            Bitmap bmp = new Bitmap(myStream);

            handle = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, handle);

            width = bmp.Width;
            height = bmp.Height;

            BitmapData bmpData = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmpData.Width, bmpData.Height, 0,
                          OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMinFilter.Nearest);

            bmp.UnlockBits(bmpData);

        }

        public Texture2D(int Id, int Width, int Height)
        {
            handle = Id;
            width = Width;
            height = Height;
        }

        private void BindIfNot(TextureTarget target = TextureTarget.Texture2D)
        {
            //Bind Texture
            if (SQGameWindow.CurrentBoundTexture != handle)
            {
                GL.BindTexture(TextureTarget.Texture2D, handle);
                SQGameWindow.CurrentBoundTexture = handle;
            }
            GL.BindTexture(target, handle);
        }


        public virtual void Draw(int x, int y, int x_tile, int y_tile, Color tint, Camera mainCamera)
        {
            // Specifically for tiles and snapped objects
            double screen = ((double)mainCamera.Width / mainCamera.Height);

            double x_adj = x - mainCamera.position.X;
            double y_adj = y - mainCamera.position.Y;

            double x_scale = x_adj / mainCamera.zoom;
            double y_scale = y_adj / mainCamera.zoom;

            double tilescale_x = 1 / mainCamera.zoom;
            double tilescale_y = 1 / mainCamera.zoom;


            double ratio_x = (x_tile + 0) * 1.0 / x_sub;
            double   end_x = (x_tile + 1) * 1.0 / x_sub;
            double ratio_y = (y_tile + 0) * 1.0 / y_sub;
            double   end_y = (y_tile + 1) * 1.0 / y_sub;


            //Bind Texture
            BindIfNot();

            //DRAW
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(tint);

            GL.TexCoord2(ratio_x, ratio_y); GL.Vertex2(x_scale -           0, screen * (y_scale + tilescale_y));
            GL.TexCoord2(  end_x, ratio_y); GL.Vertex2(x_scale + tilescale_x, screen * (y_scale + tilescale_y));
            GL.TexCoord2(  end_x,   end_y); GL.Vertex2(x_scale + tilescale_x, screen * (y_scale - 0));
            GL.TexCoord2(ratio_x,   end_y); GL.Vertex2(x_scale -           0, screen * (y_scale - 0));

            GL.End();


        }

        public virtual void DrawAsBackground(int world_x, int world_y, Color tint, Camera mainCamera)
        {
            // Specifically for tiles and snapped objects
            double screen = ((double)mainCamera.Height / mainCamera.Width);

            double camera_L = mainCamera.position.X - mainCamera.zoom;
            double camera_R = mainCamera.position.X + mainCamera.zoom;
            double camera_T = -mainCamera.position.Y - mainCamera.zoom * screen;
            double camera_B = -mainCamera.position.Y + mainCamera.zoom * screen;

            double tile_L = camera_L / world_x;
            double tile_R = camera_R / world_x;
            double tile_T = camera_T / world_y;
            double tile_B = camera_B / world_y;


            //Bind Texture
            BindIfNot();

            //DRAW
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(tint);

            GL.TexCoord2(tile_L, tile_T); GL.Vertex2(-1,  1);
            GL.TexCoord2(tile_R, tile_T); GL.Vertex2( 1,  1);
            GL.TexCoord2(tile_R, tile_B); GL.Vertex2( 1, -1);
            GL.TexCoord2(tile_L, tile_B); GL.Vertex2(-1, -1);

            GL.End();


        }

        public virtual void Draw(Kirali.MathR.Vector2[] pointArray)
        {
            //Translations if needed
            GL.PushMatrix();
            GL.Translate(x, y, 0);
            GL.Rotate(angle, 0d, 0d, 1d);

            //Bind Texture
            BindIfNot();

            //DRAW
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(pointArray[0].X, pointArray[0].Y);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(pointArray[1].X, pointArray[1].Y);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(pointArray[2].X, pointArray[2].Y);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(pointArray[3].X, pointArray[3].Y);
            GL.End();

            GL.PopMatrix();
        }
        public virtual void Draw(Kirali.MathR.Vector2[] pointArray, Color tint)
        {
            //Translations if needed
            GL.PushMatrix();
            GL.Translate(x, y, 0);
            GL.Rotate(angle, 0d, 0d, 1d);

            //Bind Texture
            BindIfNot();

            //DRAW
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(tint);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(pointArray[0].X, pointArray[0].Y);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(pointArray[1].X, pointArray[1].Y);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(pointArray[2].X, pointArray[2].Y);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(pointArray[3].X, pointArray[3].Y);
            GL.End();

            GL.PopMatrix();
        }
        public virtual void Draw(Kirali.MathR.Vector2[] pointArray, Color tint, TextureTile tile)
        {
            //Translations if needed
            GL.PushMatrix();
            GL.Translate(x, y, 0);
            GL.Rotate(angle, 0d, 0d, 1d);

            //Bind Texture
            BindIfNot();

            //DRAW
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(tint);
            GL.TexCoord2(tile.Top_Left.X, tile.Top_Left.Y); GL.Vertex2(pointArray[0].X, pointArray[0].Y);
            GL.TexCoord2(tile.Top_Right.X, tile.Top_Right.Y); GL.Vertex2(pointArray[1].X, pointArray[1].Y);
            GL.TexCoord2(tile.Bottom_Right.X, tile.Bottom_Right.Y); GL.Vertex2(pointArray[2].X, pointArray[2].Y);
            GL.TexCoord2(tile.Bottom_Left.X, tile.Bottom_Left.Y); GL.Vertex2(pointArray[3].X, pointArray[3].Y);
            GL.End();

            GL.PopMatrix();
        }
        public virtual void Draw(Kirali.MathR.Vector2[] pointArray, TextureTile tile)
        {
            //Translations if needed
            GL.PushMatrix();
            GL.Translate(x, y, 0);
            GL.Rotate(angle, 0d, 0d, 1d);

            //Bind Texture
            BindIfNot();

            //DRAW
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(pointArray[0].X, pointArray[0].Y);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(pointArray[3].X, pointArray[3].Y);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(pointArray[2].X, pointArray[2].Y);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(pointArray[1].X, pointArray[1].Y);
            GL.End();

            GL.PopMatrix();
        }
        public virtual void Draw(Kirali.MathR.Vector2[] pointArray, Color[] colorArray, TextureTile tile)
        {
            //Translations if needed
            GL.PushMatrix();
            GL.Translate(x, y, 0);
            GL.Rotate(angle, 0d, 0d, 1d);

            //Bind Texture
            BindIfNot();

            //DRAW
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(colorArray[0]); GL.TexCoord2(tile.Top_Left.X, tile.Top_Left.Y); GL.Vertex2(pointArray[0].X, pointArray[0].Y); // TOP    -- LEFT
            GL.Color4(colorArray[1]); GL.TexCoord2(tile.Top_Right.X, tile.Top_Right.Y); GL.Vertex2(pointArray[1].X, pointArray[1].Y); // TOP    -- RIGHT
            GL.Color4(colorArray[2]); GL.TexCoord2(tile.Bottom_Right.X, tile.Bottom_Right.Y); GL.Vertex2(pointArray[2].X, pointArray[2].Y); // BOTTOM -- RIGHT
            GL.Color4(colorArray[3]); GL.TexCoord2(tile.Bottom_Left.X, tile.Bottom_Left.Y); GL.Vertex2(pointArray[3].X, pointArray[3].Y); // BOTTOM -- LEFT
            GL.End();

            //GL.PopMatrix();
        }

        public static void ClearTexture(TextureTarget target = TextureTarget.Texture2D)
        {
            GL.BindTexture(target, 0);
        }
    }

    public enum MultiTilePathType
    {

    }
}
