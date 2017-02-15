using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbUpdate.Model
{
    public class SQLBuild
    {
        public int Id { get; set; }
        public string Database { get; set; }
        public int Version { get; set; }
        public string Scripts { get; set; }
        public SQLConfig Config { get; set; }        
    }
}
