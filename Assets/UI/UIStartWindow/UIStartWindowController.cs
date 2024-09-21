using UI.UIService;

namespace UI.UIStartWindow
{
    public class UIStartWindowController
    {
        private readonly IUIService _uiService;

        private UIStartWindowView _startWindowView;
        
        public UIStartWindowController(
            IUIService uiService)
        {
            _uiService = uiService;
            _startWindowView = _uiService.Get<UIStartWindowView>();
            _uiService.Show<UIStartWindowView>();
        }
    }
}