using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SoliaQuestClassic.Render;
using SoliaQuestClassic.Render.Animation;

namespace SoliaQuestClassic.SoulForge.Abilities.Animations
{
    public class ScarletVoidDashAnimation : Animation
    {
        private SineusoidalSwingAction WingBendAction_Left;
        private SineusoidalSwingAction WingBendAction_Right;


        public ScarletVoidDashAnimation(PoseableObject poseable) : base(poseable)
        {
            SetRestartEvery(99);
            WingBendAction_Left  = new SineusoidalSwingAction(new ActiveBone[] { poseable.boneGroup[1], poseable.boneGroup[2], poseable.boneGroup[3], poseable.boneGroup[4] }, AnimationAxes.Y_AXIS,     Math.PI / 2, 100);
            WingBendAction_Right = new SineusoidalSwingAction(new ActiveBone[] { poseable.boneGroup[9], poseable.boneGroup[10], poseable.boneGroup[11], poseable.boneGroup[12] }, AnimationAxes.Y_AXIS, -Math.PI / 2, 100);

            WingBendAction_Left.StartOnTick(0);
            WingBendAction_Right.StartOnTick(0);


            Actions = new AnimationAction[] { WingBendAction_Left, WingBendAction_Right };
        }
    }
}
