using System.ComponentModel;

namespace TaskList.Models
{
    public enum TaskStatusViewModel
    {
        [Description("Active")] Active = 1,
        [Description("Concluded")] Concluded = 2,
    }
}