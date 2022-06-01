using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Types
{
    public class Typeless : SQType
    {
        public static string GetInternal { get { return "typeless"; } }

        public Typeless()
        {
            internalName = "typeless";
            displayName = "Typeless";
        }


        public static int RegisterSpeciesType()
        {
            //must add type image loading first.
            Typeless typeRegister = new Typeless();
            typeRegister.LoadResourceImage("SoliaQuestClassic.Resources.TypeImages.Typeless.png");
            SQWorld.Register(typeRegister);
            return 1;
        }
    }
}
