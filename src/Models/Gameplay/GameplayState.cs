using System.Linq;
using Sfs = SFML.System;
using Tetris.Models.Gameplay.Terminos;
using Tetris.Models.States;
using Tetris.Models.Summary;
using Tetris.Models.Utilities.Scheduler;

namespace Tetris.Models.Gameplay
{
    public sealed class GameplayState : AState
    {
        public int PointsForLine { get; set; }
        public IWorld World { get; }
        public int Score { get; set; }

        public GameplayState()
        {
            World = new World(10, 16);
            Score = 0;
            PointsForLine = 10;
            Name = ToString().Split(".").Last();

            _droppingScheduler = new RecurrentScheduler()
                .Schedule()
                .Every(Sfs.Time.FromSeconds(0.5f))
                .Execute(() => World.CurrentPiece.Drop(World.Matrix));

            var endGameScheduler = new ConditionScheduler()
                .Schedule()
                .When(() => World.WorldEnded)
                .Execute(() => SwitchState(new SummaryState(Score)));

            _scoreResolver = new LaneScourer(PointsForLine);

            Updatables.Add(World);
            Updatables.Add(_droppingScheduler);
            Updatables.Add(endGameScheduler);
        }

        public override void OnLeftClick()
        {
            World.CurrentPiece.Move(EDirection.Left, World.Matrix);
        }

        public override void OnDownClick()
        {
            World.CurrentPiece.Drop(World.Matrix);
        }

        public override void OnRightClick()
        {
            World.CurrentPiece.Move(EDirection.Right, World.Matrix);
        }

        public override void OnUpClick()
        {
            World.CurrentPiece.NextDirection(World.Matrix);
        }

        public override void OnSpaceClick()
        {
            while (!World.CurrentPiece.Grounded)
            {
                World.CurrentPiece.Drop(World.Matrix);
            }
        }

        public override void Update(Sfs.Time dt)
        {
            base.Update(dt);
            var scoreOld = Score;
            Score += _scoreResolver.ClearFullLanesAndGetPoints(World.Matrix);
            if (scoreOld != Score)
            {
                ((RecurrentScheduler) _droppingScheduler).Timeout *= 0.9f;
            }
        }

        private IScoreResolver _scoreResolver;
        private IScheduler _droppingScheduler;
    }
}