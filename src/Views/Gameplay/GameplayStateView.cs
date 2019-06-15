using Tetris.Models.Gameplay;
using Sfg = SFML.Graphics;
using Sfs = SFML.System;

namespace Tetris.Views.Gameplay
{
    public class GameplayStateView : IViewContainer
    {

        public GameplayStateView(GameplayState gameplayState)
        {
            _gameplayState = gameplayState;
            _background = new Sfg.RectangleShape(new Sfs.Vector2f(Game.Resolution.X, Game.Resolution.Y))
            {
                FillColor = new Sfg.Color(25,25,112),
                Position = new Sfs.Vector2f(-680/2f, -320/2f)
            };
            _score = new Sfg.Text(0.ToString(), new Sfg.Font(FontFilePath), CharacterSize)
            {
                Position = new Sfs.Vector2f(400, 0)
            };
        }

        public void Draw(Sfg.RenderTarget target, Sfg.RenderStates states)
        {
            _score.DisplayedString = $"Score: {_gameplayState.Score}";
            target.Draw(_background);
            target.Draw(new WorldView(_gameplayState.World));
            target.Draw(new TerminoView(_gameplayState.World.CurrentPiece));
            target.Draw(_score);
        }


        private Sfg.RectangleShape _background;
        private Sfg.Text _score;
        private GameplayState _gameplayState;
        private const string FontFilePath = "Media/arial.ttf";
        private const int CharacterSize = 32;
    }
}