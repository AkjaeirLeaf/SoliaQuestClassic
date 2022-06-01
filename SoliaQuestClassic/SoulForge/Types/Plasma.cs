using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Types
{
    public class Plasma : SQType
    {
        public static string GetInternal { get { return "plasma"; } }

        public Plasma()
        {
            internalName = "plasma";
            displayName = "Plasma";;

            //add modifiers to damage
            //DAMAGE INCOMING reflects the extra damage / resistance to an attack on THIS type
            AddIncomingDamageModify(Air.GetInternal      ,   0.4);
            AddIncomingDamageModify(Crystal.GetInternal  ,   1.2);
            AddIncomingDamageModify(Dark.GetInternal     ,   0.5);
            AddIncomingDamageModify(Fire.GetInternal     ,   0.5);
            AddIncomingDamageModify(Ice.GetInternal      ,   0.2);
            AddIncomingDamageModify(Light.GetInternal    ,   0.7);
            AddIncomingDamageModify(Metal.GetInternal    ,   0.7);
            AddIncomingDamageModify(Plasma.GetInternal   ,   0.6);
            AddIncomingDamageModify(Spirit.GetInternal   ,   1.3);
            AddIncomingDamageModify(Stone.GetInternal    ,   0.6);
            AddIncomingDamageModify(Typeless.GetInternal ,   1.0);
            AddIncomingDamageModify(Water.GetInternal    ,   1.1);
            
            
            
            //DAMAGE OUTGOING reflects the extra damage / loss in damage in an ability used BY this type
            AddOutgoingDamageModify(Air.GetInternal      ,   1.7);
            AddOutgoingDamageModify(Crystal.GetInternal  ,   0.6);
            AddOutgoingDamageModify(Dark.GetInternal     ,   0.8);
            AddOutgoingDamageModify(Fire.GetInternal     ,   1.9);
            AddOutgoingDamageModify(Ice.GetInternal      ,   0.2);
            AddOutgoingDamageModify(Light.GetInternal    ,   1.9);
            AddOutgoingDamageModify(Metal.GetInternal    ,   0.5);
            AddOutgoingDamageModify(Plasma.GetInternal   ,   2.0);
            AddOutgoingDamageModify(Spirit.GetInternal   ,   1.7);
            AddOutgoingDamageModify(Stone.GetInternal    ,   0.5);
            AddOutgoingDamageModify(Typeless.GetInternal ,   1.0);
            AddOutgoingDamageModify(Water.GetInternal    ,   0.6);
            
        }


        public static int RegisterSpeciesType()
        {
            //must add type image loading first.
            Plasma typeRegister = new Plasma();
            typeRegister.LoadResourceImage("SoliaQuestClassic.Resources.TypeImages.Plasma.png");
            SQWorld.Register(typeRegister);
            return 1;
        }
    }
}
