using Daily.Model;
using System.Collections.Generic;

namespace Daily.View
{
    public interface IViewBase
    {
        void Show(List<TaskRepo> taskRepos);
    }
}