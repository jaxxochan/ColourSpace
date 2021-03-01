using System.Configuration;

namespace CS.Core.DataAccess
{
    public interface IDbConfiguration
    {
        string MainDatabase { get; }
    }

    public class DataAccessConfiguration : ConfigurationSection, IDbConfiguration
    {
        [ConfigurationProperty("mainDatabase")]
        public string MainDatabase
        {
            get
            {
                return "data source=LAPTOP-62OFV8HE\\SQLEXPRESS;initial catalog=DEMO_DB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;";
            }
            set
            {
                this["mainDatabase"] = value;
            }
        }
    }
}
