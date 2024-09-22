using DefaultNamespace.Balloon;
using UI.UIService;
using UI.UIStartWindow;

namespace DefaultNamespace.GameController
{
    public class GameController
    {
        private readonly IUIService _uiService;
        private readonly BalloonController _balloonController;

        public GameController(
            IUIService uiService,
            BalloonController balloonController)
        {
            _uiService = uiService;
            _balloonController = balloonController;
            _balloonController.OnGameOver += StopGame;
        }

        private void StopGame()
        {
            _uiService.Show<UIStartWindowView>();
            _balloonController.DespawnAll();
        }

        public void StartGame()
        {
            _balloonController.ChangeReadyBool(true);
            _balloonController.SpawnAll();
        }
    }
}