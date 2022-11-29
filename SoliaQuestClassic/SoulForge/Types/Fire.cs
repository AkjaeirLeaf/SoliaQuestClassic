using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Types
{
    public class Fire : SQType
    {
        public static string GetInternal { get { return "fire"; } }

        public Fire()
        {
            internalName = "fire";
            displayName = "Fire";

            //add modifiers to damage
            //DAMAGE INCOMING reflects the extra damage / resistance to an attack on THIS type
            AddIncomingDamageModify(Air.GetInternal      ,   0.5);
            AddIncomingDamageModify(Crystal.GetInternal  ,   1.4);
            AddIncomingDamageModify(Dark.GetInternal     ,   0.6);
            AddIncomingDamageModify(Fire.GetInternal     ,   0.6);
            AddIncomingDamageModify(Ice.GetInternal      ,   0.2);
            AddIncomingDamageModify(Light.GetInternal    ,   0.8);
            AddIncomingDamageModify(Metal.GetInternal    ,   1.0);
            AddIncomingDamageModify(Plant.GetInternal    ,   0.4);
            AddIncomingDamageModify(Plasma.GetInternal   ,   0.8);
            AddIncomingDamageModify(Spirit.GetInternal   ,   0.9);
            AddIncomingDamageModify(Stone.GetInternal    ,   0.9);
            AddIncomingDamageModify(Toxic.GetInternal    ,   0.8);
            AddIncomingDamageModify(Typeless.GetInternal ,   1.0);
            AddIncomingDamageModify(Water.GetInternal    ,   1.8);
            
            
            
            //DAMAGE OUTGOING reflects the extra damage / loss in damage in an ability used BY this type
            AddOutgoingDamageModify(Air.GetInternal      ,   1.6);
            AddOutgoingDamageModify(Crystal.GetInternal  ,   0.5);
            AddOutgoingDamageModify(Dark.GetInternal     ,   0.7);
            AddOutgoingDamageModify(Fire.GetInternal     ,   1.6);
            AddOutgoingDamageModify(Ice.GetInternal      ,   0.3);
            AddOutgoingDamageModify(Light.GetInternal    ,   1.3);
            AddOutgoingDamageModify(Metal.GetInternal    ,   0.6);
            AddOutgoingDamageModify(Plant.GetInternal    ,   1.6);
            AddOutgoingDamageModify(Plasma.GetInternal   ,   1.4);
            AddOutgoingDamageModify(Spirit.GetInternal   ,   1.3);
            AddOutgoingDamageModify(Stone.GetInternal    ,   0.7);
            AddOutgoingDamageModify(Toxic.GetInternal    ,   1.5);
            AddOutgoingDamageModify(Typeless.GetInternal ,   1.0);
            AddOutgoingDamageModify(Water.GetInternal    ,   0.3);
            
        }


        public static int RegisterSpeciesType()
        {
            //must add type image loading first.
            Fire typeRegister = new Fire();
            typeRegister.LoadResourceImage("SoliaQuestClassic.Resources.TypeImages.Fire.png");
            SQWorld.Register(typeRegister);
            return 1;
        }
    }
}
