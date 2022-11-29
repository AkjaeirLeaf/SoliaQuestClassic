using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Types
{
    public class Water : SQType
    {
        public static string GetInternal { get { return "water"; } }

        public Water()
        {
            internalName = "water";
            displayName = "Water";;

            //add modifiers to damage
            //DAMAGE INCOMING reflects the extra damage / resistance to an attack on THIS type
            AddIncomingDamageModify(Air.GetInternal      ,   0.5);
            AddIncomingDamageModify(Crystal.GetInternal  ,   1.4);
            AddIncomingDamageModify(Dark.GetInternal     ,   0.6);
            AddIncomingDamageModify(Fire.GetInternal     ,   0.7);
            AddIncomingDamageModify(Ice.GetInternal      ,   0.9);
            AddIncomingDamageModify(Light.GetInternal    ,   1.1);
            AddIncomingDamageModify(Metal.GetInternal    ,   1.5);
            AddIncomingDamageModify(Plant.GetInternal    ,   1.5);
            AddIncomingDamageModify(Plasma.GetInternal   ,   1.2);
            AddIncomingDamageModify(Spirit.GetInternal   ,   1.2);
            AddIncomingDamageModify(Stone.GetInternal    ,   1.1);
            AddIncomingDamageModify(Toxic.GetInternal    ,   1.4);
            AddIncomingDamageModify(Typeless.GetInternal ,   1.0);
            AddIncomingDamageModify(Water.GetInternal    ,   0.6);
            
            
            
            //DAMAGE OUTGOING reflects the extra damage / loss in damage in an ability used BY this type
            AddOutgoingDamageModify(Air.GetInternal      ,   1.2);
            AddOutgoingDamageModify(Crystal.GetInternal  ,   0.9);
            AddOutgoingDamageModify(Dark.GetInternal     ,   0.6);
            AddOutgoingDamageModify(Fire.GetInternal     ,   0.1);
            AddOutgoingDamageModify(Ice.GetInternal      ,   0.9);
            AddOutgoingDamageModify(Light.GetInternal    ,   1.3);
            AddOutgoingDamageModify(Metal.GetInternal    ,   0.7);
            AddOutgoingDamageModify(Plant.GetInternal    ,   0.3);
            AddOutgoingDamageModify(Plasma.GetInternal   ,   0.3);
            AddOutgoingDamageModify(Spirit.GetInternal   ,   1.4);
            AddOutgoingDamageModify(Stone.GetInternal    ,   1.2);
            AddOutgoingDamageModify(Toxic.GetInternal    ,   1.4);
            AddOutgoingDamageModify(Typeless.GetInternal ,   1.0);
            AddOutgoingDamageModify(Water.GetInternal    ,   1.6);
            
        }


        public static int RegisterSpeciesType()
        {
            //must add type image loading first.
            Water typeRegister = new Water();
            typeRegister.LoadResourceImage("SoliaQuestClassic.Resources.TypeImages.Water.png");
            SQWorld.Register(typeRegister);
            return 1;
        }
    }
}
