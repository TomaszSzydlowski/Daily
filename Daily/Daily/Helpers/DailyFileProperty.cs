namespace Daily.Helpers
{
    public class DailyFileProperty
    {
        protected string FilePath => AppSettings.GetInstance().Read("FileDirectory");

    }
}
