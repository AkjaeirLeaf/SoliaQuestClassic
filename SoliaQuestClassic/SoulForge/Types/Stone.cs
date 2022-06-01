using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Types
{
    public class Stone : SQType
    {
        public static string GetInternal { get { return "stone"; } }

        public Stone()
        {
            internalName = "stone";
            displayName = "Stone";;

            //add modifiers to damage
            //DAMAGE INCOMING reflects the extra damage / resistance to an attack on THIS type
            AddIncomingDamageModify(Air.GetInternal      ,   0.6);
            AddIncomingDamageModify(Crystal.GetInternal  ,   1.4);
            AddIncomingDamageModify(Dark.GetInternal     ,   0.6);
            AddIncomingDamageModify(Fire.GetInternal     ,   1.4);
            AddIncomingDamageModify(Ice.GetInternal      ,   1.4);
            AddIncomingDamageModify(Light.GetInternal    ,   0.6);
            AddIncomingDamageModify(Metal.GetInternal    ,   1.8);
            AddIncomingDamageModify(Plasma.GetInternal   ,   1.2);
            AddIncomingDamageModify(Spirit.GetInternal   ,   0.8);
            AddIncomingDamageModify(Stone.GetInternal    ,   1.0);
            AddIncomingDamageModify(Typeless.GetInternal ,   1.0);
            AddIncomingDamageModify(Water.GetInternal    ,   0.8);
            
            
            
            //DAMAGE OUTGOING reflects the extra damage / loss in damage in an ability used BY this type
            AddOutgoingDamageModify(Air.GetInternal      ,   0.6);
            AddOutgoingDamageModify(Crystal.GetInternal  ,   1.3);
            AddOutgoingDamageModify(Dark.GetInternal     ,   0.9);
            AddOutgoingDamageModify(Fire.GetInternal     ,   0.8);
            AddOutgoingDamageModify(Ice.GetInternal      ,   0.6);
            AddOutgoingDamageModify(Light.GetInternal    ,   0.6);
            AddOutgoingDamageModify(Metal.GetInternal    ,   1.1);
            AddOutgoingDamageModify(Plasma.GetInternal   ,   0.7);
            AddOutgoingDamageModify(Spirit.GetInternal   ,   0.5);
            AddOutgoingDamageModify(Stone.GetInternal    ,   1.7);
            AddOutgoingDamageModify(Typeless.GetInternal ,   1.0);
            AddOutgoingDamageModify(Water.GetInternal    ,   1.2);
            
        }


        public static int RegisterSpeciesType()
        {
            //must add type image loading first.
            Stone typeRegister = new Stone();
            typeRegister.LoadResourceImage("SoliaQuestClassic.Resources.TypeImages.Stone.png");
            SQWorld.Register(typeRegister);
            return 1;
        }
    }
}
