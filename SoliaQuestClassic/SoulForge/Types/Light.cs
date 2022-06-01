using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Types
{
    public class Light : SQType
    {
        public static string GetInternal { get { return "light"; } }
        public Light()
        {
            internalName = "light";
            displayName = "Light";

            //add modifiers to damage
            //DAMAGE INCOMING reflects the extra damage / resistance to an attack on THIS type
            AddIncomingDamageModify(Air.GetInternal      ,   1.5);
            AddIncomingDamageModify(Crystal.GetInternal  ,   1.2);
            AddIncomingDamageModify(Dark.GetInternal     ,   2.6);
            AddIncomingDamageModify(Fire.GetInternal     ,   0.1);
            AddIncomingDamageModify(Ice.GetInternal      ,   1.2);
            AddIncomingDamageModify(Light.GetInternal    ,   0.3);
            AddIncomingDamageModify(Metal.GetInternal    ,   1.1);
            AddIncomingDamageModify(Plasma.GetInternal   ,   0.3);
            AddIncomingDamageModify(Spirit.GetInternal   ,   1.1);
            AddIncomingDamageModify(Stone.GetInternal    ,   1.3);
            AddIncomingDamageModify(Typeless.GetInternal ,   1.0);
            AddIncomingDamageModify(Water.GetInternal    ,   1.2);



            //DAMAGE OUTGOING reflects the extra damage / loss in damage in an ability used BY this type
            AddOutgoingDamageModify(Air.GetInternal      ,   0.3);
            AddOutgoingDamageModify(Crystal.GetInternal  ,   0.9);
            AddOutgoingDamageModify(Dark.GetInternal     ,   0.8);
            AddOutgoingDamageModify(Fire.GetInternal     ,   1.0);
            AddOutgoingDamageModify(Ice.GetInternal      ,   0.7);
            AddOutgoingDamageModify(Light.GetInternal    ,   1.7);
            AddOutgoingDamageModify(Metal.GetInternal    ,   0.5);
            AddOutgoingDamageModify(Plasma.GetInternal   ,   1.1);
            AddOutgoingDamageModify(Spirit.GetInternal   ,   1.3);
            AddOutgoingDamageModify(Stone.GetInternal    ,   0.3);
            AddOutgoingDamageModify(Typeless.GetInternal ,   1.0);
            AddOutgoingDamageModify(Water.GetInternal    ,   0.6);

        }


        public static int RegisterSpeciesType()
        {
            //must add type image loading first.
            Light typeRegister = new Light();
            typeRegister.LoadResourceImage("SoliaQuestClassic.Resources.TypeImages.Light.png");
            SQWorld.Register(typeRegister);
            return 1;
        }
    }
}
