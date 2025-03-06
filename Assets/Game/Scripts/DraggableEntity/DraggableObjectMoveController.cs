using System;
using Components;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Game
{
    //Grasp Controller for movement
    [UsedImplicitly]
    public class DraggableObjectMoveController : IInitializable, IDisposable
    {
        private MoveComponent _moveComponent;

        private readonly IEntity _entity;
        private readonly DragHandler _dragHandler;

        public DraggableObjectMoveController(IEntity entity, DragHandler dragHandler)
        {
            _entity = entity;
            _dragHandler = dragHandler;
        }

        void IInitializable.Initialize()
        {
            _moveComponent = _entity.Get<MoveComponent>();

            _dragHandler.OnDragObject += OnDrag;
        }

        private void OnDrag(Vector2 direction)
        {
            _moveComponent.Move(direction);
        }

        void IDisposable.Dispose()
        {
            _dragHandler.OnDragObject -= OnDrag;
        }
    }
}