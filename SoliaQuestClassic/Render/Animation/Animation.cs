using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.Render.Animation
{
    public partial class Animation
    {
        public AnimationAction[] Actions = new AnimationAction[0];
        private PoseableObject linkObject;
        private bool isPlaying = false;
        private int resetevery = 0;
        private int resetcounter = 0;
        private bool queueStop = false;
        private bool ready_switch = false;

        public bool AnimationQueuedReady
        {
            get
            {
                return ready_switch;
            }
        }

        public Animation(PoseableObject poseable)
        {
            linkObject = poseable;
        }


        public virtual void PlayAnimation()
        {
            isPlaying = true;
        }

        public virtual void PauseAnimation()
        {
            isPlaying = false;
        }

        public virtual void StopAnimation()
        {
            isPlaying = false;
            for (int ix = 0; ix < Actions.Length; ix++)
            {
                Actions[ix].Reset();
            }
            linkObject.ResetPose();
        }

        public virtual void RestartAnimation()
        {
            StopAnimation();
            PlayAnimation();
        }

        public virtual void StopAtNextLoop()
        {
            queueStop = true;
        }

        public virtual void SetRestartEvery(int resetlength)
        {
            resetevery = resetlength;
        }

        public virtual void Tick()
        {
            if (isPlaying)
            {
                for (int ix = 0; ix < Actions.Length; ix++)
                {
                    Actions[ix].Tick();
                }
            }
            if(resetevery > 0) {
                resetcounter++;
                if(resetcounter > resetevery) {
                    if (queueStop)
                    {
                        StopAnimation();
                        ready_switch = true;
                        queueStop = false;
                    }
                    else
                    {
                        RestartAnimation();
                    }
                    resetcounter = 0;
                }
            }
        }
    }
}
