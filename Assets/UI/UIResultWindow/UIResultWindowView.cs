using UnityEngine;

namespace UI.UIResultWindow
{
    public class UIResultWindowView : UIWindow
    {
        public Transform ResultViewTransfom => resultViewTransfom;
        public UIButton BackButton => backButton;
        
        [SerializeField] private Transform resultViewTransfom;
        [SerializeField] private UIButton backButton;
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