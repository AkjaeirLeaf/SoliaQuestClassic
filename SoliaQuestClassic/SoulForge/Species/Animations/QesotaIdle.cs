using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SoliaQuestClassic.Render;
using SoliaQuestClassic.Render.Animation;

namespace SoliaQuestClassic.SoulForge.Species.Animations
{
    public class QesotaIdle : Animation
    {
        private SineusoidalSwingAction head_nodding;
        private SineusoidalSwingAction wing_shoulder_left; // bones 1 & 9
        private SineusoidalSwingAction wing_shoulder_right; 
        private SineusoidalMoveAction  body_fb_rocking;

        public QesotaIdle(PoseableObject poseable) : base(poseable)
        {
            SetRestartEvery(119);

            head_nodding  = new SineusoidalSwingAction(poseable.boneGroup[6], AnimationAxes.X_AXIS, Math.PI / 6, 120);
            wing_shoulder_left = new SineusoidalSwingAction(new ActiveBone[]  { poseable.boneGroup[1], poseable.boneGroup[2] , poseable.boneGroup[3] , poseable.boneGroup[4]  }, AnimationAxes.X_AXIS, Math.PI / 6, 120);
            wing_shoulder_right = new SineusoidalSwingAction(new ActiveBone[] { poseable.boneGroup[9], poseable.boneGroup[10], poseable.boneGroup[11], poseable.boneGroup[12] }, AnimationAxes.X_AXIS, Math.PI / 6, 120);
            head_nodding.StartOnTick(80);
            wing_shoulder_left.StartOnTick(0);
            wing_shoulder_right.StartOnTick(60);

            body_fb_rocking = new SineusoidalMoveAction(poseable.boneGroup[0], AnimationAxes.Y_AXIS, 0.04, 120);
            body_fb_rocking.StartOnTick(0);

            Actions = new AnimationAction[] { head_nodding, wing_shoulder_left, wing_shoulder_right, body_fb_rocking };
        }
    }
}
