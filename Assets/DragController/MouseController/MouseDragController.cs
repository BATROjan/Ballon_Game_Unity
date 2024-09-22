using DefaultNamespace.Balloon;
using MainCamera;
using UnityEngine;
using Zenject;

namespace DragController.MouseController
{
    public class MouseDragController : BaseDragController
    {
        
        public MouseDragController( 
            BalloonController balloonController,
            CameraController cameraController, 
            TickableManager tickableManager) 
            : base(
                balloonController,
                cameraController,
                tickableManager)
        {
        }

        public override void Tick()
        {
            base.Tick();
            
            if (Input.GetMouseButton(0))
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
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

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