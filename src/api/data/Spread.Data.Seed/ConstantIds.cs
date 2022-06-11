using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Data.Seed
{
    public static class ConstantIds
    {
        public class User
        {
            public static Guid AdminId = new Guid("63F34CCB-C779-4C82-A1AE-A76C5248BF23");
        }

        public class LookupType
        {
            public static Guid CountryId = new Guid("C868A137-EFAD-446A-8A62-211574F51241");
            public static Guid CityId = new Guid("AA2BE2D9-CBB8-4D19-813F-E17B843853F3");
            public static Guid CountyId = new Guid("6136224D-139B-4F14-A76A-1CEB95F42BF1");
        }

        public class Lookup
        {
            public static Guid TurkiyeId = new Guid("EC534A08-824C-4F56-9E7A-F0E4C235C3E6");
            public static Guid AnkaraId = new Guid("BE7B98C3-DBB4-449B-8EAE-F23E739321EE");
        }
    }
}
