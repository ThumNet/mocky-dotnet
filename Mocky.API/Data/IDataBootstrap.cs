using System;
using Microsoft.Data.Sqlite;

namespace Mocky.API.Data
{
    public interface IDataBootstrap
    {
        void Setup();
    }

    public class DataBootstrap : IDataBootstrap
    {
        private readonly DataConfig _config;

        public DataBootstrap(DataConfig config)
        {
            _config = config;
        }

        public void Setup()
        {
            using var connection = new SqliteConnection(_config.ConnectionString);
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = Sql.CHECK_TABLE_EXISTS;
            var count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count != 0)
            {
                return;
            }

            cmd.CommandText = Sql.CREATE_TABLE;
            cmd.ExecuteNonQuery();

            // Enable write-ahead logging
            cmd.CommandText = "PRAGMA journal_mode = 'wal'";
            cmd.ExecuteNonQuery();
        }
    }
}
