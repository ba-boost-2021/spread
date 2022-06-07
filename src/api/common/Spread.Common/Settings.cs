namespace Spread.Common;

public class Settings
{
    public DatabaseConfiguration Database { get; set; }
    public string Environment { get; set; }

    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; }
    }
}