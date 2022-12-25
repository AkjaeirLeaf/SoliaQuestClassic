using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SoliaQuestClassic.IO;

using Kirali.MathR;
using Kirali.Light;
using Kirali.Environment.Render.Primatives;

namespace SoliaQuestClassic.Render
{
    public class PoseableObject
    {
        private Object3D ref_linkObjMesh;
        public Object3D LinkObject { get { return ref_linkObjMesh; } set { ref_linkObjMesh = value; } }
        private Vector3[] m_posedVertices_keepVAO;
        public Vector3[] PosedVertices { get { return m_posedVertices_keepVAO; } set { m_posedVertices_keepVAO = value; } }
        public PointInfluence[] Point_Armature_Array { get { return ref_linkObjMesh.Point_Armature_Array; } }
        public double[] BoneInfluenceRef { get { return ref_linkObjMesh.BoneInfluenceRef; } }

        public ActiveBone[] boneGroup = new ActiveBone[0];

        public PoseableObject(Object3D linkedObject)
        {
            ref_linkObjMesh = linkedObject;

            // Create posable bones
            boneGroup = new ActiveBone[linkedObject.Armature_Bones.Length];
            for(int ix = 0; ix < linkedObject.Armature_Bones.Length; ix++)
            {
                boneGroup[ix] = new ActiveBone(linkedObject.Armature_Bones[ix], ix, this);
            }

            // Copy vao
            ResetPose();
        }

        public void ResetPose()
        {
            m_posedVertices_keepVAO = new Vector3[ref_linkObjMesh.PointData.Length];
            for (int ix = 0; ix < boneGroup.Length; ix++) { boneGroup[ix].Hard_Reset_Pose(); }
            for (int ix = 0; ix < m_posedVertices_keepVAO.Length; ix++) { m_posedVertices_keepVAO[ix] = new Vector3(ref_linkObjMesh.PointData[ix]); }
        }

        public Triangle3D GetPosedTriangle(int index)
        {
            if (index < ref_linkObjMesh.TriangleCount)
            {
                Vector3[] tpoints = new Vector3[3];
                tpoints[0] = m_posedVertices_keepVAO[ref_linkObjMesh.PointRef[index * 3 + 0]];
                tpoints[1] = m_posedVertices_keepVAO[ref_linkObjMesh.PointRef[index * 3 + 1]];
                tpoints[2] = m_posedVertices_keepVAO[ref_linkObjMesh.PointRef[index * 3 + 2]];


                Triangle3D tri = new Triangle3D(tpoints);
                tri.TextureLink[0] = ref_linkObjMesh.UV_REF[index * 3 + 0];
                tri.TextureLink[1] = ref_linkObjMesh.UV_REF[index * 3 + 1];
                tri.TextureLink[2] = ref_linkObjMesh.UV_REF[index * 3 + 2];
                tri.UV_Link[0] = ref_linkObjMesh.UV_MAP[ref_linkObjMesh.UV_REF[index * 3 + 0]];
                tri.UV_Link[1] = ref_linkObjMesh.UV_MAP[ref_linkObjMesh.UV_REF[index * 3 + 1]];
                tri.UV_Link[2] = ref_linkObjMesh.UV_MAP[ref_linkObjMesh.UV_REF[index * 3 + 2]];



                return tri;
            }
            throw new IndexOutOfRangeException("Referenced triangle does not exist in the mesh. Use TriangleCount to check size of mesh.");
        }

        public Triangle3D[] AllObjectTriangles(Kirali.Light.Camera camera)
        {
            int TriangleCount = ref_linkObjMesh.TriangleCount;
            double limiter = 0.1;
            int tc = 0;
            Triangle3D[] op = new Triangle3D[TriangleCount];
            bool[] doAdd = Kirali.Framework.ArrayHandler.setAll(false, TriangleCount);
            for (int l = 0; l < TriangleCount; l++)
            {
                op[l] = GetPosedTriangle(l);
                if (Kirali.MathR.Vector3.Dot(op[l].Normal, op[l].Middle - camera.position) < limiter) { doAdd[l] = true; tc++; }
            }
            Triangle3D[] adds = new Triangle3D[tc];
            tc = 0;
            for (int l = 0; l < op.Length; l++)
            {
                if (doAdd[l]) { adds[tc] = op[l]; tc++; }
            }
            return adds;
        }

        public void Render(Kirali.Light.Camera MainCamera, int useTextureSlot, Vector3 LightSource, KColor4 LightColor)
        {
            ref_linkObjMesh.Render(MainCamera, useTextureSlot, LightSource, LightColor, this);
        }
    }
}
