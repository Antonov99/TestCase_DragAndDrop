using System;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Game
{
    [UsedImplicitly]
    public sealed class CameraMoveSystem : IFixedTickable, IInitializable, IDisposable
    {
        private Vector2 _startPosition;
        private float _targetPositionX;
        private Camera _camera;
        private float _cameraHalfWidth;

        private readonly DragHandler _dragHandler;
        private readonly Transform _leftBound;
        private readonly Transform _rightBound;
        private readonly float _speed;

        public CameraMoveSystem(DragHandler dragHandler, Transform leftBound, Transform rightBound, float speed)
        {
            _dragHandler = dragHandler;
            _leftBound = leftBound;
            _rightBound = rightBound;
            _speed = speed;
        }

        void IInitializable.Initialize()
        {
            _camera = Camera.main;
            if (_camera is null) throw new NullReferenceException("Camera");

            _cameraHalfWidth = _camera.orthographicSize * _camera.aspect;

            _dragHandler.OnStartDragging += OnStart;
            _dragHandler.OnStopDragging += OnStop;
        }

        private void OnStart()
        {
            _startPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        }

        private void OnStop()
        {
            var targetPositionX = _camera.ScreenToWorldPoint(Input.mousePosition).x - _startPosition.x;

            _targetPositionX = Mathf.Clamp(
                _camera.transform.position.x - targetPositionX,
                _leftBound.position.x + _cameraHalfWidth,
                _rightBound.position.x - _cameraHalfWidth
            );
        }

        public void FixedTick()
        {
            var position = _camera.transform.position;
            var newX = Mathf.Lerp(position.x, _targetPositionX, Time.deltaTime * _speed);

            position =
                new Vector3(
                    newX,
                    position.y,
                    position.z
                );

            _camera.transform.position = position;
        }

        void IDisposable.Dispose()
        {
            _dragHandler.OnStartDragging -= OnStart;
            _dragHandler.OnStopDragging -= OnStop;
        }
    }
}