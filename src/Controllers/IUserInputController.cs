using Tetris.Models.States;
using Tetris.Views;
using Sfw = SFML.Window;

namespace Tetris.Controllers
{
    public interface IUserInputController
    {
        IState ActualState { get; set; }
        IViewContainer ActualViewContainer { get; set; }
        void OnKeyboardPress(object sender, Sfw.KeyEventArgs e);
    }
}