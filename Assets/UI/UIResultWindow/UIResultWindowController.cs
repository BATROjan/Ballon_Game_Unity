using System;
using System.Collections.Generic;
using UI.UIService;
using UI.UIStartWindow;

namespace UI.UIResultWindow
{
    public class UIResultWindowController
    {
        private readonly PlayerResultConfig _resultConfig;
        private readonly IUIService _uiService;
        private readonly PlayerResultView.Pool _resultPool;

        private List<PlayerResultView> _playerResultViews = new List<PlayerResultView>();
        
        private UIResultWindowView _uiResultWindowView;
        public UIResultWindowController(
            PlayerResultConfig resultConfig,
            IUIService uiService,
            PlayerResultView.Pool resultPool)
        {
            _resultConfig = resultConfig;
            _uiService = uiService;
            _resultPool = resultPool;
            
            _uiResultWindowView = _uiService.Get<UIResultWindowView>();
            _uiResultWindowView.ShowAction += SpawnResults;
            _uiResultWindowView.BackButton.OnClick += BackToMenu;
        }

        private void BackToMenu()
        {
            foreach (var view in _playerResultViews)
            {
                _resultPool.Despawn(view);
            }
            _playerResultViews.Clear();
            
            _uiService.Show<UIStartWindowView>();
            _uiService.Hide<UIResultWindowView>();
        }

        private void SpawnResults()
        {
            for (int i = 0; i < _resultConfig.GetModelsConut(); i++)
            {
               var resultView = _resultPool.Spawn(_resultConfig.GetModel(i));
               resultView.transform.SetParent(_uiResultWindowView.ResultViewTransfom);
               
               _playerResultViews.Add(resultView);
            }
        }
    }
}