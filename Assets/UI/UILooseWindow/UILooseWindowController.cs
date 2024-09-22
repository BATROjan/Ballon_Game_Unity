using DefaultNamespace.Balloon;
using UI.UIResultWindow;
using UI.UIService;
using UI.UIStartWindow;

namespace UI.UILooseWindow
{
    public class UILooseWindowController
    {
        private readonly PlayerResultConfig _config;
        private readonly BalloonController _balloonController;
        private readonly IUIService _uiService;
        private UILooseWindowView _looseWindowView;
        
        public UILooseWindowController(
            PlayerResultConfig config,
            BalloonController balloonController,
            IUIService uiService)
        {
            _config = config;
            _balloonController = balloonController;
            _uiService = uiService;
            _looseWindowView = _uiService.Get<UILooseWindowView>();
            _looseWindowView.SaveButton.OnClick += SaveRelust;
        }

        private void SaveRelust()
        {
            ResultModel newModel = new ResultModel();
            newModel.Name = _looseWindowView.InputField.text;
            newModel.Score =_balloonController.GetScore().ToString();
            _config.SetNewResult(newModel);
            _uiService.Show<UIStartWindowView>();
            _uiService.Hide<UILooseWindowView>();
        }
    }
}