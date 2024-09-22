using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.UIResultWindow
{
    public class PlayerResultView : MonoBehaviour
    {
        [SerializeField] private Text Name;
        [SerializeField] private Text Score;

        private void Reinit(ResultModel model)
        {
            Name.text = model.Name;
            Score.text = model.Score;
        }

        public class Pool: MonoMemoryPool<ResultModel,PlayerResultView>
        {
            protected override void Reinitialize(ResultModel model, PlayerResultView item)
            {
                item.Reinit(model);
            }
        }
    }
}