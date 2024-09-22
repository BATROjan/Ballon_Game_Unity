using System;
using UnityEngine;

namespace DragController
{
    public interface IDragController
    {
        void OnStartRaycastHit(object hit);
        void OnEndRaycastHit();
    }
}