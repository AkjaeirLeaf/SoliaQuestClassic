using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Types
{
    public class Crystal : SQType
    {
        public static string GetInternal { get { return "crystal"; } }

        public Crystal()
        {
            internalName = "crystal";
            displayName = "Crystal";

            //add modifiers to damage
            //DAMAGE INCOMING reflects the extra damage / resistance to an attack on THIS type
            AddIncomingDamageModify(Air.GetInternal      ,   0.5);
            AddIncomingDamageModify(Crystal.GetInternal  ,   1.3);
            AddIncomingDamageModify(Dark.GetInternal     ,   0.6);
            AddIncomingDamageModify(Fire.GetInternal     ,   0.8);
            AddIncomingDamageModify(Ice.GetInternal      ,   0.6);
            AddIncomingDamageModify(Light.GetInternal    ,   0.4);
            AddIncomingDamageModify(Metal.GetInternal    ,   1.7);
            AddIncomingDamageModify(Plant.GetInternal    ,   0.6);
            AddIncomingDamageModify(Plasma.GetInternal   ,   1.0);
            AddIncomingDamageModify(Spirit.GetInternal   ,   0.5);
            AddIncomingDamageModify(Stone.GetInternal    ,   1.6);
            AddIncomingDamageModify(Toxic.GetInternal    ,   0.3);
            AddIncomingDamageModify(Typeless.GetInternal ,   1.0);
            AddIncomingDamageModify(Water.GetInternal    ,   0.5);



            //DAMAGE OUTGOING reflects the extra damage / loss in damage in an ability used BY this type
            AddOutgoingDamageModify(Air.GetInternal      ,   0.9);
            AddOutgoingDamageModify(Crystal.GetInternal  ,   1.2);
            AddOutgoingDamageModify(Dark.GetInternal     ,   0.8);
            AddOutgoingDamageModify(Fire.GetInternal     ,   0.7);
            AddOutgoingDamageModify(Ice.GetInternal      ,   0.7);
            AddOutgoingDamageModify(Light.GetInternal    ,   1.0);
            AddOutgoingDamageModify(Metal.GetInternal    ,   0.5);
            AddOutgoingDamageModify(Plant.GetInternal    ,   1.5);
            AddOutgoingDamageModify(Plasma.GetInternal   ,   0.7);
            AddOutgoingDamageModify(Spirit.GetInternal   ,   1.1);
            AddOutgoingDamageModify(Stone.GetInternal    ,   0.6);
            AddOutgoingDamageModify(Toxic.GetInternal    ,   1.6);
            AddOutgoingDamageModify(Typeless.GetInternal ,   1.0);
            AddOutgoingDamageModify(Water.GetInternal    ,   0.9);


        }


        public static int RegisterSpeciesType()
        {
            //must add type image loading first.
            Crystal typeRegister = new Crystal();
            typeRegister.LoadResourceImage("SoliaQuestClassic.Resources.TypeImages.Crystal.png");
            SQWorld.Register(typeRegister);
            return 1;
        }
    }
}
