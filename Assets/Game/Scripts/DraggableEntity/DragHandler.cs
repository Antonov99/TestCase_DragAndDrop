using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class DragHandler : MonoBehaviour, IDragHandler
    {
        public event Action<Vector2> OnDragObject;

        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_camera == null) throw new NullReferenceException("Main Camera");

            var direction = GetDirection(eventData.position);
            OnDragObject?.Invoke(direction);
        }

        private Vector3 GetDirection(Vector2 mousePosition)
        {
            Vector3 newPosition = _camera.ScreenToWorldPoint(mousePosition);
            newPosition.z = 0;
            return newPosition;
        }
    }
}