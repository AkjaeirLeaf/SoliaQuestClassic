using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Types
{
    public class Ice : SQType
    {
        public static string GetInternal { get { return "ice"; } }

        public Ice()
        {
            internalName = "ice";
            displayName = "Ice";

            //add modifiers to damage
            //DAMAGE INCOMING reflects the extra damage / resistance to an attack on THIS type
            AddIncomingDamageModify(Air.GetInternal      ,   0.9);
            AddIncomingDamageModify(Crystal.GetInternal  ,   1.5);
            AddIncomingDamageModify(Dark.GetInternal     ,   0.6);
            AddIncomingDamageModify(Fire.GetInternal     ,   1.7);
            AddIncomingDamageModify(Ice.GetInternal      ,   1.2);
            AddIncomingDamageModify(Light.GetInternal    ,   0.8);
            AddIncomingDamageModify(Metal.GetInternal    ,   1.5);
            AddIncomingDamageModify(Plant.GetInternal    ,   1.1);
            AddIncomingDamageModify(Plasma.GetInternal   ,   1.9);
            AddIncomingDamageModify(Spirit.GetInternal   ,   0.9);
            AddIncomingDamageModify(Stone.GetInternal    ,   1.3);
            AddIncomingDamageModify(Toxic.GetInternal    ,   0.7);
            AddIncomingDamageModify(Typeless.GetInternal ,   1.0);
            AddIncomingDamageModify(Water.GetInternal    ,   1.2);
            
            
            
            //DAMAGE OUTGOING reflects the extra damage / loss in damage in an ability used BY this type
            AddOutgoingDamageModify(Air.GetInternal      ,   1.6);
            AddOutgoingDamageModify(Crystal.GetInternal  ,   0.9);
            AddOutgoingDamageModify(Dark.GetInternal     ,   0.7);
            AddOutgoingDamageModify(Fire.GetInternal     ,   0.2);
            AddOutgoingDamageModify(Ice.GetInternal      ,   1.7);
            AddOutgoingDamageModify(Light.GetInternal    ,   1.3);
            AddOutgoingDamageModify(Metal.GetInternal    ,   0.9);
            AddOutgoingDamageModify(Plant.GetInternal    ,   1.3);
            AddOutgoingDamageModify(Plasma.GetInternal   ,   0.2);
            AddOutgoingDamageModify(Spirit.GetInternal   ,   0.9);
            AddOutgoingDamageModify(Stone.GetInternal    ,   1.2);
            AddOutgoingDamageModify(Toxic.GetInternal    ,   1.5);
            AddOutgoingDamageModify(Typeless.GetInternal ,   1.0);
            AddOutgoingDamageModify(Water.GetInternal    ,   1.1);
            
        }


        public static int RegisterSpeciesType()
        {
            //must add type image loading first.
            Ice typeRegister = new Ice();
            typeRegister.LoadResourceImage("SoliaQuestClassic.Resources.TypeImages.Ice.png");
            SQWorld.Register(typeRegister);
            return 1;
        }
    }
}
