using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UIResultWindow
{
    [CreateAssetMenu(fileName = "PlayerResultConfig", menuName = "Configs/PlayerResultConfig")]
    public class PlayerResultConfig : ScriptableObject
    {
        [SerializeField] private ResultModel[] resultModels;

        public int GetModelsConut()
        {
            return resultModels.Length;
        }

        public ResultModel GetModel(int id)
        {
            return resultModels[id];
        }
    }
    
    [Serializable]
    public struct ResultModel
    {
        public String Name;
        public String Score;
    }
}