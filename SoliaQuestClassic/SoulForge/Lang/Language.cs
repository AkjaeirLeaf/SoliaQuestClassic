using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using SoliaQuestClassic.Render;

using Kirali.MathR;

namespace SoliaQuestClassic.SoulForge.Lang
{
    public partial class Language
    {
        protected string language_internal;
        protected int    register_id;
        protected Glyph[] glyphs_alphabetical;
        protected Glyph[] glyphs_numeric_symbols;
        protected bool lettersCanCapitalize;
        protected bool supportTinyLetters;
        public Texture2D[] texture_library = new Texture2D[5];
        protected static int lettex_ROWS_COUNT = 2; // letter glyph textures size
        protected static int lettex_COLS_COUNT = 13; 
        protected static int symtex_ROWS_COUNT = 1;
        protected static int symtex_COLS_COUNT = 1;
        // Texlib guide:
        // 0: Uppercase or default
        // 1: lowercase
        // 2: numbers and symbols
        // 3: tiny uppercase
        // 4: tiny lowercase

        public Language()
        {
            OnObjectInit();
        }


        public virtual void OnObjectInit()
        {

        }

        public virtual void BuildGlyphsets_Letters(string charline)
        {
            char[] break_ = charline.ToCharArray();
            Glyph[] glyphset = new Glyph[break_.Length];

            int row = 0;
            int col = 0;

            for(int ix = 0; ix < break_.Length; ix++)
            {
                glyphset[ix] = new Glyph();
                glyphset[ix].call = break_[ix];
                glyphset[ix].glyphName = break_[ix].ToString();
                glyphset[ix].category = GlyphType.LETTER;
                glyphset[ix].row = row;
                glyphset[ix].col = col;
                glyphset[ix].cropLeft  = 0;
                glyphset[ix].cropRight = 0;
                col++;
                if(col >= lettex_COLS_COUNT) { row++; col = 0; }

            }

            glyphs_alphabetical = glyphset;
        }

        public virtual void BuildGlyphsets_SymbolsNumeric(string charline)
        {
            char[] break_ = charline.ToCharArray();
            Glyph[] glyphset = new Glyph[break_.Length];

            int row = 0;
            int col = 0;

            for (int ix = 0; ix < break_.Length; ix++)
            {
                glyphset[ix] = new Glyph();
                glyphset[ix].call = break_[ix];
                glyphset[ix].glyphName = break_[ix].ToString();
                glyphset[ix].row = row;
                glyphset[ix].col = col;
                glyphset[ix].cropLeft = 0;
                glyphset[ix].cropRight = 0;

                if (Char.IsNumber(break_[ix]))
                {
                    glyphset[ix].category = GlyphType.NUMBER;
                }
                else if (break_[ix] == '+' || break_[ix] == '=' || break_[ix] == '-')
                {
                    glyphset[ix].category = GlyphType.SYMBOL_MATH;
                }
                else
                {
                    glyphset[ix].category = GlyphType.SYMBOL_MISC;
                }

                col++;
                if (col >= lettex_COLS_COUNT) { row++; col = 0; }

            }

            glyphs_numeric_symbols = glyphset;
        }

        public virtual bool GetGlyph(char call, out Glyph gly)
        {
            char copy = call; bool isLower = false;
            if(!Char.IsUpper(call) && Char.IsLetter(call)) { copy = Char.ToUpper(call); isLower = true; }
            for (int ix = 0; ix < glyphs_alphabetical.Length; ix++)
            {
                if (glyphs_alphabetical[ix].call == copy)
                {
                    gly = glyphs_alphabetical[ix]; if(isLower) { gly.isLowercase = true; } else { gly.isLowercase = false; }
                    return true;
                }
            }
            for (int ix = 0; ix < glyphs_numeric_symbols.Length; ix++)
            {
                if (glyphs_numeric_symbols[ix].call == call)
                {
                    gly = glyphs_numeric_symbols[ix];
                    return true;
                }
            }
            gly = new Glyph();
            return false;
        }

