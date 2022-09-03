using UnityEngine;

class CameraController : MonoBehaviour
{
    PlayerBall Player { get => player ??= FindObjectOfType<PlayerBall>(); }         // Using FindObjectOfType is bad practice, but in this case I use it only 1 time,
    PlayerBall player;                                                              // and then I'm cashing PlayerBall instance to "player" field. I think this is better                                                                                 CameraMovable CameraMovable { get => cameraMovable ??= new CameraMovable(); }
    CameraMovable CameraMovable { get => cameraMovable ??= new CameraMovable(); }   // and faster that drag-in-drop. But the best thing in this case is to use Zenject with their Containers 
    CameraMovable cameraMovable;
    
    private void FixedUpdate() => CameraMovable.Move(transform, Player.transform.position);
}
