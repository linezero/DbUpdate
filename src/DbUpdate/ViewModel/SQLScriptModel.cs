using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DbUpdate.ViewModel
{
    public class SQLScriptModel
    {
        [Required]
        public string Database { get; set; }
        [Required]
        public string Script { get; set; }
        [Required]
        public string CleanScript { get; set; }
        public string Comment { get; set; }
    }
}
