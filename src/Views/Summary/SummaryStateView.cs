using SFML.System;
using Tetris.Models.Summary;
using Sfg = SFML.Graphics;

namespace Tetris.Views.Summary
{
    public class SummaryStateView : IViewContainer
    {
        public SummaryStateView(SummaryState summaryState)
        {
            _score = new Sfg.Text($"Score: {summaryState.Score}", new Sfg.Font(FontFilePath), CharacterSize)
            {
                Position = new Vector2f(100, 100)
            };
        }
        
        public void Draw(Sfg.RenderTarget target, Sfg.RenderStates states)
        {
            target.Draw(_score, states);
        }

        private Sfg.Text _score;
        private const string FontFilePath = "Media/arial.ttf";
        private const int CharacterSize = 100;
    }
}