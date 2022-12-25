using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.IO
{
    public struct Armature_bone
    {
        public string Name;
        public Bone_type_ident bone_type;
        public string Parent_Name;
        public string[] Link_Children;
        public double[] Pose; // this should be 16 long ALWAYS
        public double[] Transform; // this should be 16 long ALWAYS
        public double[] Head; // 3 long array
        public double[] Tail; // 3 long array
        public double[] Axis_T; // all three
        public double[] Axis_P; // all three
        public double[] Axis_R; // all three
        public bool axi_res;
    }

    public enum Bone_type_ident
    {
        
        UNKNOWN          =  0,
        BODY_MAIN        =  1,
        HEAD             =  2,
        EYE              =  3,
        FRONT_SHOULDER   =  4,
        FRONT_MIDLIMB    =  6,
        FRONT_FORELIMB   =  5,
        FRONT_FOOT       =  7,
        BACK_SHOULDER    =  8,
        BACK_MIDLIMB     =  9,
        BACK_FORELIMB    = 10,
        BACK_FOOT        = 11,
        TAIL_BASE        = 12,
        TAIL_SEGMENT     = 13,
        TAIL_TIP         = 14,
        WING_SHOULDER    = 15,
        WING_SEGMENT     = 16,
        WING_TIP         = 17,
        VERTEBRA_TOP     = 18,
        VERTEBRA_BOTTOM  = 19,
        ARM_SHOULDER     = 20,
        ARM_MIDLIMB      = 21,
        ARM_FORELIMB     = 22,
        ARM_HAND         = 23,
        BIPED_UPPERLEG   = 24,
        BIPED_LOWERLEG   = 25,
        BIPED_FOOT       = 26,
        PHYSICS_DRAPED   = 27,
        PHYSICS_DAMPENED = 28
    }
}
