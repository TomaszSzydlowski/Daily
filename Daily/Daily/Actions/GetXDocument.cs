using Daily.Helpers;
using Daily.Helpers.Interfaces;
using System.Xml.Linq;

namespace Daily.Actions
{

    public sealed class GetXDocument : DailyFileProperty, IGetXDocument
    {
        private static GetXDocument instance = new GetXDocument();



        private GetXDocument()
        {

        }

        public static GetXDocument GetInstance()
        {
            return instance;
        }

        public XDocument Get()
        {
            return XDocument.Load(FilePath);
        }
    }
}
