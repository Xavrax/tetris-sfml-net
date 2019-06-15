using System.Collections.Generic;
using Tetris.Models.Gameplay;
using Sfg = SFML.Graphics;
using Sfs = SFML.System;

namespace Tetris.Views.Gameplay
{
    public class WorldView : ISceneEntity
    {
        private Sfg.RectangleShape _background;
        public Sfs.Vector2f Position { get; set; }
        public List<Sfg.RectangleShape> _views;

        public WorldView(IWorld world)
        {
            _background = new Sfg.RectangleShape(new Sfs.Vector2f(300f, 480f))
            {
                FillColor = Sfg.Color.Black,
                OutlineThickness = 20f,
                OutlineColor = new Sfg.Color(212, 175, 55)
            };
            _views = new List<Sfg.RectangleShape>();
            Position = new Sfs.Vector2f(-100, -100);
            for (var y = 0; y < World.WorldBounds.Y; y++)
            {
                for (var x = 0; x < World.WorldBounds.X; x++)
                {
                    if (!world.Matrix[y, x])
                    {
                        continue;
                    }
                    
                    var position = new Sfs.Vector2f(x * 30, y * 30);
                    var view = new Sfg.RectangleShape(new Sfs.Vector2f(28f, 28f))
                    {
                        FillColor = Sfg.Color.White,
                        Position = position,
                        OutlineThickness = 2f,
                        OutlineColor = Sfg.Color.Black
                    };
                    _views.Add(view);
                }
            }
        }
        
        public void Draw(Sfg.RenderTarget target, Sfg.RenderStates states)
        {
            target.Draw(_background);
            foreach (var view in _views)
            {
                target.Draw(view, states);
            }
        }
    }
}