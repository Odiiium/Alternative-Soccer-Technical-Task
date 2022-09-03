using UnityEngine;
class Aim : MonoBehaviour
{
    internal LineRenderer AimLine { get => aimLine ??= GetComponentInChildren<LineRenderer>(); }
    LineRenderer aimLine;
}