using System;
using Sfs = SFML.System;

namespace Tetris.Models.Utilities.Scheduler
{
    public class RecurrentTaskBuilder
    {
        private IScheduler _scheduler;
        private Sfs.Time _timeout;
        
        
        
        public RecurrentTaskBuilder(IScheduler scheduler, Sfs.Time time)
        {
            _scheduler = scheduler;
            _timeout = time;
        }

        public IScheduler Execute(Action toExecute)
        {
            ((RecurrentScheduler) _scheduler).ToExecute += toExecute;
            ((RecurrentScheduler) _scheduler).Timeout = _timeout;
            return _scheduler;
        }
    }
}