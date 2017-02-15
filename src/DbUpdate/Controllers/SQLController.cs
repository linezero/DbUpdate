using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DbUpdate.Common;
using DbUpdate.Model;
using System.Text;
using DbUpdate.ViewModel;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DbUpdate.Controllers
{
    [Route("api/[controller]")]
    public class SQLController : Controller
    {
        private DataContext _context;
        public SQLController(DataContext context)
        {
            _context = context;
        }
        // GET: api/sql
        [HttpGet]
        public string Get(int start,int end)
        {
            var list = _context.SQLScripts.Where(r => r.Id >= start && r.Id <= end).ToList();
            StringBuilder sqlsb = new StringBuilder("/****** Script for Build from DbUpdate  ******/");
            foreach (var item in list)
            {
                sqlsb.AppendLine(item.CleanScript);
                sqlsb.AppendLine(item.Script);
            }
            return sqlsb.ToString();
        }

        [HttpGet]
        [Route("database")]
        public IActionResult GetDatabase(string name)
        {
            var config = _context.SQLConfigs.FirstOrDefault(r => r.Name.Equals(name));
            if (config == null)
                return NotFound();
            var databases = new DapperHelper(config.Connection).Query("SELECT Name FROM Master.dbo.SysDatabases WHERE dbid>4");
            return Ok(databases);
        }

        // GET api/sql/dbname
        [HttpGet("{dbname}")]
        public List<int> Get(string dbname)
        {
            return _context.SQLScripts.Where(r=>r.Database.Equals(dbname)).Take(20).Select(r=>r.Id).ToList();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]SQLScriptModel script)
        {
            if (!ModelState.IsValid)
                return NotFound();
            _context.SQLScripts.Add(new SQLScript() {
                CleanScript=script.CleanScript,
                Script=script.Script,
                Comment=script.Comment,
                Database=script.Database,
                CreateOn=DateTime.Now
            });
            _context.SaveChanges();
            return Created("api/sql/version/", script);
        }
    }
}
