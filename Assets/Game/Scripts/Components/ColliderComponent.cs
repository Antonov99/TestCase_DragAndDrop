using JetBrains.Annotations;
using UnityEngine;

namespace Components
{
    //Component
    [UsedImplicitly]
    public class ColliderComponent
    {
        private readonly Collider2D _collider;

        public ColliderComponent(Collider2D collider)
        {
            _collider = collider;
        }

        public void SetActive(bool value)
        {
            _collider.enabled = value;
        }
    }
}