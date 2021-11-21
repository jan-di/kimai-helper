using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimaiHelper.Kimai.Model
{
    public class ServerVersion
    {
        public System.Version Version { get; set; }

        public int VersionId { get; set; }

        public string Semver { get; set; }

        public string Candidate { get; set; }

        public string Name { get; set; }

        public string Copyright { get; set; }
    }
}
