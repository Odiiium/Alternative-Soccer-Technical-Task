using UnityEngine;

class CameraController : MonoBehaviour
{
    [SerializeField] Player player;
    internal CameraMovable CameraMovable { get => cameraMovable ??= new CameraMovable(); }   
    CameraMovable cameraMovable;
    
    private void FixedUpdate() => CameraMovable.Move(transform, player.transform.position);
}
