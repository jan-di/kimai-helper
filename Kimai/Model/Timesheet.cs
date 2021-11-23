using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimaiHelper.Kimai.Model
{
    public class Timesheet
    {
        public int Id { get; set; }

        public DateTime Begin { get; set; }

        public DateTime? End { get; set; }

        public Project Project { get; set; }
    }
}
