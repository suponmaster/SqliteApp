using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteApp
{
    class DataAccess
    {
        public static void InitializeDatabase()
        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=CustomersData.db"))
            {
                db.Open();
                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Customers (uID INTEGER PRIMARY KEY, " +
                    "firstName NVARCHAR(30), " +
                    "lastName NVARCHAR(30), " +
                    "email NVARCHAR(50))";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public static void AddData(string inputfirstName, string inputlastName, string inputemail)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=CustomersData.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Customers VALUES (NULL, @firstName, @lastName, @email);";
                insertCommand.Parameters.AddWithValue("@firstName", inputfirstName);
                insertCommand.Parameters.AddWithValue("@lastName", inputlastName);
                insertCommand.Parameters.AddWithValue("@email", inputemail);

                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        public static List<String> GetData()
        {
            List<String> entries = new List<string>();

            using (SqliteConnection db = new SqliteConnection("filename=CustomersData.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Customers", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                    entries.Add(query.GetString(3));
                }

                db.Close();
            }
            return entries;
        }
    }
}
