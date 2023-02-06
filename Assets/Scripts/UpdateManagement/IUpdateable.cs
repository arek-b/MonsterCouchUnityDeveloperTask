using UnityEngine;

namespace UpdateManagement
{
    public interface IUpdateable
    {
        void Tick(Vector2 playerPosition);
    }
}
