using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Microsoft.Data.Sqlite;
using Mocky.API.ViewModels;

namespace Mocky.API.Data
{
    public interface IMockyRepository
    {
        Guid Create(CreateUpdateMock mock);
        Mock Get(Guid id);
    }

    public class MockyRepository : IMockyRepository
    {
        private readonly DataConfig _config;

        public MockyRepository(DataConfig config)
        {
            _config = config;
        }

        public Guid Create(CreateUpdateMock mock)
        {
            var newId = Guid.NewGuid();
            var content = Encoding.GetEncoding(mock.Charset).GetBytes(mock.Content);
            var now = DateTime.UtcNow;
            DateTime? expireAt = mock.Expiration == Expiration.Never ? null : now.AddDays((int)mock.Expiration);
            var headers = JsonSerializer.Serialize(mock.Headers);

            using var connection = new SqliteConnection(_config.ConnectionString);
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = Sql.INSERT;
            cmd.Parameters.AddWithValue("$id", newId.ToString());
            cmd.Parameters.AddWithValue("$name", mock.Name);
            cmd.Parameters.AddWithValue("$content", content);
            cmd.Parameters.AddWithValue("$content_type", mock.ContentType);
            cmd.Parameters.AddWithValue("$charset", mock.Charset);
            cmd.Parameters.AddWithValue("$status", mock.Status);
            cmd.Parameters.AddWithValue("$headers", headers);
            cmd.Parameters.AddWithValue("$created_at", now);
            cmd.Parameters.AddWithValue("$expire_at", expireAt);
            cmd.Parameters.AddWithValue("$secret_token", mock.Secret);
            cmd.Parameters.AddWithValue("$hash_ip", "TODO:haship");
            cmd.Prepare();

            var rowsEffected = cmd.ExecuteNonQuery();
            if (rowsEffected == 0)
            {
                throw new ApplicationException("Failed to insert mocky");
            }
            return newId;
        }

        public Mock Get(Guid id)
        {
            using var connection = new SqliteConnection(_config.ConnectionString);
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = Sql.GET;
            cmd.Parameters.AddWithValue("$id", id.ToString());

            var mock = new Mock();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    mock.Charset = (string)reader["charset"];
                    mock.Status = (int)(long)reader["status"];
                    mock.ContentType = (string)reader["content_type"];
                    mock.Content = Encoding.GetEncoding(mock.Charset).GetString((byte[])reader["content"]);
                    mock.Headers = JsonSerializer.Deserialize<Dictionary<string, string>>((string)reader["headers"]);
                }
            }

            return mock;
        }
    }
}
