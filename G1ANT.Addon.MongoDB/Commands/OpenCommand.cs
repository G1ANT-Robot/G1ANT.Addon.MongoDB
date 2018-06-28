using G1ANT.Language;
using MongoDB.Driver;
using System;
using System.Linq;

namespace G1ANT.Addon.MongoDB
{
    [Command(Name = "mongodb.init", Tooltip = "Set parameters for MongoDB connection")]
    public class OpenCommand : Command
    {
  
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Connections string for using MongoDB")]
            public TextStructure connectionString { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = true, Tooltip = "Database name")]
            public TextStructure databaseName { get; set; } = new TextStructure(string.Empty);

        }

        public OpenCommand(AbstractScripter scripter) : base(scripter)
        {
        }

        public void Execute(Arguments arguments)
        {
            MongoDBSettings.GetInstance().ConnectionString = arguments.connectionString.Value;
            MongoDBSettings.GetInstance().DatabaseName = arguments.databaseName.Value;
            try
            {
                var connectionString = MongoDBSettings.GetInstance().ConnectionString;
                var client = new MongoClient(connectionString);
                var dbList = client.ListDatabases().ToList().Select(db => db.GetValue("name").AsString);
                bool isDbExists = dbList.Contains(arguments.databaseName.Value);
                if (!isDbExists)
                {
                    throw new Exception(String.Format("Database {0} not found", arguments.databaseName.Value));
                }
            }
            catch (Exception exc)
            {
                throw new ApplicationException($"Error occured init command :" + exc.Message);
            }
        }
    }
}
