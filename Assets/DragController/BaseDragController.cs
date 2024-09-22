using System;
using DefaultNamespace.Balloon;
using MainCamera;
using UnityEngine;
using Zenject;

namespace DragController
{
    public abstract class BaseDragController : IDragController, ITickable
    {
        protected Camera mainCamera;
        
        protected RaycastHit _hit;
        protected const int _distance = 1000;

        private readonly BalloonController _balloonController;
        private readonly CameraController _cameraController;
        private readonly TickableManager _tickableManager;

        protected BaseDragController(
            BalloonController balloonController,
            CameraController cameraController,
            TickableManager tickableManager)
        {
            _balloonController = balloonController;
            _cameraController = cameraController;
            
            _tickableManager = tickableManager;
            _tickableManager.Add(this);
        }

        public virtual void Tick()
        {
            if (!mainCamera)
            {
                mainCamera = _cameraController.GetCameraView().MainCamera;
            }
        }
        protected abstract void TouchLogic();
        

        public void OnStartRaycastHit(object hit)
        {
            var balloonView = ((RaycastHit)hit).transform.GetComponent<BalloonView>();
                   
            if (balloonView )
            {
                _balloonController.DespawnOne(balloonView);
            }
            
        }

        public void OnEndRaycastHit()
        {
        }
    }
}