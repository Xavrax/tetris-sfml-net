using System;
using Sfs = SFML.System;

namespace Tetris.Models.Utilities.Scheduler
{
    public class ScheduledTaskBuilder
    {
        private IScheduler _scheduler;

        public ScheduledTaskBuilder(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }
        
        public RecurrentTaskBuilder Every(Sfs.Time time)
        {
            return new RecurrentTaskBuilder(_scheduler, time);
        }

        public ConditionTaskBuilder When(Func<bool> predicate)
        {
            return new ConditionTaskBuilder(_scheduler, predicate);
        }
    }
}