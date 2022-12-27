using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kirali.MathR;

namespace SoliaQuestClassic.Render.Animation
{
    public partial class AnimationAction
    {
        protected ActiveBone[] target = new ActiveBone[0];
        protected int ActionTimer = 0;
        protected int ActionTimerReset = 1000;

        public AnimationAction(ActiveBone target_link)
        {
            target = new ActiveBone[] { target_link };
        }

        public AnimationAction(ActiveBone[] target_links)
        {
            target = target_links;
        }


        public virtual void PrepareAction()
        {

        }

        public virtual void Tick()
        {
            
        }

        public virtual void Reset()
        {
            ActionTimer = 0;
        }
    }

    public enum AnimationAxes
    {
        X_AXIS,
        Y_AXIS,
        Z_AXIS,
        CUSTOMAXIS
    }

    public class GoToAction : AnimationAction
    {
        private Vector3[] target_positions;

        public GoToAction(ActiveBone target_link, Vector3 target_position) : base(target_link)
        {
            target_positions = new Vector3[] { target_position };
        }

        public GoToAction(ActiveBone target_link, Vector3[] target_position) : base(target_link)
        {
            target_positions = target_position;
        }

        public override void PrepareAction()
        {
            base.PrepareAction();
        }

        public override void Tick()
        {
            base.Tick();
        }
    }

    public class SineusoidalSwingAction : AnimationAction
    {
        private AnimationAxes swing_axis;
        private double Amplitude;
        private int cycle_time;
        private int start_on = 0;
        private double twopi = Math.PI * 2;
        private Vector3 CustomAxis;

        public SineusoidalSwingAction(ActiveBone target_link, AnimationAxes axis, double amplitude, int cycle_ticks, Vector3 custom_rotationaxis = null) : base(target_link)
        {
            swing_axis = axis;
            Amplitude = amplitude;
            cycle_time = cycle_ticks;
            if(axis== AnimationAxes.CUSTOMAXIS && custom_rotationaxis != null) { CustomAxis = custom_rotationaxis; }
        }

        public SineusoidalSwingAction(ActiveBone[] target_link, AnimationAxes axis, double amplitude, int cycle_ticks, Vector3 custom_rotationaxis = null) : base(target_link)
        {
            swing_axis = axis;
            Amplitude = amplitude;
            cycle_time = cycle_ticks;
            if (axis == AnimationAxes.CUSTOMAXIS && custom_rotationaxis != null) { CustomAxis = custom_rotationaxis; }
        }

        public override void PrepareAction()
        {
            base.PrepareAction();
        }

        public void StartOnTick(int tick) { start_on = tick; }

        public override void Tick()
        {
            double delta = Amplitude * twopi / cycle_time * Math.Cos((ActionTimer + start_on) * twopi / cycle_time);

            for (int ix = 0; ix < target.Length; ix++)
            {
                switch (swing_axis)
                {
                    case AnimationAxes.X_AXIS:
                        target[ix].PoseBone_RotateThet(delta);
                        break;
                    case AnimationAxes.Y_AXIS:
                        target[ix].PoseBone_RotatePhie(delta);
                        break;
                    case AnimationAxes.Z_AXIS:
                        target[ix].PoseBone_RotateRadi(delta);
                        break;
                    case AnimationAxes.CUSTOMAXIS:
                        target[ix].PoseBone_RotateExternalSpecify(CustomAxis, delta, target[ix].Head_Position);
                        break;
                }
            }

            

            ActionTimer++;
            if(ActionTimer > cycle_time) { ActionTimer = 0; }
        }
    }

    public class SineusoidalMoveAction : AnimationAction
    {
        private AnimationAxes move_axis;
        private double Amplitude;
        private int cycle_time;
        private int start_on = 0;
        private double twopi = Math.PI * 2;
        private Vector3 CustomAxis;

        private ActiveBone[] ControlBases = new ActiveBone[0];


        public SineusoidalMoveAction(ActiveBone target_link, AnimationAxes axis, double amplitude, int cycle_ticks, Vector3 custom_rotationaxis = null) : base(target_link)
        {
            move_axis = axis;
            Amplitude = amplitude;
            cycle_time = cycle_ticks;
            if (axis == AnimationAxes.CUSTOMAXIS && custom_rotationaxis != null) { CustomAxis = custom_rotationaxis; }
        }

        public SineusoidalMoveAction(ActiveBone[] target_link, AnimationAxes axis, double amplitude, int cycle_ticks, Vector3 custom_rotationaxis = null) : base(target_link)
        {
            move_axis = axis;
            Amplitude = amplitude;
            cycle_time = cycle_ticks;
            if (axis == AnimationAxes.CUSTOMAXIS && custom_rotationaxis != null) { CustomAxis = custom_rotationaxis; }
        }

        public void SetForceMove(ActiveBone bone)
        {
            ControlBases = new ActiveBone[] { bone };
        }

        public override void PrepareAction()
        {
            base.PrepareAction();
        }

        public void StartOnTick(int tick) { start_on = tick; }

        public override void Tick()
        {
            double delta = Amplitude * twopi / cycle_time * Math.Cos((ActionTimer + start_on) * twopi / cycle_time);

            for (int ix = 0; ix < target.Length; ix++)
            {
                switch (move_axis)
                {
                    case AnimationAxes.X_AXIS:
                        target[ix].Move_Axis_Thet(delta);
                        break;
                    case AnimationAxes.Y_AXIS:
                        target[ix].Move_Axis_Phie(delta);
                        break;
                    case AnimationAxes.Z_AXIS:
                        target[ix].Move_Axis_Radi(delta);
                        break;
                    case AnimationAxes.CUSTOMAXIS:
                        target[ix].Move_CustomAxis(CustomAxis, delta);
                        break;
                }
            }

            if(ControlBases.Length > 0)
            {
                for (int ix = 0; ix < ControlBases.Length; ix++)
                {
                    switch (move_axis)
                    {
                        case AnimationAxes.X_AXIS:
                            ControlBases[ix].ForceMoveBoneRef(target[0].Axis_Thet, delta);
                            break;
                        case AnimationAxes.Y_AXIS:
                            ControlBases[ix].ForceMoveBoneRef(target[0].Axis_Phie, delta);
                            break;
                        case AnimationAxes.Z_AXIS:
                            ControlBases[ix].ForceMoveBoneRef(target[0].Axis_Radi, delta);
                            break;
                        case AnimationAxes.CUSTOMAXIS:
                            ControlBases[ix].ForceMoveBoneRef(CustomAxis, delta);
                            break;
                    }
                }
            }

            ActionTimer++;
            if (ActionTimer > cycle_time) { ActionTimer = 0; }
        }
    }
}
