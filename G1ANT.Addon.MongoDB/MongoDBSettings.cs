using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1ANT.Addon.MongoDB
{
    public sealed class MongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        private MongoDBSettings()
        {
        }

        private static readonly MongoDBSettings instance = null;
        static MongoDBSettings()
        {
            instance = new MongoDBSettings();
        }

        public static MongoDBSettings GetInstance()
        {
            return instance;
        }

    }


}
