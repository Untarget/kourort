using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    internal class Cookies
    {
        static private string Firstname;
        public static string firstname { get { return Firstname; } set { Firstname = value; } }
        static private string Secondname;
        public static string secondname { get { return Secondname; } set { Secondname = value; } }
        static private string Lastname;
        public static string lastname { get { return Lastname; } set { Lastname = value; } }
        static private int Post;
        public static int post { get { return Post; } set { Post = value; } }
        static private int iD;
        public static int ID { get { return iD; } set { iD = value; } }
        static private int kourort_iD;
        public static int kourort_ID { get { return kourort_iD; } set { kourort_iD = value; } }

    }
}
