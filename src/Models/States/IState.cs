using System;
using Sfs = SFML.System;

namespace Tetris.Models.States
{
    public interface IState
    {
        StateCondition Condition { get; set; }
        IState SwitchToThis { get; }
        String Name { get; }
        void OnLeftClick();
        void OnRightClick();
        void OnUpClick();
        void OnDownClick();
        void OnSpaceClick();
        void Update(Sfs.Time dt);
    }
}