using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Data.DataBase
{
    public class Database<T>
    {
        private readonly string _connectionKey;

        public Database()
        {
            _connectionKey = "Data Source=Data.db;Version=3";
        }

        public T Get(int id)
        {
            using (var connection = new SQLiteConnection(_connectionKey))
            {
                connection.Open();

                string tableName = typeof(T).Name+"s";;
                string query = $"SELECT * FROM {tableName} WHERE Id = @Id";

                var result = connection.QueryFirstOrDefault<T>(query, new { Id = id });
                return result;
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var connection = new SQLiteConnection(_connectionKey))
            {
                connection.Open();

                string tableName = typeof(T).Name+"s";;
                string query = $"SELECT * FROM {tableName}";

                var result = connection.Query<T>(query);
                return result;
            }
        }

        public void Insert(T entity)
        {
            using (var connection = new SQLiteConnection(_connectionKey))
            {
                connection.Open();

                string tableName = typeof(T).Name+"s";
                string columns = string.Join(", ", typeof(T).GetProperties().Select(p => p.Name));
                string values = string.Join(", ", typeof(T).GetProperties().Select(p => $"@{p.Name}"));

                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

                connection.Execute(query, entity);
            }
        }

        public void Update(T entity)
        {
            using (var connection = new SQLiteConnection(_connectionKey))
            {
                connection.Open();

                string tableName = typeof(T).Name+"s";;
                string columns = string.Join(", ", typeof(T).GetProperties().Select(p => $"{p.Name} = @{p.Name}"));
                string query = $"UPDATE {tableName} SET {columns} WHERE Id = @Id";

                connection.Execute(query, entity);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(_connectionKey))
            {
                connection.Open();

                string tableName = typeof(T).Name+"s";;
                string query = $"DELETE FROM {tableName} WHERE Id = @Id";

                connection.Execute(query, new { Id = id });
            }
        }
    }
}