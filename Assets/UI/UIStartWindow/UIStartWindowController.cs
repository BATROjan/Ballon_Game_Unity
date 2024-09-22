using DefaultNamespace.Balloon;
using DefaultNamespace.GameController;
using UI.UIResultWindow;
using UI.UIService;

namespace UI.UIStartWindow
{
    public class UIStartWindowController
    {
        private readonly GameController _gameController;
        private readonly IUIService _uiService;

        private UIStartWindowView _startWindowView;
        
        public UIStartWindowController(
            GameController gameController,
            IUIService uiService)
        {
            _gameController = gameController;
            _uiService = uiService;
            _startWindowView = _uiService.Get<UIStartWindowView>();
            _uiService.Show<UIStartWindowView>();
            _startWindowView.StartButton.OnClick += StartGame;
            _startWindowView.TableButton.OnClick += ShowTable;
        }

        private void ShowTable()
        {
            _uiService.Hide<UIStartWindowView>();
            _uiService.Show<UIResultWindowView>();
        }

        private void StartGame()
        {
            _gameController.StartGame();
            _uiService.Hide<UIStartWindowView>();
        }
    }
}