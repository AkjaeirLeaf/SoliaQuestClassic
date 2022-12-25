using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Kirali.MathR;
using Kirali.Light;
using Kirali.Environment.Render.Primatives;
using Newtonsoft.Json;

namespace SoliaQuestClassic.IO
{
    public class ObjectJson
    {
        public string MeshName = "";
        public int[] point_ptr;
        public Vector3[] points_cache;
        public Vector3[] face_normals = new Vector3[0];
        public int[] face_ptr = new int[0];
        public Vector2[] uv_map = new Vector2[0];
        public int[] uv_pointer = new int[0];
        public int[] vpa = new int[0];

        // Armature Data
        public Armature_bone[] Armature_Bones = new Armature_bone[0];
        public PointInfluence[] Point_Armature_Array = new PointInfluence[0];
        public double[] BoneInfluenceRef = new double[0];


        public void Export()
        {
            string content = JsonConvert.SerializeObject(this);
            string path = "external_models\\" + MeshName + "\\";
            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
            File.WriteAllText(path + "default.sqcj", content);
        }

        public static ObjectJson FromObject3D(Object3D obj)
        {
            ObjectJson json = new ObjectJson();

            json.MeshName     = obj.Mesh_ID;
            json.face_normals = obj.FACE_NORMALS;
            json.face_ptr = obj.FACE_POINTERS;
            json.uv_map = obj.UV_MAP;
            json.uv_pointer = obj.UV_REF;
            json.vpa = obj.VERTEX_POINTER_ARRAY;

            json.points_cache = obj.PointData;
            json.point_ptr = obj.PointRef;

            json.Armature_Bones = obj.Armature_Bones;
            json.Point_Armature_Array = obj.Point_Armature_Array;
            json.BoneInfluenceRef = obj.BoneInfluenceRef;

            return json;
        }

    }
}
