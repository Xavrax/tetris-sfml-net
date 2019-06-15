using System;
using Sfs = SFML.System;

namespace Tetris.Models.Utilities.Scheduler
{
    public class RecurrentScheduler : IScheduler
    {
        public Action ToExecute { get; set; }
        public Sfs.Time ElapsedTime { get; set; }
        public Sfs.Time Timeout { get; set; }

        public ScheduledTaskBuilder Schedule()
        {
            return new ScheduledTaskBuilder(this);
        }
        public void UpdateCurrent(Sfs.Time dt)
        {
            ElapsedTime += dt;
            
            if (ElapsedTime <= Timeout)
            {
                return;
            }
            
            ToExecute();
            ElapsedTime = Sfs.Time.Zero;
        }
    }
}