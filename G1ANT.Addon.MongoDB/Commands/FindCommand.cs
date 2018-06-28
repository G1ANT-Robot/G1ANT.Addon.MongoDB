using G1ANT.Language;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace G1ANT.Addon.MongoDB
{
    [Command(Name = "mongodb.find", Tooltip = "Find documents in MongoDB collection")]
    public class FindCommand : Command
    {
    
        public class Arguments : CommandArguments
        {

            [Argument(Required = true, Tooltip = "Collection name")]
            public TextStructure collection { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Query filter")]
            public TextStructure filter { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Sort parameters")]
            public TextStructure sort { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = false, Tooltip = "Skip records count")]
            public IntegerStructure skip { get; set; } = new IntegerStructure(-1);

            [Argument(Required = false, Tooltip = "Limit records count")]
            public IntegerStructure limit { get; set; } = new IntegerStructure(-1);

            [Argument]
            public VariableStructure Result { get; set; } = new  VariableStructure("result");
        }

        public FindCommand(AbstractScripter scripter) : base(scripter)
        {
        }


        public void Execute(Arguments arguments)
        {
            TextStructure cmdresult = new TextStructure();
            try
            {

                String outData = "[]";
                List<String> jsons = new List<string>(100);

                string ftl = "{}";
                if (!String.IsNullOrWhiteSpace(arguments.filter.Value))
                {
                    ftl = arguments.filter.Value;
                }
                
                string sort = null;
                if (!String.IsNullOrWhiteSpace(arguments.sort.Value))
                {
                    sort = arguments.sort.Value;
                }

                int? skip = null;
                if (arguments.skip.Value>0)
                {
                    skip = arguments.skip.Value;
                }
                
                int? limit = null;
                if (arguments.limit.Value > 0)
                {
                    limit = arguments.limit.Value;
                }

                var connectionString = MongoDBSettings.GetInstance().ConnectionString;
                var client = new MongoClient(connectionString);
                IMongoDatabase db = client.GetDatabase(MongoDBSettings.GetInstance().DatabaseName);
                var collection = db.GetCollection<BsonDocument>(arguments.collection.Value);
                var y = collection.Find(ftl).Skip(skip).Limit(limit).Sort(sort).ToListAsync();
                y.Wait();
                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; 
                int count = y.Result.Count;
                if (count > 0)
                {
                    StringBuilder sb = new StringBuilder(1024);
                    sb.Append("[ ");
                    for (int i = 0; i < count; i++)
                    {
                        sb.Append(y.Result[i].ToJson(jsonWriterSettings));
                        if (i != count - 1)
                        {
                            sb.Append(", ");
                        }
                    }
                    sb.Append(" ]");
                    outData = sb.ToString();
                }

                Scripter.Variables.SetVariableValue(arguments.Result.Value, new TextStructure(outData));
            }
            catch (Exception exc)
            {
                throw new ApplicationException($"Error occured find command :"+ exc.Message);
            }
            return;
        }
    }
}
