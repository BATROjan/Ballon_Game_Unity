using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UIResultWindow
{
    [CreateAssetMenu(fileName = "PlayerResultConfig", menuName = "Configs/PlayerResultConfig")]
    public class PlayerResultConfig : ScriptableObject
    {
        [SerializeField] private ResultModel[] resultModels;
        private ResultModel _currentModel;
        private ResultModel _lastModel;
        
        public int GetModelsConut()
        {
            return resultModels.Length;
        }

        public ResultModel GetModel(int id)
        {
            return resultModels[id];
        }

        public int GetMinScore()
        {
            return int.Parse(resultModels.Last().Score);
        }
        public void SetNewResult(ResultModel newModel)
        {
            _currentModel = newModel;
            
            foreach (var model in resultModels)
            { 
                _lastModel = model;
                
                if (int.Parse(_currentModel.Score) > int.Parse(_lastModel.Score))
                {
                    int id = Array.IndexOf(resultModels, _lastModel);
                    resultModels[id] = _currentModel;
                     _currentModel = _lastModel;
                }
            }
        }
    }
    
    [Serializable]
    public struct ResultModel
    {
        public String Name;
        public String Score;
    }
}