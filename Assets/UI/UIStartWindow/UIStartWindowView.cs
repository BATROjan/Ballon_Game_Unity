using UnityEngine;

namespace UI.UIStartWindow
{
    public class UIStartWindowView : UIWindow
    {
        public UIButton StartButton => startButton;
        public UIButton TableButton => tableButton;
        
        [SerializeField] private UIButton startButton;
        [SerializeField] private UIButton tableButton;
        
        public override void Show()
        {
            ShowAction?.Invoke();
        }

        public override void Hide()
        {
            HideAction?.Invoke();
        }
    }
}