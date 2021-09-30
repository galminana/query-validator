using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class TableRelations
    {
        public int Id { get; set; }
        public string ParentTable { get; set; }
        public string ParentTableColumn { get; set; }
        public string ChildTable { get; set; }
        public string ChildTableColumn { get; set; }
    }
}
