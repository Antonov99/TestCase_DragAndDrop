using Components;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game
{
    //Concrete Entity Installer
    public class DraggableEntityInstaller : MonoInstaller
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private Collider2D _collider;

        [SerializeField]
        private Entity _entity;

        [FormerlySerializedAs("_draggableObject")]
        [SerializeField]
        private DragHandler _dragHandler;

        public override void InstallBindings()
        {
            //ComponentsForEntity
            Container.Bind<MoveComponent>()
                .AsSingle()
                .WithArguments(_rigidbody)
                .NonLazy();

            Container.Bind<ColliderComponent>()
                .AsSingle()
                .WithArguments(_collider)
                .NonLazy();

            //MechanicsForEntity
            Container.BindInterfacesAndSelfTo<DraggableObjectMoveController>()
                .AsSingle()
                .WithArguments(_entity, _dragHandler)
                .NonLazy();

            Container.BindInterfacesAndSelfTo<DraggableObjectColliderController>()
                .AsSingle()
                .WithArguments(_dragHandler, _entity)
                .NonLazy();
        }
    }
}