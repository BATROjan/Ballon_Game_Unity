using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace.Balloon
{
    public class BalloonController
    {
        public Action OnGameOver;
        
        private readonly BalloonView.Pool _balloonPool;

        private Dictionary<BalloonView, Tween> _tweenDictionary = new Dictionary<BalloonView, Tween>();

        private bool readyToSpawn;
        private Tween _tween;
        private int _score;
        
        public BalloonController(BalloonView.Pool balloonPool)
        {
            _balloonPool = balloonPool;
        }
        
        public void SpawnAll()
        {
            _tween.Kill();
            _tween = null;
            
            float delay = Random.Range(0f, 3f);
            
           _tween = DOVirtual.DelayedCall(delay, () =>
            {
                if (readyToSpawn)
                {
                    SpawnOne();
                    SpawnAll();
                }
            });
        }

        public void ChangeReadyBool(bool value)
        {
            readyToSpawn = value;
        }

        public void DespawnAll()
        {
            readyToSpawn = false;
            foreach (var item in _tweenDictionary)
            {
                item.Value.Kill();
                _balloonPool.Despawn(item.Key);
            }
            _tweenDictionary.Clear();
        }

        public void DespawnOne(BalloonView balloonView)
        {
            _score++;
            
            _tweenDictionary[balloonView].Kill();
            _tweenDictionary[balloonView] = null;
            
            _tweenDictionary.Remove(balloonView);
            _balloonPool.Despawn(balloonView);
        }

        public int GetScore()
        {
            return _score;
        }

        public void ResetScore()
        {
            _score = 0;
        }

        private void SpawnOne()
        {
           var balloon = _balloonPool.Spawn();
           balloon.transform.position = new Vector3(Random.Range(-25f, 25f), -100, 100);
           
           Tween tween = balloon.transform.DOMoveY(100, 7).SetEase(Ease.Linear)
               .OnComplete(()=> OnGameOver?.Invoke());
           
           _tweenDictionary.Add(balloon, tween);
        }
    }
}