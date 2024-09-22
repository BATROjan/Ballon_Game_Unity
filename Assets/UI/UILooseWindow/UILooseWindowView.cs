using UnityEngine;
using UnityEngine.UI;

namespace UI.UILooseWindow
{
    public class UILooseWindowView : UIWindow
    {
        public UIButton SaveButton => saveButton;
        public InputField InputField => inputField;

        [SerializeField] private InputField inputField;
        [SerializeField] private UIButton saveButton;
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