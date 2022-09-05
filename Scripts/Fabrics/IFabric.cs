using UnityEngine;

interface IFabric<T>
{
    T Create(T type, Vector3 position, Quaternion rotation);
    T Create(T type, Transform transform);
}
