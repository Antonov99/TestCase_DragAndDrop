using JetBrains.Annotations;
using UnityEngine;

namespace Components
{
    [UsedImplicitly]
    public class MoveComponent
    {
        private readonly Rigidbody2D _rigidbody;

        public MoveComponent(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Move(Vector2 direction)
        {
            _rigidbody.MovePosition(direction);
        }
    }
}