using System;
namespace Mocky.API
{
    public class Sql
    {
        public const string CREATE_TABLE = @"CREATE TABLE mocks_v3(
                id CHAR(36) NOT NULL,
                name VARCHAR(100),
                content TEXT,
                content_type VARCHAR(200) NOT NULL,

                status INT NOT NULL,
                charset VARCHAR(100) NOT NULL,
                headers TEXT,
            
                secret_token VARCHAR(64),
                hash_ip VARCHAR(100),
            
                created_at DATETIME NOT NULL,
                last_access_at DATETIME,
                expire_at DATETIME,

                total_access BIGINT,
            
                PRIMARY KEY(id)
            );";

        public const string CHECK_TABLE_EXISTS = @"SELECT COUNT(*) FROM sqlite_master WHERE type='table' and name='mocks_v3'";

        public const string INSERT = @"INSERT INTO mocks_v3
            (id, name, content, content_type, status, charset, headers, created_at, expire_at, total_access, secret_token, hash_ip)
          VALUES
            ($id, $name, $content, $content_type, $status, $charset, $headers, $created_at, $expire_at, 0, $secret_token, $hash_ip)";

        public const string GET = @"SELECT content, content_type, status, charset, headers
            FROM mocks_v3
            WHERE id=$id";
        
        public const string UPDATE = @"UPDATE mocks_v3
          SET
            name = $name,
            content = $content,
            content_type = $content_type,
            status = $status,
            charset = $charset,
            headers = $headers,
            hash_ip = $hash_ip,
            expire_at = $expire_at
          WHERE id = $id AND secret_token = $secret_token";

        public const string DELETE = "DELETE FROM mocks_v3 WHERE id = $id and secret_token = $secret_token";

        public const string GET_STATS = "SELECT created_at, last_access_at, total_access FROM mocks_v3 WHERE id = $id";

        public const string UPDATE_STATS = "UPDATE mocks_v3 SET last_access_at = $last_access_at, total_access = total_access + 1 WHERE id = $id";

        public const string ADMIN_STATS = @"SELECT
            COUNT(*) as nb_mocks,
            SUM(total_access) as total_access,
            SUM(case when last_access_at > date('now', '-1 month') then 1 else 0 end) as nb_mocks_accessed_in_month,
            SUM(case when created_at > date('now', '-1 month') then 1 else 0 end) as nb_mocks_created_in_month,
            SUM(case when last_access_at IS NULL then 1 else 0 end) as nb_mocks_never_accessed,
            SUM(case when last_access_at IS NULL OR  last_access_at < DATE('now', '-1 year') then 1 else 0 end) as nb_mocks_not_accessed_in_year,
            COUNT(distinct hash_ip) as nb_distinct_ips,
            ROUND(AVG(LENGTH(content))) as mock_average_length
          FROM mocks_v3";
    }
}
