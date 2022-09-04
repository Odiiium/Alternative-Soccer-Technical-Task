using UnityEngine;

interface IFabric<T>
{
    T Create(T type, Transform transform);
}
