using UnityEngine;

class Ball : MonoBehaviour
{
    InputController inputController = new InputController();
    BallMovable ballMovable = new BallMovable();
    BallStateMachine playerStateMachine = new BallStateMachine();

    private void Update()
    {

        Move();
    }

    void Move() => ballMovable.DoMove(gameObject.transform, inputController.endTouchPosition - inputController.startTouchPosition);
}