using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;
using System.IO;

using Kirali.MathR;
using Kirali.Light;
using Kirali.Environment.Render.Primatives;

using SoliaQuestClassic.Render;
using SoliaQuestClassic.IO;

namespace SoliaQuestClassic.IO
{
    public class Object3D : Triangle3DMesh
    {
        // old

        // new
        private string mesh_id = "";
        public string Mesh_ID { get { return mesh_id; } }

        private Vector3 rotation = new Vector3();
        public Vector3 Rotation { get { return rotation; } set { rotation = value; } }
        private Vector3[] face_normals = new Vector3[0];
        public Vector3[] FACE_NORMALS { get { return face_normals; } }
        private int[] face_ptr = new int[0];
        public int[] FACE_POINTERS { get { return face_ptr; } }
        public int[] PointRef { get { return point_ptr; } }
        private Vector2[] uv_map = new Vector2[0];
        public Vector2[] UV_MAP { get { return uv_map; } }
        private int[] uv_pointer = new int[0];
        public int[] UV_REF { get { return uv_pointer; } }
        private int[] vpa = new int[0];
        public int[] VERTEX_POINTER_ARRAY { get { return vpa; } }
        public Texture2D[] ObjectTextures = new Texture2D[0];

        public Object3D Clone()
        {
            return (Object3D)MemberwiseClone();
        }

        // ARMATURE
        public Armature_bone[] Armature_Bones = new Armature_bone[0];
        public PointInfluence[] Point_Armature_Array = new PointInfluence[0];
        public double[] BoneInfluenceRef = new double[0];

        public ObjectJson GetExport()
        {
            ObjectJson json = new ObjectJson();
            json.face_normals = face_normals;
            json.face_ptr = face_ptr;
            json.MeshName = mesh_id;
            json.uv_map = uv_map;
            json.uv_pointer = uv_pointer;
            json.vpa = vpa;

            json.points_cache = PointData;
            json.point_ptr = TriangleData;

            json.Armature_Bones       = Armature_Bones;
            json.Point_Armature_Array = Point_Armature_Array;
            json.BoneInfluenceRef     = BoneInfluenceRef;


            // do bones:)

            return json;
        }

        public static Object3D FromJsonResource(string resourcePath)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                Object3D obj = new Object3D();
                ObjectJson json = Newtonsoft.Json.JsonConvert.DeserializeObject<ObjectJson>(reader.ReadToEnd());
                obj.mesh_id = json.MeshName;
                obj.face_normals = json.face_normals;
                obj.face_ptr = json.face_ptr;
                obj.uv_map = json.uv_map;
                obj.uv_pointer = json.uv_pointer;
                obj.vpa = json.vpa;

                obj.points_cache = json.points_cache;
                obj.point_ptr    = json.point_ptr;

                obj.Armature_Bones       = json.Armature_Bones;
                obj.Point_Armature_Array = json.Point_Armature_Array;
                obj.BoneInfluenceRef     = json.BoneInfluenceRef;


