using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ExampleSqlConnection
{
    public class InfoPersonRepository
    {
        private readonly string _connectionString;

        public InfoPersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetOpenedSqlConnection()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            return sqlConnection;
        }

        public void AddUser(string name, int age)
        {
            using (var sqlConnection = GetOpenedSqlConnection())
            {

                var sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "InsertUsers";


                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@age", age);
                var result = sqlCommand.ExecuteScalar();

                Console.WriteLine($"Id добавленного пользователя: {result}");
            }
        }
        public void GetUsers()
        {
            using (var sqlConnection = GetOpenedSqlConnection())
            {
                var sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "GetUsers";

                var reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(0)}, {reader.GetName(1)}, {reader.GetName(2)}");

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int age = reader.GetInt32(2);
                        Console.WriteLine($"{id} {name} {age}");
                    }
                }
                reader.Close();
            }
        }
    }
}





