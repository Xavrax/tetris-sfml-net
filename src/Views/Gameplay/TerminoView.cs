using System.Collections.Generic;
using Tetris.Models.Gameplay.Terminos;
using Sfg = SFML.Graphics;
using Sfs = SFML.System;

namespace Tetris.Views.Gameplay
{
    public class TerminoView : ISceneEntity
    {
        public Sfs.Vector2f Position { get; set; }

        public TerminoView(ITermino termino)
        {
            _views = new List<Sfg.RectangleShape>();
            termino.EachBlock(termino.Position, (x, y) =>
            {
                var block = CreateBlock(termino.Color, x, y);
                _views.Add(block);
            });
        }

        public void Draw(Sfg.RenderTarget target, Sfg.RenderStates states)
        {
            foreach (var view in _views)
            {
                target.Draw(view, states);
            }
        }
        
        private Sfg.RectangleShape CreateBlock(Sfg.Color color, int x, int y)
        {
            var position = new Sfs.Vector2f(x * 30, y * 30);
            return new Sfg.RectangleShape(new Sfs.Vector2f(28f, 28f))
            {
                FillColor = color,
                Position = position,
                OutlineThickness = 2f,
                OutlineColor = Sfg.Color.Black
            };
        }

        private List<Sfg.RectangleShape> _views;
    }
}