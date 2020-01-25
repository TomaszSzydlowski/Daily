namespace Daily
{
    public abstract class BaseAction
    {
        protected string FilePath { get => AppSettings.GetInstance().Read("FileDirectory"); }

        public abstract void Exec(string arg);
    }
}
