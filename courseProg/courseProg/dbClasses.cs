using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseProg
{
    public class dbClasses
    {
        public int User_id;
        public string first_name;
        public string last_name;
        public string email_id;

    }

    public class classLevel
    {
        public int l_id;
        public string l_name;
    }
    public class classTopic
    {
        public int t_id;
        public string t_name;
    }

    public class classQuiz
    {
        public int q_id;
        public string q_ques;
        public int q_topic;
        public int q_level;
        public string correctOpt;
        public string Opt1;
        public string Opt2;
        public string Opt3;
        public string Opt4;
        public int q_type;
    }
    public class classCourse
    {
        public int c_id;
        public string c_name;
        public int c_topic;
        public int c_level;
        public string c_desc;
        public string ytb_link1;
        public string ytb_link2;
        public string ytb_link3;
        public string c_exam;
        public string faq1;
        public string faq2;
        public string faq3;
    }
}
