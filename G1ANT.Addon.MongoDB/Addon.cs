using G1ANT.Language;

namespace G1ANT.Addon.MongoDB
{
    [Addon(Name = "MongoDB", Tooltip = "Addon for MongoDB operations")]
    [Copyright(Author = "Marian Witkowski", Copyright = "(c) 2017 Marian Witkowski", Email = "marian.witkowski@gmail.com")]
    [License(Type = "LGPL", ResourceName = "License.txt")]
    [CommandGroup(Name = "mongodb", Tooltip = "Command connected with MongoDB operations")]

    public class Addon : Language.Addon
    {
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
