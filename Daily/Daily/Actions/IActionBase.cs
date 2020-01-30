using Daily.View;
using System.Xml.Linq;

namespace Daily.Actions
{
    public interface IActionBase
    {
        XDocument XDoc { get; set; }

        void Exec(XDocument xDoc,string arg);
    }
}
