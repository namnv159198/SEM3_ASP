using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3_UWP.Models
{
    public class Song
    {
        public String name { get; set; }
        public String singer { get; set; }
        public String author { get; set; }
        public string thumbnail { get; set; }
        public string link { get; set; }
        public long id { get; set; }
        public int status { get; set; }

      
       // public String description { get; set; }
       public List<Song> listSong{ get; set; }
    }
}
