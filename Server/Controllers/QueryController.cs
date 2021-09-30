using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private DataContext _ctx;
        public QueryController(DataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost]
        public async Task<string> Post([FromBody] string[] tables)
        {
            var tableList = tables.Select(i => i.ToUpper()).ToArray();
            List<string> errors = new();
            var relations = _ctx.TableRelations.Where(i => tableList.Contains( i.ParentTable.ToUpper()) || tableList.Contains(i.ChildTable.ToUpper())).ToList();
            for (int i = 0; i < tableList.Length; i++)
            {
                var table = tableList[i];

                if (!relations.Where(r=> 
                    (r.ParentTable.ToUpper() == table && tableList.Contains(r.ChildTable.ToUpper())) ||
                    (r.ChildTable.ToUpper() == table && tableList.Contains(r.ParentTable.ToUpper()))
                    ).Any())
                {
                    errors.Add(table);
                }
            }
            if (errors.Count == 0)
            {
                return "No errors";
            }
            else
            {
                return $"The folowing tables doesnt have valid relations {string.Join(',', errors)}";
            }


        }

    }
}
