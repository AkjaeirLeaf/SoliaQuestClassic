using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Types
{
    public class Air : SQType
    {
        public static string GetInternal { get { return "air"; } }

        public Air()
        {
            internalName = "air";
            displayName = "Air";

            //add modifiers to damage
            //DAMAGE INCOMING reflects the extra damage / resistance to an attack on THIS type
            AddIncomingDamageModify(Air.GetInternal       , 0.8);
            AddIncomingDamageModify(Crystal.GetInternal   , 1.8);
            AddIncomingDamageModify(Dark.GetInternal      , 0.9);
            AddIncomingDamageModify(Fire.GetInternal      , 1.9);
            AddIncomingDamageModify(Ice.GetInternal       , 1.2);
            AddIncomingDamageModify(Light.GetInternal     , 0.8);
            AddIncomingDamageModify(Metal.GetInternal     , 1.9);
            AddIncomingDamageModify(Plasma.GetInternal    , 1.6);
            AddIncomingDamageModify(Spirit.GetInternal    , 0.6);
            AddIncomingDamageModify(Stone.GetInternal     , 1.1);
            AddIncomingDamageModify(Typeless.GetInternal  , 1.0);
            AddIncomingDamageModify(Water.GetInternal     , 0.9);



            //DAMAGE OUTGOING reflects the extra damage / loss in damage in an ability used BY this type
            AddOutgoingDamageModify(Air.GetInternal       , 1.8);
            AddOutgoingDamageModify(Crystal.GetInternal   , 0.6);
            AddOutgoingDamageModify(Dark.GetInternal      , 0.3);
            AddOutgoingDamageModify(Fire.GetInternal      , 1.8);
            AddOutgoingDamageModify(Ice.GetInternal       , 0.6);
            AddOutgoingDamageModify(Light.GetInternal     , 0.8);
            AddOutgoingDamageModify(Metal.GetInternal     , 1.2);
            AddOutgoingDamageModify(Plasma.GetInternal    , 1.9);
            AddOutgoingDamageModify(Spirit.GetInternal    , 1.4);
            AddOutgoingDamageModify(Stone.GetInternal     , 0.6);
            AddOutgoingDamageModify(Typeless.GetInternal  , 1.0);
            AddOutgoingDamageModify(Water.GetInternal     , 1.2);

        }


        public static int RegisterSpeciesType()
        {
            //must add type image loading first.
            Air typeRegister = new Air();
            typeRegister.LoadResourceImage("SoliaQuestClassic.Resources.TypeImages.Air.png");
            SQWorld.Register(typeRegister);
            return 1;
        }
    }
}