                return obj;
            }
        }

        public static Object3D FromJsonExternal(string filepath)
        {
            FileStream stream = new FileStream(filepath, FileMode.Open);
            using (StreamReader reader = new StreamReader(stream))
            {
                Object3D obj = new Object3D();
                ObjectJson json = Newtonsoft.Json.JsonConvert.DeserializeObject<ObjectJson>(reader.ReadToEnd());
                obj.mesh_id = json.MeshName;
                obj.face_normals = json.face_normals;
                obj.face_ptr = json.face_ptr;
                obj.uv_map = json.uv_map;
                obj.uv_pointer = json.uv_pointer;
                obj.vpa = json.vpa;

                obj.points_cache = json.points_cache;
                obj.point_ptr = json.point_ptr;

                obj.Armature_Bones = json.Armature_Bones;
                obj.Point_Armature_Array = json.Point_Armature_Array;
                obj.BoneInfluenceRef = json.BoneInfluenceRef;


                return obj;
            }
        }

        // RENDER MESH

        public void Render(Kirali.Light.Camera MainCamera, int useTextureSlot, Vector3 LightSource, KColor4 LightColor, PoseableObject posedMesh = null)
        {
            if (useTextureSlot >= 0 && useTextureSlot < ObjectTextures.Length)
            {
                Triangle3D[] all;
                PointInfluence[] PAI;
                bool doWeightRender = false;

                if(posedMesh != null)
                {
                    all = posedMesh.AllObjectTriangles(MainCamera);
                    PAI = posedMesh.Point_Armature_Array;
                    if (AnimatorWindow.ANIMW_ShowBoneWeightRender) { doWeightRender = true; }
                }
                else { all = AllObjectTriangles(MainCamera); }
                var triangles_ordered = all.OrderByDescending(Triangle3D => Vector3.Distance(Triangle3D.Middle, MainCamera.position)).ToArray();

                all = (Triangle3D[])triangles_ordered;

                for (int f = 0; f < all.Length; f++)
                {
                    

                    Vector2[] projected = new Vector2[]
                        {
                        MainCamera.PointToScreen(all[f].Points[0]),
                        MainCamera.PointToScreen(all[f].Points[1]),
                        MainCamera.PointToScreen(all[f].Points[2])
                        };

                    if (projected[0].Form != Vector2.VectorForm.INFINITY
                            && projected[1].Form != Vector2.VectorForm.INFINITY
                            && projected[2].Form != Vector2.VectorForm.INFINITY
                            )
                    {
                        double shading = 1;
                        double ambient = 0.3;
                        Color hue = (LightColor.ToSystemColor());
                        Color[] ColorTint = new Color[3];
                        Vector2[] texMap = new Vector2[3];
                        texMap[0] = uv_map[all[f].TextureLink[0]];
                        texMap[1] = uv_map[all[f].TextureLink[1]];
                        texMap[2] = uv_map[all[f].TextureLink[2]];

                        shading = Vector3.Dot(-1 * all[f].Normal, LightSource);
                        if (shading < 0) { shading = 0; }
                        if (shading > 1) { shading = 1; }
                        shading = ambient + (1 - ambient) * shading;
                        ColorTint[0] = QuickGreyscale((int)(shading * 255));

                        shading = Vector3.Dot(-1 * all[f].Normal, LightSource);
                        if (shading < 0) { shading = 0; }
                        if (shading > 1) { shading = 1; }
                        shading = ambient + (1 - ambient) * shading;
                        ColorTint[1] = QuickGreyscale((int)(shading * 255));

                        shading = Vector3.Dot(-1 * all[f].Normal, LightSource);
                        if (shading < 0) { shading = 0; }
                        if (shading > 1) { shading = 1; }
                        shading = ambient + (1 - ambient) * shading;
                        ColorTint[2] = QuickGreyscale((int)(shading * 255));

                        ObjectTextures[useTextureSlot].Draw(projected, ColorTint, texMap);
                    }
                }
            }
        }

        private Color QuickGreyscale(int value)
        {
            return Color.FromArgb(value, value, value);
        }

        public Triangle3D[] AllObjectTriangles(Kirali.Light.Camera camera, bool absolute = false)
        {
            double limiter = 0.1;
            int tc = 0;
            Triangle3D[] op = new Triangle3D[TriangleCount];
            bool[] doAdd = Kirali.Framework.ArrayHandler.setAll(false, TriangleCount);
            for (int l = 0; l < TriangleCount; l++)
            {
                op[l] = GetObjectTriangle(l);
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

        public Triangle3D GetObjectTriangle(int index, bool absolute = false)
        {
            if (index < TriangleCount)
            {
                Vector3[] tpoints = new Vector3[3];
                tpoints[0] = points_cache[point_ptr[index * 3 + 0]];
                tpoints[1] = points_cache[point_ptr[index * 3 + 1]];
                tpoints[2] = points_cache[point_ptr[index * 3 + 2]];

                if (absolute)
                {
                    
                }

                Triangle3D tri = new Triangle3D(tpoints);
                tri.TextureLink[0] = uv_pointer[index * 3 + 0];
                tri.TextureLink[1] = uv_pointer[index * 3 + 1];
                tri.TextureLink[2] = uv_pointer[index * 3 + 2];
                tri.UV_Link[0] = uv_map[uv_pointer[index * 3 + 0]];
                tri.UV_Link[1] = uv_map[uv_pointer[index * 3 + 1]];
                tri.UV_Link[2] = uv_map[uv_pointer[index * 3 + 2]];



                return tri;
            }
            throw new IndexOutOfRangeException("Referenced triangle does not exist in the mesh. Use TriangleCount to check size of mesh.");
        }

        // LOAD MESH DATA

        private void SetBoneDetail(string bone_name, double[] transform, string parentBone)
        {
            for(int ix = 0; ix < Armature_Bones.Length; ix++)
            {
                if(Armature_Bones[ix].Name == bone_name)
                {
                    Armature_Bones[ix].Parent_Name = parentBone;
                    Armature_Bones[ix].Transform   = transform;
                }
            }
        }

        public static bool FromCollada(string filepath, out Object3D obj3d)
        {
            // make mesh obj
            Object3D obj_build = new Object3D();

            // grab mesh from xml-collada format
            XMLFile objCollada = XMLFile.FromFile(filepath);

            // the xml contains:
            // VAO
            // pointers
            // normals
            // texture UV maps
            // basic shader data
            // armature / bones / weights
            // SEVERAL other info too, but this is all we really want here.

            // COLLADA.library_geometries contains the geometry data / mesh
            XMLStructure geometry_of;
            if (objCollada.Search("COLLADA.library_geometries.geometry", out geometry_of))
            {
                object name; geometry_of.GetParameter("name", out name); obj_build.mesh_id = (string)name;
                XMLStructure vx_positions = geometry_of.Children[0].Children[0];
                XMLStructure face_normals = geometry_of.Children[0].Children[1];
                XMLStructure vx_uvmap_dat = geometry_of.Children[0].Children[2];
                XMLStructure pointer_appl = geometry_of.Children[0].Children[4];

                // Create vao of size specified in "count" parameter
                object vao_size; vx_positions.Children[0].GetParameter("count", out vao_size);
                Vector3[] vao = new Vector3[Int32.Parse(vao_size.ToString()) / 3];

                // Fill the vao using the contents of "mesh-positions-array"
                string[] vao_content = vx_positions.Children[0].Contents.ToString().Split(' ');
                for(int ix = 0; ix < vao.Length; ix++)
                {
                    double X = 0; Double.TryParse(vao_content[3 * ix + 0], out X);
                    double Y = 0; Double.TryParse(vao_content[3 * ix + 1], out Y);
                    double Z = 0; Double.TryParse(vao_content[3 * ix + 2], out Z);
                    vao[ix] = new Vector3(X, Y, Z);
                }

                // Create normal array of size specified in "count" parameter
                object normals_size; face_normals.Children[0].GetParameter("count", out normals_size);
                Vector3[] normals = new Vector3[Int32.Parse(normals_size.ToString()) / 3];

                // Fill the normal array using the contents of "mesh-normals-array"
                string[] normals_content = face_normals.Children[0].Contents.ToString().Split(' ');
                for (int ix = 0; ix < normals.Length; ix++)
                {
                    double X = 0; Double.TryParse(normals_content[3 * ix + 0], out X);
                    double Y = 0; Double.TryParse(normals_content[3 * ix + 1], out Y);
                    double Z = 0; Double.TryParse(normals_content[3 * ix + 2], out Z);
                    normals[ix] = new Vector3(X, Y, Z);
                }

                // Create uv map array of size specified in "count" parameter
                object uv_size; vx_uvmap_dat.Children[0].GetParameter("count", out uv_size);
                Vector2[] uv_map_points = new Vector2[Int32.Parse(uv_size.ToString()) / 2];

                // Fill the normal array using the contents of "mesh-normals-array"
                string[] uv_content = vx_uvmap_dat.Children[0].Contents.ToString().Split(' ');
                for (int ix = 0; ix < uv_map_points.Length; ix++)
                {
                    double X = 0; Double.TryParse(uv_content[2 * ix + 0], out X);
                    double Y = 0; Double.TryParse(uv_content[2 * ix + 1], out Y);
                    uv_map_points[ix] = new Vector2(X, Y);
                }

                // Create all pointers array, set length
                object pointerArrayLength; pointer_appl.GetParameter("count", out pointerArrayLength);
                int[] all_pointers = new int[Int32.Parse(pointerArrayLength.ToString()) * 3 * 3];
                int[] point_ptr = new int[all_pointers.Length / 3];
                int[] face_ptr = new int[all_pointers.Length / 3];
                // format: three vertices ref (0 1 2)
                // within each: vertex, normal, texture
                // for now I will do a single big vpa (vertex pointer array)
                string[] ptr_content = pointer_appl.Children[3].Contents.ToString().Split(' ');
                for (int ix = 0; ix < all_pointers.Length; ix++)
                {
                    int ptr = 0; int.TryParse(ptr_content[ix], out ptr);
                    all_pointers[ix] = ptr;
                    if(ix % 3 == 0) { point_ptr[ix / 3] = ptr; }
                    if((ix - 1) % 3 == 0) { face_ptr[ix / 3] = ptr; }
                }


                // build the final mesh
                obj_build.points_cache = vao;
                obj_build.face_normals = normals;
                obj_build.face_ptr = face_ptr;
                obj_build.uv_map = uv_map_points;
                obj_build.vpa = all_pointers;

                // extra idk idc
                obj_build.point_ptr = point_ptr;

                obj3d = obj_build;
                return true;
            }

            obj3d = null;
            return false;
        }
        public static bool FromColladaResx(string resourcePath, out Object3D obj3d)
        {
            // make mesh obj
            Object3D obj_build = new Object3D();

            // grab mesh from xml-collada format
            XMLFile objCollada = XMLFile.FromResource(resourcePath);

            // the xml contains:
            // VAO
            // pointers
            // normals
            // texture UV maps
            // basic shader data
            // armature / bones / weights
            // SEVERAL other info too, but this is all we really want here.

            // COLLADA.library_geometries contains the geometry data / mesh
            XMLStructure geometry_of; bool geometry_data = false;
            if (objCollada.Search("COLLADA.library_geometries.geometry", out geometry_of))
            {
                object name; geometry_of.GetParameter("name", out name); obj_build.mesh_id = (string)name;
                XMLStructure vx_positions = geometry_of.Children[0].Children[0];
                XMLStructure face_normals = geometry_of.Children[0].Children[1];
                XMLStructure vx_uvmap_dat = geometry_of.Children[0].Children[2];
                XMLStructure pointer_appl = geometry_of.Children[0].Children[4];

                // Create vao of size specified in "count" parameter
                object vao_size; vx_positions.Children[0].GetParameter("count", out vao_size);
                Vector3[] vao = new Vector3[Int32.Parse(vao_size.ToString()) / 3];

                // Fill the vao using the contents of "mesh-positions-array"
                string[] vao_content = vx_positions.Children[0].Contents.ToString().Split(' ');
                for (int ix = 0; ix < vao.Length; ix++)
                {
                    double X = 0; Double.TryParse(vao_content[3 * ix + 0], out X);
                    double Y = 0; Double.TryParse(vao_content[3 * ix + 1], out Y);
                    double Z = 0; Double.TryParse(vao_content[3 * ix + 2], out Z);
                    vao[ix] = new Vector3(X, Y, Z);
                }

                // Create normal array of size specified in "count" parameter
                object normals_size; face_normals.Children[0].GetParameter("count", out normals_size);
                Vector3[] normals = new Vector3[Int32.Parse(normals_size.ToString()) / 3];

                // Fill the normal array using the contents of "mesh-normals-array"
                string[] normals_content = face_normals.Children[0].Contents.ToString().Split(' ');
                for (int ix = 0; ix < normals.Length; ix++)
                {
                    double X = 0; Double.TryParse(normals_content[3 * ix + 0], out X);
                    double Y = 0; Double.TryParse(normals_content[3 * ix + 1], out Y);
                    double Z = 0; Double.TryParse(normals_content[3 * ix + 2], out Z);
                    normals[ix] = new Vector3(X, Y, Z);
                }

                // Create uv map array of size specified in "count" parameter
                object uv_size; vx_uvmap_dat.Children[0].GetParameter("count", out uv_size);
                Vector2[] uv_map_points = new Vector2[Int32.Parse(uv_size.ToString()) / 2];

                // Fill the normal array using the contents of "mesh-normals-array"
                string[] uv_content = vx_uvmap_dat.Children[0].Contents.ToString().Split(' ');
                for (int ix = 0; ix < uv_map_points.Length; ix++)
                {
                    double X = 0; Double.TryParse(uv_content[2 * ix + 0], out X);
                    double Y = 0; Double.TryParse(uv_content[2 * ix + 1], out Y);
                    uv_map_points[ix] = new Vector2(X, Y);
                }

                // Create all pointers array, set length
                object pointerArrayLength; pointer_appl.GetParameter("count", out pointerArrayLength);
                int[] all_pointers = new int[Int32.Parse(pointerArrayLength.ToString()) * 3 * 3];
                int[] point_ptr = new int[all_pointers.Length / 3];
                int[] face_ptr = new int[all_pointers.Length / 3];
                int[] uv_ptr = new int[all_pointers.Length / 3];
                // format: three vertices ref (0 1 2)
                // within each: vertex, normal, texture
                // for now I will do a single big vpa (vertex pointer array)
                string[] ptr_content = pointer_appl.Children[3].Contents.ToString().Split(' ');
                for (int ix = 0; ix < all_pointers.Length; ix++)
                {
                    int ptr = 0; int.TryParse(ptr_content[ix], out ptr);
                    all_pointers[ix] = ptr;
                    if (ix % 3 == 0) { point_ptr[ix / 3] = ptr; }
                    if ((ix - 1) % 3 == 0) { face_ptr[ix / 3] = ptr; }
                    if ((ix - 2) % 3 == 0) { uv_ptr[ix / 3] = ptr; }
                }


                // build the final mesh
                obj_build.points_cache = vao;
                obj_build.face_normals = normals;
                obj_build.face_ptr = face_ptr;
                obj_build.uv_map = uv_map_points;
                obj_build.uv_pointer = uv_ptr;
                obj_build.vpa = all_pointers;

                // extra idk idc
                obj_build.point_ptr = point_ptr;

                geometry_data = true;
                //return true;
            }

            XMLStructure armature_controller; bool armature_data = false;
            XMLStructure scene_parent; bool scene_parent_data = false;
            if (objCollada.Search("COLLADA.library_controllers.controller.skin", out armature_controller)
                && objCollada.Search("COLLADA.library_visual_scenes.visual_scene", out scene_parent))
            {
                // SKIN contains:
                // bind_shape_matrix , int[16] it seems its always: <bind_shape_matrix>1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1</bind_shape_matrix>
                // source, x3?
                // joints
                // vertex_weights

                // Child 1: <source id="(creature)_armature_(creature)-skin-joints">
                // should always be the 01 slot child.
                // this section lists all of the bones in an array:

                string[] bones_identify;
                //<Name_array/> is the 0 slot child of the 1 slot child of skin.
                bones_identify = armature_controller.Children[1].Children[0].Contents.ToString().Split(' '); // should be this easy tbh
                // as far as i can tell, the 1 slot child is bogus.

                // child 2 is... poses?
                // <source id="qesota_armature_qesota-skin-bind_poses">
                // <float_array id="qesota_armature_qesota-skin-bind_poses-array" ... big float array...
                object poses_bind_size; armature_controller.Children[2].Children[0].GetParameter("count", out poses_bind_size);
                double[] poses_bind = new double[Int32.Parse(poses_bind_size.ToString())];
                string[] bindarraybreak = armature_controller.Children[2].Children[0].Contents.ToString().Split(' ');
                for (int ix = 0; ix < poses_bind.Length; ix++)
                {
                    Double.TryParse(bindarraybreak[ix], out poses_bind[ix]);
                }

                // on to child #3... this one is skin weights.
                // <source id="qesota_armature_qesota-skin-weights">
                // hmmm I think this might actually just be the list of weights for each bone.
                object vertex_weight_count; armature_controller.Children[3].Children[0].GetParameter("count", out vertex_weight_count);
                double[] vertex_weights = new double[Int32.Parse(vertex_weight_count.ToString())];
                string[] vweightbreak = armature_controller.Children[3].Children[0].Contents.ToString().Split(' ');
                for (int ix = 0; ix < poses_bind.Length; ix++)
                {
                    Double.TryParse(vweightbreak[ix], out vertex_weights[ix]);
                }

                // child 4 is bogus

                // on to child #5... this is the vao eq, contains:
                // in slot 2: <vcount> not sure what this one is yet
                // in slot 3: <v> joint, weight, joint, weight ... etc
                // <vertex_weights> is child 5, has a count parameter... idk what it refers to exactly

                // ooook wiki says >> The <vcount> value for a vertex defines the number of influences on that vertex.
                // >> The values in the <v> array are the indices of the joint and weight that make up that influence.
                string[] vcount_inf_obj = armature_controller.Children[5].Children[2].Contents.ToString().Split(' ');
                int[] vcount = new int[vcount_inf_obj.Length];
                PointInfluence[] inf = new PointInfluence[vcount.Length];
                for (int ix = 0; ix < poses_bind.Length; ix++)
                {
                    Int32.TryParse(vcount_inf_obj[ix], out vcount[ix]);
                    inf[ix].JOINT = new int[vcount[ix]];
                    inf[ix].WEIGHT = new int[vcount[ix]];
                }
                string[] v_arr_broken = armature_controller.Children[5].Children[3].Contents.ToString().Split(' ');
                int absolute = 0;
                for (int ix = 0; ix < vcount.Length; ix++)
                {
                    for (int sub = 0; sub < vcount[ix]; sub++)
                    {
                        inf[ix].JOINT[sub]  = Int32.Parse(v_arr_broken[absolute]); absolute++;
                        inf[ix].WEIGHT[sub] = Int32.Parse(v_arr_broken[absolute]); absolute++;
                    }
                }
                // phew holy shit i think thats it, altho I'll say, idk where the bone parent/children system is...
                // found it : library_visual_scenes

                Armature_bone[] bones = new Armature_bone[bones_identify.Length];
                for(int ix = 0; ix < bones.Length; ix++)
                {
                    bones[ix].Name = bones_identify[ix];
                    bones[ix].Pose = new double[16];
                    bones[ix].Transform = new double[16];

                    for (int px = 0; px < 16; px++)
                    {
                        bones[ix].Pose[px] = poses_bind[ix * 16 + px]; // crossing my fingers here...
                    }

                    // assign parents later
                }

                // What have we got here...
                // BONES, all set but gotta apply parents
                // POINT_INFLUENCE these guys should go straight to the Object3D storage
                // only thing left is the vertex_weights, 

                obj_build.Armature_Bones = bones;
                obj_build.Point_Armature_Array = inf;
                obj_build.BoneInfluenceRef = vertex_weights;
                armature_data = true;

                // We not done with those bones yet tho...
                XMLStructure Armature_par = scene_parent.Children[0];
                for(int ix = 1; ix < Armature_par.Children.Length; ix++)
                {
                    object child_ID_obj; Armature_par.Children[ix].GetParameter("id", out child_ID_obj);
                    if (child_ID_obj != null)
                    {
                        if (child_ID_obj.ToString().Contains("_armature"))
                        {
                            object name_obj0; Armature_par.Children[ix].GetParameter("name", out name_obj0);
                            string[] break_tform0 = Armature_par.Children[ix].Children[0].Contents.ToString().Split(' ');
                            double[] tform0 = new double[break_tform0.Length];
                            for (int tx0 = 0; tx0 < tform0.Length; tx0++)
                            {
                                Double.TryParse(break_tform0[tx0], out tform0[tx0]);
                            }
                            obj_build.SetBoneDetail(name_obj0.ToString(), tform0, "");

                            // check if more than two children, this would mean there's a sub-bone
                            if (Armature_par.Children[ix].Children.Length > 2)
                            {
                                for (int ch0 = 1; ch0 < Armature_par.Children[ix].Children.Length; ch0++)
                                {
                                    object child_ID_obj1; Armature_par.Children[ix].Children[ch0].GetParameter("id", out child_ID_obj1);
                                    if (child_ID_obj1 != null)
                                    {
                                        if (child_ID_obj1.ToString().Contains("_armature"))
                                        {
                                            object name_obj1; Armature_par.Children[ix].Children[ch0].GetParameter("name", out name_obj1);
                                            string[] break_tform1 = Armature_par.Children[ix].Children[ch0].Children[0].Contents.ToString().Split(' ');
                                            double[] tform1 = new double[break_tform1.Length];
                                            for (int tx1 = 0; tx1 < tform1.Length; tx1++)
                                            {
                                                Double.TryParse(break_tform1[tx1], out tform1[tx1]);
                                            }
                                            obj_build.SetBoneDetail(name_obj1.ToString(), tform1, name_obj0.ToString());

                                            // check if more than two children, this would mean there's a sub-bone
                                            if (Armature_par.Children[ix].Children[ch0].Children.Length > 2)
                                            {
                                                for (int ch1 = 1; ch1 < Armature_par.Children[ix].Children[ch0].Children.Length; ch1++)
                                                {
                                                    object child_ID_obj2; Armature_par.Children[ix].Children[ch0].Children[ch1].GetParameter("id", out child_ID_obj2);
                                                    if (child_ID_obj2 != null)
                                                    {
                                                        if (child_ID_obj2.ToString().Contains("_armature"))
                                                        {
                                                            object name_obj2; Armature_par.Children[ix].Children[ch0].Children[ch1].GetParameter("name", out name_obj2);
                                                            string[] break_tform2 = Armature_par.Children[ix].Children[ch0].Children[ch1].Children[0].Contents.ToString().Split(' ');
                                                            double[] tform2 = new double[break_tform2.Length];
                                                            for (int tx2 = 0; tx2 < tform2.Length; tx2++)
                                                            {
                                                                Double.TryParse(break_tform2[tx2], out tform2[tx2]);
                                                            }
                                                            obj_build.SetBoneDetail(name_obj2.ToString(), tform2, name_obj1.ToString());

                                                            // check if more than two children, this would mean there's a sub-bone
                                                            if (Armature_par.Children[ix].Children[ch0].Children[ch1].Children.Length > 2)
                                                            {
                                                                for (int ch2 = 1; ch2 < Armature_par.Children[ix].Children[ch0].Children[ch1].Children.Length; ch2++)
                                                                {
                                                                    object child_ID_obj3; Armature_par.Children[ix].Children[ch0].Children[ch1].Children[ch2].GetParameter("id", out child_ID_obj3);
                                                                    if (child_ID_obj3 != null)
                                                                    {
                                                                        if (child_ID_obj3.ToString().Contains("_armature"))
                                                                        {
                                                                            object name_obj3; Armature_par.Children[ix].Children[ch0].Children[ch1].Children[ch2].GetParameter("name", out name_obj3);
                                                                            string[] break_tform3 = Armature_par.Children[ix].Children[ch0].Children[ch1].Children[ch2].Children[0].Contents.ToString().Split(' ');
                                                                            double[] tform3 = new double[break_tform3.Length];
                                                                            for (int tx3 = 0; tx3 < tform3.Length; tx3++)
                                                                            {
                                                                                Double.TryParse(break_tform3[tx3], out tform3[tx3]);
                                                                            }
                                                                            obj_build.SetBoneDetail(name_obj3.ToString(), tform3, name_obj2.ToString());

                                                                            // check if more than two children, this would mean there's a sub-bone
                                                                            if (Armature_par.Children[ix].Children[ch0].Children[ch1].Children[ch2].Children.Length > 2)
                                                                            {
                                                                                for (int ch3 = 1; ch3 < Armature_par.Children[ix].Children[ch0].Children[ch1].Children[ch2].Children.Length; ch3++)
                                                                                {

                                                                                }
                                                                            }
                                                                        }
                                                                    }


                                                                }
                                                            }
                                                        }
                                                    }


                                                }
                                            }
                                        }
                                    }
                                    
                                }
                            }
                        }
                    }

                    
                }

                // hopefully all set ;-;
            }

            if (geometry_data && armature_data)
            {
                obj3d = obj_build;
                return true;
            }

            obj3d = null;
            return false;
        }

    }
}
