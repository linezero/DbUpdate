using System;

namespace DbUpdate.Model
{
    public class SQLScript
    {
        public int Id { get; set; }
        public string Database { get; set; }
        public int Version { get; set; }
        public string Script { get; set; }
        public string CleanScript { get; set; }
        public string Comment { get; set; }
        public DateTime CreateOn { get; set; }
        public SQLConfig Config { get; set; }
    }
}
