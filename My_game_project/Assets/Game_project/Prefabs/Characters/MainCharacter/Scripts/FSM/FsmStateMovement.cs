using UnityEngine;

namespace Assets.Game_project.Prefabs.Characters.MainCharacter.Scripts.FSM
{
    public class FsmStateMovement : FsmState
    {
        protected readonly Transform Transform;
        protected readonly float Speed;

        public FsmStateMovement(Fsm fsm, Transform transform, float speed) : base(fsm) 
        {
            Transform = transform;
            Speed = speed;
        }

        public override void Enter()
        {
            Debug.Log("Movement state [ENTER]");
        }

        public override void Exit() 
        {
            Debug.Log("Movement state [EXIT]");
        }

        public override void Update()
        {
            Debug.Log("Movement state [UPDATE]");

            var inputDirection = ReadInput();

            if (inputDirection.sqrMagnitude == 0f)
            {
                Fsm.SetState<FsmStateIdle>();
            }

            Move(inputDirection);
        }

        protected Vector2 ReadInput()
        {
            var inputHorizontal = Input.GetAxis("Horizontal");
            var inputVertical = Input.GetAxis("Vertical");
            var inputDirection = new Vector2(inputHorizontal, inputVertical);
            return inputDirection;
        }

        protected virtual void Move(Vector2 inputDirection)
        {
            Transform.position += new Vector3(inputDirection.x, 0f, inputDirection.y) * (Speed * Time.deltaTime);
        }
    }
}