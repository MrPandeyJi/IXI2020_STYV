using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseProg
{
    public class dbHelperClass
    {
        public static string dbname = "prepdb.db";
        public static void addUsertoDB(dbClasses obj)
        {
            using (var conn = new SQLiteConnection(dbname))
            {
                using (var statement = conn.Prepare(@" insert into Users
                                                    (first_name,last_name,email_id)
                                                     values(?,?,?);                                                    
                                                    "))
                {
                    statement.Bind(1, obj.first_name);
                    statement.Bind(2, obj.last_name);
                    statement.Bind(3, obj.email_id);

                    statement.Step();
                }
            }
        }

        public static void getUsers(ObservableCollection<dbClasses> obcUsers)
        {
            using (var conn = new SQLiteConnection(dbname))
            {
                using (var query = conn.Prepare(@"select * from users ;"))
                {
                    while (query.Step() == SQLiteResult.ROW)
                    {
                        obcUsers.Add(new dbClasses
                        {
                            User_id = Convert.ToInt32(query[0].ToString()),
                            first_name = query[1].ToString(),
                            last_name = query[2].ToString()

                        });

                    }
                }
            }
        }

        public static classQuiz getQuestions(classQuiz objQuiz, int q_id)
        { 
            using (var conn = new SQLiteConnection(dbname))
            {
                using (var query = conn.Prepare(string.Format(@"select * from quiz where q_id = {0};", q_id)))
                {
                    while (query.Step() == SQLiteResult.ROW)
                    {
                        objQuiz = new classQuiz
                        {
                            q_id = Convert.ToInt32(query[0].ToString()),
                            q_ques = query[1].ToString(),
                            q_topic = Convert.ToInt32(query[2].ToString()),
                            q_level = Convert.ToInt32(query[3].ToString()),
                            correctOpt = query[4].ToString(),
                            Opt1 = query[5].ToString(),
                            Opt2 = query[6].ToString(),
                            Opt3 = query[7].ToString(),
                            Opt4 = query[8].ToString(),
                            q_type = Convert.ToInt32(query[9].ToString())
                        };
                    }
                }
            }
            return objQuiz;
        }

        public static void getBeginQuest(ObservableCollection<classCourse> obcQuest)
        {
            using (var conn = new SQLiteConnection(dbname))
            {
                using (var query = conn.Prepare(string.Format(@"select * from course where c_level = {0};", UtilityData.currentCourse)))
                {
                    while (query.Step() == SQLiteResult.ROW)
                    {
                        obcQuest.Add(new classCourse
                        {
                            c_id = Convert.ToInt32(query[0].ToString()),
                            c_name = query[1].ToString(),
                            c_topic = Convert.ToInt32(query[2].ToString()),
                            c_level = Convert.ToInt32(query[3].ToString())
                            //c_desc = query[4].ToString(),
                            //ytb_link1 = query[5].ToString(),
                            //ytb_link2 = query[6].ToString(),
                            //ytb_link3 = query[7].ToString(),
                            //c_exam = query[8].ToString(),
                            //faq1 = query[9].ToString(),
                            //faq2 = query[10].ToString(),
                            //faq3 = query[11].ToString()
                        });
                    }
                }
            }
        }
        public static void addLevelsdb(classLevel obj)
        {
            using (var conn = new SQLiteConnection(dbname))
            {
                using (var statement = conn.Prepare(@" insert into level
                                                    (l_name)
                                                     values(?);                                                    
                                                    "))
                {
                    statement.Bind(1, obj.l_name);

                    statement.Step();
                }
            }
        }

        public static void addTopicdb(classTopic obj)
        {
            using (var conn = new SQLiteConnection(dbname))
            {
                using (var statement = conn.Prepare(@" insert into topic
                                                    (t_name)
                                                     values(?);                                                    
                                                    "))
                {
                    statement.Bind(1, obj.t_name);

                    statement.Step();
                }
            }
        }

    }
}
