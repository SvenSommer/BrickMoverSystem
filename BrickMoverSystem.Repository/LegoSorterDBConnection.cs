using System;
using MySql.Data.MySqlClient;

namespace BrickHandler.MySqlRepository
{
    public class LegoSorterDbConnection
    {
        private LegoSorterDbConnection()
        {
        }

        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        private MySqlConnection Connection { get; set; }

        private static LegoSorterDbConnection _instance = null;
        public static LegoSorterDbConnection Instance()
        {
            if (_instance == null)
                _instance = new LegoSorterDbConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(DatabaseName))
                    return false;
                string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}", Server, DatabaseName, UserName, Password);
                Connection = new MySqlConnection(connstring);
                Connection.Open();
            }

            return true;
        }

        public void Close()
        {
            Connection.Close();
        }
    }
}
