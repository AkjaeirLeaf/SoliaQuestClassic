using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Types
{
    public class Spirit : SQType
    {
        public static string GetInternal { get { return "spirit"; } }

        public Spirit()
        {
            internalName = "spirit";
            displayName = "Spirit";;

            //add modifiers to damage
            //DAMAGE INCOMING reflects the extra damage / resistance to an attack on THIS type
            AddIncomingDamageModify(Air.GetInternal      ,   1.1);
            AddIncomingDamageModify(Crystal.GetInternal  ,   1.7);
            AddIncomingDamageModify(Dark.GetInternal     ,   1.9);
            AddIncomingDamageModify(Fire.GetInternal     ,   0.7);
            AddIncomingDamageModify(Ice.GetInternal      ,   0.7);
            AddIncomingDamageModify(Light.GetInternal    ,   0.4);
            AddIncomingDamageModify(Metal.GetInternal    ,   0.3);
            AddIncomingDamageModify(Plasma.GetInternal   ,   0.4);
            AddIncomingDamageModify(Spirit.GetInternal   ,   1.0);
            AddIncomingDamageModify(Stone.GetInternal    ,   0.4);
            AddIncomingDamageModify(Typeless.GetInternal ,   1.0);
            AddIncomingDamageModify(Water.GetInternal    ,   0.8);
            
            
            
            //DAMAGE OUTGOING reflects the extra damage / loss in damage in an ability used BY this type
            AddOutgoingDamageModify(Air.GetInternal      ,   1.5);
            AddOutgoingDamageModify(Crystal.GetInternal  ,   1.8);
            AddOutgoingDamageModify(Dark.GetInternal     ,   0.4);
            AddOutgoingDamageModify(Fire.GetInternal     ,   1.5);
            AddOutgoingDamageModify(Ice.GetInternal      ,   1.5);
            AddOutgoingDamageModify(Light.GetInternal    ,   1.9);
            AddOutgoingDamageModify(Metal.GetInternal    ,   1.0);
            AddOutgoingDamageModify(Plasma.GetInternal   ,   1.9);
            AddOutgoingDamageModify(Spirit.GetInternal   ,   2.0);
            AddOutgoingDamageModify(Stone.GetInternal    ,   1.0);
            AddOutgoingDamageModify(Typeless.GetInternal ,   1.0);
            AddOutgoingDamageModify(Water.GetInternal    ,   1.5);
            
        }


        public static int RegisterSpeciesType()
        {
            //must add type image loading first.
            Spirit typeRegister = new Spirit();
            typeRegister.LoadResourceImage("SoliaQuestClassic.Resources.TypeImages.Spirit.png");
            SQWorld.Register(typeRegister);
            return 1;
        }
    }
}
