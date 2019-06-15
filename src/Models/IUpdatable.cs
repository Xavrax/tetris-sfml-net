using Sfs = SFML.System;

namespace Tetris.Models
{
    public interface IUpdatable
    {
        void UpdateCurrent(Sfs.Time dt);
    }
}