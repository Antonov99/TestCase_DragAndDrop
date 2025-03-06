using UnityEngine;
using Zenject;

namespace Game
{
    public class CameraEntityInstaller : MonoInstaller
    {
        [SerializeField]
        private DragHandler _dragHandler;

        [SerializeField]
        private Transform _leftBound;

        [SerializeField]
        private Transform _rightBound;

        [SerializeField]
        private float _speed;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CameraMoveSystem>()
                .AsSingle()
                .WithArguments(_dragHandler, _leftBound, _rightBound,_speed)
                .NonLazy();
        }
    }
}