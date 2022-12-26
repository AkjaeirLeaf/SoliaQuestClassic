using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SoliaQuestClassic.IO;
using Kirali.MathR;

namespace SoliaQuestClassic.Render
{
    public class ActivePose
    {


    }

    public class ActiveBone
    {
        private Armature_bone Basis_Define;
        public Armature_bone DefaultBone { get { return Basis_Define; } }

        private Vector3 m_Axis_Thet; private Vector3 m_Axis_Thet_default;
        private Vector3 m_Axis_Phie; private Vector3 m_Axis_Phie_default;
        private Vector3 m_Axis_Radi; private Vector3 m_Axis_Radi_default;

        private Vector3 m_HeadPos; private Vector3 m_HeadPos_default; 
        private Vector3 m_TailPos; private Vector3 m_TailPos_default;

        public Vector3 Axis_Thet { get { return m_Axis_Thet; } }
        public Vector3 Axis_Phie { get { return m_Axis_Phie; } }
        public Vector3 Axis_Radi { get { return m_Axis_Radi; } }

        public Vector3 Head_Position { get { return m_HeadPos; } }
        public Vector3 Tail_Position { get { return m_TailPos; } }
        public Vector3 Head_Relative { get { return m_HeadPos - m_TailPos; } }
        public Vector3 Tail_Relative { get { return m_TailPos - m_HeadPos; } }

        //
        //
        //



        public void Hard_Reset_Pose()
        {
            m_Axis_Thet = m_Axis_Thet_default;
            m_Axis_Phie = m_Axis_Phie_default;
            m_Axis_Radi = m_Axis_Radi_default;

            m_HeadPos = m_HeadPos_default;
            m_TailPos = m_TailPos_default;
        }

        public void Mesh_Deform_Rotate(Vector3 Axis, double radians)
        {
            // DEFORM MESH AND JUMP INTO THE SEA
            Vector3 axi_normal = Axis.SafeNormalize();
            for (int px = 0; px < obj_.PosedVertices.Length; px++)
            {
                PointInfluence PI_L = obj_.Point_Armature_Array[px];
                if(PI_L.JOINT != null)
                {
                    for (int pl = 0; pl < PI_L.JOINT.Length; pl++)
                    {
                        if (PI_L.JOINT[pl] == jointID)
                        {
                            double weight = obj_.BoneInfluenceRef[PI_L.WEIGHT[pl]];
                            Matrix deform = Matrix.RotationU(axi_normal, radians * weight);
                            obj_.PosedVertices[px] = m_HeadPos + ((obj_.PosedVertices[px] - m_HeadPos).ToMatrix().Flip() * deform).ToVector3();
                            //break;
                        }
                    }
                }
            }
        }

        public void Mesh_Deform_Rotate(Vector3 Axis, Vector3 Center, double radians)
        {
            // DEFORM MESH AND JUMP INTO THE SEA
            Vector3 axi_normal = Axis.SafeNormalize();
            for (int px = 0; px < obj_.PosedVertices.Length; px++)
            {
                PointInfluence PI_L = obj_.Point_Armature_Array[px];
                if (PI_L.JOINT != null)
                {
                    for (int pl = 0; pl < PI_L.JOINT.Length; pl++)
                    {
                        if (PI_L.JOINT[pl] == jointID)
                        {
                            double weight = obj_.BoneInfluenceRef[PI_L.WEIGHT[pl]];
                            Matrix deform = Matrix.RotationU(axi_normal, radians * weight);
                            obj_.PosedVertices[px] = Center + ((obj_.PosedVertices[px] - Center).ToMatrix().Flip() * deform).ToVector3();
                            //break;
                        }
                    }
                }
            }
        }

        public void Mesh_Deform_Translate(Vector3 Axis, double distance)
        {
            // DEFORM MESH AND JUMP INTO THE SEA
            Vector3 axi_normal = Axis.SafeNormalize();
            for (int px = 0; px < obj_.PosedVertices.Length; px++)
            {
                PointInfluence PI_L = obj_.Point_Armature_Array[px];
                if (PI_L.JOINT != null)
                {
                    for (int pl = 0; pl < PI_L.JOINT.Length; pl++)
                    {
                        if (PI_L.JOINT[pl] == jointID)
                        {
                            double weight = obj_.BoneInfluenceRef[PI_L.WEIGHT[pl]];
                            obj_.PosedVertices[px] = obj_.PosedVertices[px] + Axis.SafeNormalize() * distance;
                            //break;
                        }
                    }
                }
            }
            /*
            foreach(string bone in Basis_Define.Link_Children)
            {
                for(int ix = 0; ix < obj_.boneGroup.Length; ix++)
                {
                    if(obj_.boneGroup[ix].DefaultBone.Name == bone)
                    {
                        obj_.boneGroup[ix].Move_CustomAxis(Axis, distance);
                    }
                }
            }
            */
        }

