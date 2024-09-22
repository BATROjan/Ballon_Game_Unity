using System;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Balloon
{
    public class BalloonView : MonoBehaviour
    {
        public class Pool: MonoMemoryPool<BalloonView>
        {
            
        }
    }
}