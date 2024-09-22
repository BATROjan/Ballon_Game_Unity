﻿using DefaultNamespace.Balloon;
using MainCamera;
using UnityEngine;
using Zenject;

namespace DragController.TouchController
{
    public class TouchController: BaseDragController
    {
        public TouchController(
            BalloonController balloonController,
            CameraController cameraController, 
            TickableManager tickableManager) : 
            base(
                balloonController,
                cameraController, 
                tickableManager)
        {
        }     
        public override void Tick()
        {
            base.Tick();
            
                if (Input.touchCount > 0)
                {
                    TouchLogic();
                }
                else
                {
                    OnEndRaycastHit();
                }
        }

        protected override void TouchLogic()
        {
            var ray = mainCamera.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out _hit, _distance, 3))
            {
                if (_hit.transform)
                {
                    OnStartRaycastHit(_hit);
                }
            }
        }
    }
}