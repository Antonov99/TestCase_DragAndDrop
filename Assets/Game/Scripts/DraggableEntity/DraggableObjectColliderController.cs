using System;
using Components;
using JetBrains.Annotations;
using Zenject;

namespace Game
{
    //GRASP Controller for switch collider enabled/disabled 
    [UsedImplicitly]
    public class DraggableObjectColliderController : IInitializable, IDisposable
    {
        private ColliderComponent _colliderComponent;

        private readonly DragHandler _dragHandler;
        private readonly IEntity _entity;

        public DraggableObjectColliderController(DragHandler dragHandler, IEntity entity)
        {
            _dragHandler = dragHandler;
            _entity = entity;
        }

        void IInitializable.Initialize()
        {
            _colliderComponent = _entity.Get<ColliderComponent>();
            _dragHandler.OnStartDragging += StartDragging;
            _dragHandler.OnStopDragging += StopDragging;
        }

        private void StartDragging()
        {
            _colliderComponent.SetActive(false);
        }

        private void StopDragging()
        {
            _colliderComponent.SetActive(true);
        }

        void IDisposable.Dispose()
        {
            _dragHandler.OnStartDragging -= StartDragging;
        }
    }
}