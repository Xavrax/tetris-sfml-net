using System;

namespace Tetris.Models.Utilities.Scheduler
{
    public interface IScheduler : IUpdatable
    {
        Action ToExecute { get; set; }
        ScheduledTaskBuilder Schedule();
    }
}