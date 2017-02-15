using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbUpdate.Model
{
    public class SQLConfig
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Connection { get; set; }
        public int Version { get; set; }
    }
}
