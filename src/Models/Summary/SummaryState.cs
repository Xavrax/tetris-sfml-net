using System.Linq;
using Tetris.Models.Gameplay;
using Tetris.Models.States;

namespace Tetris.Models.Summary
{
    public class SummaryState : AState
    {
        public int Score { get; }
        
        public SummaryState(int score)
        {
            Score = score;
            Name = ToString().Split(".").Last();

        }
        public override void OnSpaceClick()
        {
            SwitchState(new GameplayState());
        }
    }
}