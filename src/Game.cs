using System;
using System.Linq;
using System.Timers;
using Tetris.Controllers;
using Tetris.Models;
using Tetris.Models.Gameplay;
using Tetris.Models.States;
using Tetris.Models.Summary;
using Tetris.Views;
using Tetris.Views.Gameplay;
using Tetris.Views.Summary;
using Sfw = SFML.Window;
using Sfg = SFML.Graphics;
using Sfs = SFML.System;

namespace Tetris
{
    public class Game
    {
        public static Sfs.Vector2u Resolution { get; private set; }
        
        public Game()
        {
            Resolution = new Sfs.Vector2u(1280, 720);
#if DEBUG
            _window = new Sfg.RenderWindow(new Sfw.VideoMode(Resolution.X, Resolution.Y), new string(Strings.GameName));            
#else   
            _window = new Sfg.RenderWindow(new Sfw.VideoMode(1280, 720), new string(Strings.GameName), Sfw.Styles.Fullscreen);
#endif
            var cameraView = _window.DefaultView;
            cameraView.Center = new Sfs.Vector2f(300f, 200f);
            _window.SetView(cameraView);
            
            var gameplayState = new GameplayState();
            _userInputController = new UserInputController {ActualState = gameplayState, ActualViewContainer = new GameplayStateView(gameplayState)};
            
        }

        public void Run()
        {
            var clock = new Sfs.Clock();
            SetEventHandlers();
            while (_window.IsOpen)
            {
                _window.Clear();
                _window.DispatchEvents();
                Update(clock.ElapsedTime);
                clock.Restart();
                Render();
                _window.Display();
            }
        }

        private void SetEventHandlers()
        {
            _window.KeyPressed += _userInputController.OnKeyboardPress;
        }

        private void Render()
        {
            _window.Draw(_userInputController.ActualViewContainer);
        }

        private void Update(Sfs.Time dt)
        {
            switch (_userInputController.ActualState.Condition)
            {
                case StateCondition.Switching:
                    var newState = _userInputController.ActualState.SwitchToThis;
                    _userInputController.ActualState = newState;
                    _userInputController.ActualViewContainer = newState.Name == nameof(SummaryState)
                        ? (IViewContainer) new SummaryStateView(newState as SummaryState)
                        : new GameplayStateView(newState as GameplayState);
                    break;
                case StateCondition.Running:
                    // do nothing, everything is ok
                    break;
                case StateCondition.Stopped:
                    _window.Close();
                    break;
                case StateCondition.Error:
                    _window.Close();
                    Environment.Exit(1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            _userInputController.ActualState.Update(dt);
        }
        
        private Sfg.RenderWindow _window;
        private IUserInputController _userInputController;
    }
}