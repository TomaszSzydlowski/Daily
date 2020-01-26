using System.Xml.Linq;

namespace Daily.Actions
{
    public interface IActionBase
    {
        XDocument XDoc { get; set; }

        public void Exec(XDocument xDoc,string arg);
    }
}
