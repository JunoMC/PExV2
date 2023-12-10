using System.Text;

namespace PExV2
{
    internal static class Program
    {
        private static Dictionary<string, string> sqlInfo = new Dictionary<string, string>()
        {
            { "Server", "103.183.121.131" },
            { "Port", "3306" },
            { "User", "proot" },
            { "Password", "HoangPhucxNhom9" },
            { "Database", "pex" },
        };

        private static string mergeArray(Dictionary<string, string> data)
        {
            string res = "";

            foreach (KeyValuePair<string, string> item in data)
                res += item.Key + "=" + item.Value + ";";

            return res;
        }

        [STAThread]
        static void Main()
        {
            //Console.OutputEncoding = Encoding.UTF8;

            string conn = mergeArray(sqlInfo);
            SqlDatabase mysql = new SqlDatabase(conn);
            mysql.ExecuteQuery("SELECT * FROM `sinh_vien` WHERE `ID` = 1");
            ApplicationConfiguration.Initialize();
            Application.Run(new PExForm1(mysql));
        }
    }
}