        public virtual void RenderGlyph(Glyph gly, int size, Point pos, Color color, Kirali.Light.Camera camera, bool uppercase = true, bool isTiny = false)
        {
            if(gly.glyphName != null)
            {
                double ratio = 2 *(double)camera.Width / camera.Height;
                double fontscale = (double)size / camera.Width;
                Vector2 pos_transpose = new Vector2(((double)pos.X / camera.Width) - 1, ((double)pos.Y / camera.Height) - 1);
                Vector2 end_pos = new Vector2(fontscale, fontscale * ratio);

                Vector2[] pts = new Vector2[] { pos_transpose, new Vector2(pos_transpose.X + end_pos.X, pos_transpose.Y),
                                            new Vector2(pos_transpose.X + end_pos.X, pos_transpose.Y + end_pos.Y), new Vector2(pos_transpose.X, pos_transpose.Y + end_pos.Y)};

                Texture2D tex;
                Vector2[] tile = GetGlyphTile(gly, uppercase, out tex, isTiny);
                //pts  = new Vector2[] { new Vector2(-1, -1), new Vector2(1, -1), new Vector2(1, 1), new Vector2(-1, 1) };
                //tile = new Vector2[] { new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0), new Vector2(0, 0) };

                //tex.Draw(pts, color);
                tex.Draw(pts, color, tile);
            }
        }

        public virtual Vector2[] GetGlyphTile(Glyph gly, bool uppercase, out Texture2D tex, bool isTinyLetter = false)
        {
            TextureTile tile;
            Vector2[] vex = new Vector2[4];
            double pos_X, pos_Y;
            double end_X, end_Y;

            // find texture
            switch (gly.category)
            {
                case GlyphType.LETTER:
                    if (lettersCanCapitalize && uppercase)
                    {
                        if (supportTinyLetters && isTinyLetter)
                        { tex = texture_library[3]; }
                        else { tex = texture_library[0]; }
                    }
                    else
                    {
                        if (supportTinyLetters && isTinyLetter)
                        { tex = texture_library[4]; }
                        else { tex = texture_library[1]; }
                    }
                    pos_X = (double)gly.col / lettex_COLS_COUNT;
                    pos_Y = (double)gly.row / lettex_ROWS_COUNT;
                    end_X = (double)(gly.col + 1) / lettex_COLS_COUNT;
                    end_Y = (double)(gly.row + 1) / lettex_ROWS_COUNT;
                    break;
                case GlyphType.NUMBER:
                case GlyphType.SYMBOL_MATH:
                case GlyphType.SYMBOL_MISC:
                    tex = texture_library[2];
                    pos_X = (double)gly.col / symtex_COLS_COUNT;
                    pos_Y = (double)gly.row / symtex_ROWS_COUNT;
                    end_X = (double)(gly.col + 1) / symtex_COLS_COUNT;
                    end_Y = (double)(gly.row + 1) / symtex_ROWS_COUNT;
                    break;
                default:
                    throw new Exception("Unexpected glyph search! No compatible glyph texture found!");
            }

            // set in vex
            vex[0] = new Vector2(pos_X, end_Y);
            vex[1] = new Vector2(end_X, end_Y);
            vex[2] = new Vector2(end_X, pos_Y);
            vex[3] = new Vector2(pos_X, pos_Y);

            // return
            return vex;
        }

        public void RegisterTexture(Texture2D tex, int slot)
        {
            if(slot >= 0 && slot < texture_library.Length)
            {
                texture_library[slot] = tex;
            }
        }

        //public static void RegisterLanguage()
        //{
        //    
        //}
    }

    public struct Glyph
    {
        public char call; 
        public string glyphName;
        public GlyphType category;
        public int row;
        public int col;
        public double cropLeft;
        public double cropRight;
        public bool isLowercase;
    }

    public enum GlyphType
    {
        LETTER,
        NUMBER,
        SYMBOL_MATH,
        SYMBOL_MISC
    }
}
