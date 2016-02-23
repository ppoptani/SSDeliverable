using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;

namespace MessageService
{
    public static class MessagesDatabase
    {
        private static SQLiteConnection m_dbConnection;
        private static bool Connect()
        {
            try
            {
                var path = @"C:\Temp\MyDatabase1.sqlite";
                if (!File.Exists(path))
                {
                    SQLiteConnection.CreateFile(path);
                    m_dbConnection = new SQLiteConnection("Data Source=" + path + ";Version=3;");
                    m_dbConnection.Open();
                    string sql = "create table messages (ID integer PRIMARY KEY AUTOINCREMENT ,message varchar(3000))";
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                }
                else
                {
                    m_dbConnection = new SQLiteConnection("Data Source=" + path + ";Version=3;");
                    m_dbConnection.Open();
                }

            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool Add(string message)
        {
            try
            {
                if (Connect())
                {
                    string sql = "insert into messages (message) values ('" + message + "')";
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }


        public static bool Delete(string ID)
        {
            try
            {
                if (Connect())
                {
                    string sql = "Delete from messages where ID=" + ID;
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static List<Message> Messages()
        {
            List<Message> messages = new List<Message>();
            try
            {
                if (Connect())
                {
                    string sql = "select * from messages";
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        messages.Add(new Message() { ID = int.Parse(reader["ID"].ToString()), Text = reader["message"].ToString() });

                    }
                }
            }
            catch
            {

            }
            finally { m_dbConnection.Close(); }

            return messages;
        }

    }
}