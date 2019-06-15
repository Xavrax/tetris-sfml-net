using System;

namespace Tetris.Models.Utilities.Scheduler
{
    public class ConditionTaskBuilder
    {
        private IScheduler _scheduler;
        private Func<bool> _predicate;

        public ConditionTaskBuilder(IScheduler scheduler, Func<bool> predicate)
        {
            _scheduler = scheduler;
            _predicate = predicate;
        }

        public IScheduler Execute(Action toExecute)
        {
            ((ConditionScheduler) _scheduler).ToExecute += toExecute;
            ((ConditionScheduler) _scheduler).Predicate = _predicate;
            return _scheduler;
        }
    }
}