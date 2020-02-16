using Daily.Model;
using System.Xml.Linq;

namespace Daily.Helpers.Interfaces
{
    public interface IActionBase
    {
        PostActionRepo Exec(XDocument xDoc, string arg=null);
    }
}
