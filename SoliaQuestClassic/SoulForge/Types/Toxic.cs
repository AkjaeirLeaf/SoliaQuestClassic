using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Types
{
    public class Toxic : SQType
    {
        public static string GetInternal { get { return "toxic"; } }

        public Toxic()
        {
            internalName = "toxic";
            displayName = "Toxic";

            //add modifiers to damage
            //DAMAGE INCOMING reflects the extra damage / resistance to an attack on THIS type
            AddIncomingDamageModify(Air.GetInternal       , 1.2);
            AddIncomingDamageModify(Crystal.GetInternal   , 1.2);
            AddIncomingDamageModify(Dark.GetInternal      , 1.0);
            AddIncomingDamageModify(Fire.GetInternal      , 1.6);
            AddIncomingDamageModify(Ice.GetInternal       , 1.4);
            AddIncomingDamageModify(Light.GetInternal     , 0.9);
            AddIncomingDamageModify(Metal.GetInternal     , 0.6);
            AddIncomingDamageModify(Plant.GetInternal     , 2.0);
            AddIncomingDamageModify(Plasma.GetInternal    , 1.8);
            AddIncomingDamageModify(Spirit.GetInternal    , 1.8);
            AddIncomingDamageModify(Stone.GetInternal     , 0.6);
            AddIncomingDamageModify(Toxic.GetInternal     , 0.2);
            AddIncomingDamageModify(Typeless.GetInternal  , 1.0);
            AddIncomingDamageModify(Water.GetInternal     , 0.9);



            //DAMAGE OUTGOING reflects the extra damage / loss in damage in an ability used BY this type
            AddOutgoingDamageModify(Air.GetInternal       , 0.6);
            AddOutgoingDamageModify(Crystal.GetInternal   , 0.5);
            AddOutgoingDamageModify(Dark.GetInternal      , 0.5);
            AddOutgoingDamageModify(Fire.GetInternal      , 0.2);
            AddOutgoingDamageModify(Ice.GetInternal       , 1.6);
            AddOutgoingDamageModify(Light.GetInternal     , 1.9);
            AddOutgoingDamageModify(Metal.GetInternal     , 1.4);
            AddOutgoingDamageModify(Plant.GetInternal     , 0.9);
            AddOutgoingDamageModify(Plasma.GetInternal    , 0.1);
            AddOutgoingDamageModify(Spirit.GetInternal    , 1.4);
            AddOutgoingDamageModify(Stone.GetInternal     , 1.4);
            AddOutgoingDamageModify(Toxic.GetInternal     , 0.6);
            AddOutgoingDamageModify(Typeless.GetInternal  , 1.0);
            AddOutgoingDamageModify(Water.GetInternal     , 1.7);

        }


        public static int RegisterSpeciesType()
        {
            //must add type image loading first.
            Toxic typeRegister = new Toxic();
            typeRegister.LoadResourceImage("SoliaQuestClassic.Resources.TypeImages.Toxic.png");
            SQWorld.Register(typeRegister);
            return 1;
        }
    }
}
