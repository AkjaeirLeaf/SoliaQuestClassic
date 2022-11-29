using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Types
{
    public class Plant : SQType
    {
        public static string GetInternal { get { return "plant"; } }

        public Plant()
        {
            internalName = "plant";
            displayName = "Plant";

            //add modifiers to damage
            //DAMAGE INCOMING reflects the extra damage / resistance to an attack on THIS type
            AddIncomingDamageModify(Air.GetInternal       , 1.0);
            AddIncomingDamageModify(Crystal.GetInternal   , 1.3);
            AddIncomingDamageModify(Dark.GetInternal      , 1.9);
            AddIncomingDamageModify(Fire.GetInternal      , 2.0);
            AddIncomingDamageModify(Ice.GetInternal       , 1.6);
            AddIncomingDamageModify(Light.GetInternal     , 0.7);
            AddIncomingDamageModify(Metal.GetInternal     , 1.5);
            AddIncomingDamageModify(Plant.GetInternal     , 0.9);
            AddIncomingDamageModify(Plasma.GetInternal    , 2.0);
            AddIncomingDamageModify(Spirit.GetInternal    , 0.6);
            AddIncomingDamageModify(Stone.GetInternal     , 1.0);
            AddIncomingDamageModify(Toxic.GetInternal     , 0.5);
            AddIncomingDamageModify(Typeless.GetInternal  , 1.0);
            AddIncomingDamageModify(Water.GetInternal     , 0.8);



            //DAMAGE OUTGOING reflects the extra damage / loss in damage in an ability used BY this type
            AddOutgoingDamageModify(Air.GetInternal       , 0.6);
            AddOutgoingDamageModify(Crystal.GetInternal   , 0.8);
            AddOutgoingDamageModify(Dark.GetInternal      , 0.2);
            AddOutgoingDamageModify(Fire.GetInternal      , 0.2);
            AddOutgoingDamageModify(Ice.GetInternal       , 0.4);
            AddOutgoingDamageModify(Light.GetInternal     , 0.6);
            AddOutgoingDamageModify(Metal.GetInternal     , 0.5);
            AddOutgoingDamageModify(Plant.GetInternal     , 1.2);
            AddOutgoingDamageModify(Plasma.GetInternal    , 0.2);
            AddOutgoingDamageModify(Spirit.GetInternal    , 1.0);
            AddOutgoingDamageModify(Stone.GetInternal     , 1.8);
            AddOutgoingDamageModify(Toxic.GetInternal     , 2.2);
            AddOutgoingDamageModify(Typeless.GetInternal  , 1.0);
            AddOutgoingDamageModify(Water.GetInternal     , 2.2);

        }


        public static int RegisterSpeciesType()
        {
            //must add type image loading first.
            Plant typeRegister = new Plant();
            typeRegister.LoadResourceImage("SoliaQuestClassic.Resources.TypeImages.Plant.png");
            SQWorld.Register(typeRegister);
            return 1;
        }
    }
}
