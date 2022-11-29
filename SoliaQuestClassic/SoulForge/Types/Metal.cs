using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Types
{
    public class Metal : SQType
    {
        public static string GetInternal { get { return "metal"; } }

        public Metal()
        {
            internalName = "metal";
            displayName = "Metal";

            //add modifiers to damage
            //DAMAGE INCOMING reflects the extra damage / resistance to an attack on THIS type
            AddIncomingDamageModify(Air.GetInternal      , 0.5);
            AddIncomingDamageModify(Crystal.GetInternal  , 0.8);
            AddIncomingDamageModify(Dark.GetInternal     , 0.6);
            AddIncomingDamageModify(Fire.GetInternal     , 1.3);
            AddIncomingDamageModify(Ice.GetInternal      , 1.2);
            AddIncomingDamageModify(Light.GetInternal    , 0.7);
            AddIncomingDamageModify(Metal.GetInternal    , 1.0);
            AddIncomingDamageModify(Plant.GetInternal    , 0.6);
            AddIncomingDamageModify(Plasma.GetInternal   , 1.8);
            AddIncomingDamageModify(Spirit.GetInternal   , 0.8);
            AddIncomingDamageModify(Stone.GetInternal    , 0.8);
            AddIncomingDamageModify(Toxic.GetInternal    , 1.4);
            AddIncomingDamageModify(Typeless.GetInternal , 1.0);
            AddIncomingDamageModify(Water.GetInternal    , 0.8);



            //DAMAGE OUTGOING reflects the extra damage / loss in damage in an ability used BY this type
            AddOutgoingDamageModify(Air.GetInternal      , 1.2);
            AddOutgoingDamageModify(Crystal.GetInternal  , 1.0);
            AddOutgoingDamageModify(Dark.GetInternal     , 0.8);
            AddOutgoingDamageModify(Fire.GetInternal     , 1.0);
            AddOutgoingDamageModify(Ice.GetInternal      , 0.7);
            AddOutgoingDamageModify(Light.GetInternal    , 1.1);
            AddOutgoingDamageModify(Metal.GetInternal    , 1.5);
            AddOutgoingDamageModify(Plant.GetInternal    , 1.6);
            AddOutgoingDamageModify(Plasma.GetInternal   , 0.9);
            AddOutgoingDamageModify(Spirit.GetInternal   , 0.6);
            AddOutgoingDamageModify(Stone.GetInternal    , 0.9);
            AddOutgoingDamageModify(Toxic.GetInternal    , 1.1);
            AddOutgoingDamageModify(Typeless.GetInternal , 1.0);
            AddOutgoingDamageModify(Water.GetInternal    , 1.3);

        }


        public static int RegisterSpeciesType()
        {
            //must add type image loading first.
            Metal typeRegister = new Metal();
            typeRegister.LoadResourceImage("SoliaQuestClassic.Resources.TypeImages.Metal.png");
            SQWorld.Register(typeRegister);
            return 1;
        }
    }
}
