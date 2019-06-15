using System;
using SFML.System;

namespace Tetris.Models.Utilities.Scheduler
{
    public class ConditionScheduler : IScheduler
    {
        public Action ToExecute { get; set; }

        public Func<bool> Predicate { get; set; }

        public ScheduledTaskBuilder Schedule()
        {
            return new ScheduledTaskBuilder(this);
        }

        public void UpdateCurrent(Time dt)
        {
            if (ToExecute == null)
            {
                return;
            }

            if (!Predicate())
            {
                return;
            }
            
            ToExecute();
            ToExecute = null;

        }
    }
}