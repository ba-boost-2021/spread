namespace Spread.Common;

public class Settings
{
    public DatabaseConfiguration Database { get; set; }
    public JwtConfiguration Jwt { get; set; }
    public S3Configuration S3 { get; set; }
    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; }
    }

    public class JwtConfiguration
    {
        public string Key { get; set; }
        public int ExpiresInMinutes { get; set; }
    }
    public class S3Configuration
    {
        public string Url { get; set; }
        public string ClientUrl { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
    }
}
