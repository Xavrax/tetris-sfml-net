using Sfg = SFML.Graphics;
using Sfs = SFML.System;

namespace Tetris.Views
{
    public interface ISceneEntity : Sfg.Drawable
    {
        Sfs.Vector2f Position { get; set; }
    }
}