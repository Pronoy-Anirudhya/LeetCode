using Microsoft.Data.Sqlite;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PhoenixDataValidatorService
{
    public class SQLiteCommunicator
    {
        public void ReadData()
        {
            SqliteConnection sqlite_conn = new SqliteConnection("Data Source=D:\\Software\\SQLitePortable\\TempDB.db;");
            sqlite_conn.Open();

            SqliteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT NAME_EN, USER_PIN from USER_PROFILE";

            using (var reader = sqlite_cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var c1 = reader.GetString(0);
                    var c2 = reader.GetInt32(1);

                    Console.WriteLine("C1:" + c1);
                    Console.WriteLine("C2:" + c2);
                }
            }

            sqlite_conn.Close();
        }
    }
}