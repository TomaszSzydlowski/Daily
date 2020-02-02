using Daily.Model;
using Daily.View;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Daily.Actions
{
    public interface IActionBase
    {
        PostActionRepo Exec(XDocument xDoc,string arg);
    }
}
