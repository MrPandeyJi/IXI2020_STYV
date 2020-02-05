using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseProg
{
    public static class UtilityData
    {
        public static dbClasses objCurrentUser = new dbClasses();
        public static classCourse objCurrentCourse = new classCourse(); 
        public static string dbname = "prepdb.db";
        public static int currentCourse = 1;
        public static int trackBeginner;
        public static int trackIntermidiate;
        public static int trackAdvances;
        public static bool isBeginDone, isIntermdiateDone, isAdvancedDone = false;
    }
}
