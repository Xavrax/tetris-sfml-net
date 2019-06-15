using Tetris.Models.States;
using Tetris.Views;
using Sfg = SFML.Graphics;
using Sfw = SFML.Window;

namespace Tetris.Controllers
{
    public class UserInputController : IUserInputController
    {
        public IState ActualState { get; set; }
        public IViewContainer ActualViewContainer { get; set; }

        public void OnKeyboardPress(object sender, Sfw.KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Sfw.Keyboard.Key.Escape:
                    OnEscapeKey(sender);
                    break;
                case Sfw.Keyboard.Key.Left:
                    ActualState.OnLeftClick();
                    break;
                case Sfw.Keyboard.Key.Right:
                    ActualState.OnRightClick();
                    break;
                case Sfw.Keyboard.Key.Up:
                    ActualState.OnUpClick();
                    break;
                case Sfw.Keyboard.Key.Down:
                    ActualState.OnDownClick();            
                    break;
                case Sfw.Keyboard.Key.Space:
                    ActualState.OnSpaceClick();
                    break;
            }
        }

        private void OnEscapeKey(object sender)
        {
            ActualState.Condition = StateCondition.Stopped;
        }
    }
}