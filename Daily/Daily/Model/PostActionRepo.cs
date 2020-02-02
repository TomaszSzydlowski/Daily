using System.Collections.Generic;
using System.Xml.Linq;

namespace Daily.Model
{
   public class PostActionRepo
    {
        public XDocument XDoc { get; set; }
        public List<TaskRepo> TaskRepos { get; set; }
    }
}
