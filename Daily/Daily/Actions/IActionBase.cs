using System.Xml.Linq;

namespace Daily.Actions
{
    public interface IActionBase
    {
        public void Exec(XDocument xDoc,string arg);
    }
}
