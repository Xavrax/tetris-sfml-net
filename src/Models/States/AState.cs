using System.Collections.Generic;
using SFML.System;

namespace Tetris.Models.States
{
    public abstract class AState : IState
    {
        public StateCondition Condition { get; set; }
        public IState SwitchToThis { get; private set; }
        protected List<IUpdatable> Updatables { get; }

        public string Name { get; protected set; }

        protected AState()
        {
            Condition = StateCondition.Running;
            SwitchToThis = null;
            Updatables = new List<IUpdatable>();
        }

        public void SwitchState(IState state)
        {
            Condition = StateCondition.Switching;
            SwitchToThis = state;
        }

        public virtual void Update(Time dt)
        {
            foreach (var updatable in Updatables)
            {
                updatable.UpdateCurrent(dt);
            }
        }

        public virtual void OnLeftClick()
        {
            // do nothing
        }

        public virtual void OnRightClick()
        {
            // do nothing
        }

        public virtual void OnUpClick()
        {
            // do nothing
        }

        public virtual void OnDownClick()
        {
            // do nothing
        }

        public virtual void OnSpaceClick()
        {
            // do nothing
        }
    }
}