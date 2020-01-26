using System.Xml.Linq;

namespace Daily.Actions
{
    public class UpdateXDoc
    {
        private static UpdateXDoc instance=new UpdateXDoc();

        public XDocument advancedXDocument { get; set; }

        private UpdateXDoc()
        {

        }

        public UpdateXDoc GetInstance()
        {
            return instance;
        }

    }
}
