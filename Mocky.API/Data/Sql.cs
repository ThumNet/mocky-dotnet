using System;
namespace Mocky.API
{
    public class Sql
    {
        public const string CREATE_TABLE = @"
CREATE TABLE mocks_v3(

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
    }
}
