using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antitriche_diplome.projet_eleve
{


    public class Bucket
    {
        public BucketDetail bucketDetail { get; set; }

    }

    public class BucketDetail
    {
        public string id { get; set; }
        public DateTime created { get; set; }
        public object name { get; set; }
        public string type { get; set; }
        public string client { get; set; }
        public string hostname { get; set; }
        public DateTime last_updated { get; set; }
    }

}