        public void PoseBone_RotateThet(double radians)
        {
            Matrix mat = Matrix.RotationU(m_Axis_Thet.SafeNormalize(), radians);
            m_Axis_Radi = (m_Axis_Radi.SafeNormalize().ToMatrix().Flip() * mat).ToVector3();
            m_Axis_Phie = (m_Axis_Phie.SafeNormalize().ToMatrix().Flip() * mat).ToVector3();

            m_TailPos = m_HeadPos + (Tail_Relative.ToMatrix().Flip() * mat).ToVector3();

            Mesh_Deform_Rotate(m_Axis_Thet, radians);  
        }
        public void PoseBone_RotatePhie(double radians)
        {
            Matrix mat = Matrix.RotationU(m_Axis_Phie.SafeNormalize(), radians);
            m_Axis_Thet = (m_Axis_Thet.SafeNormalize().ToMatrix().Flip() * mat).ToVector3();
            m_Axis_Radi = (m_Axis_Radi.SafeNormalize().ToMatrix().Flip() * mat).ToVector3();

            m_TailPos = m_HeadPos + (Tail_Relative.ToMatrix().Flip() * mat).ToVector3();

            Mesh_Deform_Rotate(m_Axis_Phie, radians);
        }
        public void PoseBone_RotateRadi(double radians)
        {
            Matrix mat = Matrix.RotationU(m_Axis_Radi.SafeNormalize(), radians);
            m_Axis_Thet = (m_Axis_Thet.SafeNormalize().ToMatrix().Flip() * mat).ToVector3();
            m_Axis_Phie = (m_Axis_Phie.SafeNormalize().ToMatrix().Flip() * mat).ToVector3();

            m_TailPos = m_HeadPos + (Tail_Relative.ToMatrix().Flip() * mat).ToVector3();

            Mesh_Deform_Rotate(m_Axis_Radi, radians);
        }
        public void PoseBone_RotateExternalSpecify(Vector3 axis, double radians, Vector3 center_absolute)
        {
            Matrix mat = Matrix.RotationU(axis.SafeNormalize(), radians);
            m_Axis_Thet = (m_Axis_Thet.SafeNormalize().ToMatrix().Flip() * mat).ToVector3();
            m_Axis_Phie = (m_Axis_Phie.SafeNormalize().ToMatrix().Flip() * mat).ToVector3();
            m_Axis_Radi = (m_Axis_Radi.SafeNormalize().ToMatrix().Flip() * mat).ToVector3();

            m_HeadPos = center_absolute + ((m_HeadPos - center_absolute).ToMatrix().Flip() * mat).ToVector3();
            m_TailPos = center_absolute + ((m_TailPos - center_absolute).ToMatrix().Flip() * mat).ToVector3();

            Mesh_Deform_Rotate(axis, center_absolute, radians);
        }

        public void Move_Axis_Thet(double distance)
        {
            m_HeadPos = m_HeadPos + m_Axis_Thet.SafeNormalize() * distance;
            m_TailPos = m_TailPos + m_Axis_Thet.SafeNormalize() * distance;
            Mesh_Deform_Translate(m_Axis_Thet, distance);
        }

        public void Move_Axis_Phie(double distance)
        {
            m_HeadPos = m_HeadPos + m_Axis_Phie.SafeNormalize() * distance;
            m_TailPos = m_TailPos + m_Axis_Phie.SafeNormalize() * distance;
            Mesh_Deform_Translate(m_Axis_Phie, distance);
        }

        public void Move_Axis_Radi(double distance)
        {
            m_HeadPos = m_HeadPos + m_Axis_Radi.SafeNormalize() * distance;
            m_TailPos = m_TailPos + m_Axis_Radi.SafeNormalize() * distance;
            Mesh_Deform_Translate(m_Axis_Radi, distance);
        }

        public void Move_CustomAxis(Vector3 axis, double distance)
        {
            m_HeadPos = m_HeadPos + axis.SafeNormalize() * distance;
            m_TailPos = m_TailPos + axis.SafeNormalize() * distance;
            Mesh_Deform_Translate(axis, distance);
        }

        // Order should always be ^v  <> roll (theta phi radial)
        private PoseableObject obj_;
        private int jointID = 0;

        public ActiveBone(Armature_bone basis, int joint, PoseableObject obj_ref)
        {
            obj_ = obj_ref;
            jointID = joint;

            //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            if (false) { basis = FillBoneValues(basis, true, obj_ref); }


            Basis_Define = basis;
            m_Axis_Thet = new Vector3(Basis_Define.Axis_T);
            m_Axis_Phie = new Vector3(Basis_Define.Axis_P);
            m_Axis_Radi = new Vector3(Basis_Define.Axis_R);

            m_Axis_Thet_default = new Vector3(m_Axis_Thet);
            m_Axis_Phie_default = new Vector3(m_Axis_Phie);
            m_Axis_Radi_default = new Vector3(m_Axis_Radi);

            m_HeadPos = new Vector3(Basis_Define.Head);
            m_TailPos = new Vector3(Basis_Define.Tail);

            m_HeadPos_default = new Vector3(m_HeadPos);
            m_TailPos_default = new Vector3(m_TailPos);

        }

        private static Armature_bone FillBoneValues(Armature_bone b, bool fixSender = false, PoseableObject sender = null)
        {
            if (!b.axi_res)
            {
                b.Head = new double[] { 0, 0, 0 };
                b.Tail = new double[] { 0, 0, 1 };
                b.Axis_T = new double[] { 1, 0, 0 };
                b.Axis_P = new double[] { 0, 1, 0 };
                b.Axis_R = new double[] { 0, 0, 1 };

                if (fixSender)
                {
                    for (int ix = 0; ix < sender.LinkObject.Armature_Bones.Length; ix++)
                    {
                        if (sender.LinkObject.Armature_Bones[ix].Name == b.Name)
                        {
                            sender.LinkObject.Armature_Bones[ix] = b;
                            break;
                        }
                    }
                }
            }
            b.axi_res = true;

            return b;
        }

    }
}
