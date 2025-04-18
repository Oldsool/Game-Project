
using UnityEngine;

namespace Assets.Game_project.Prefabs.Characters.MainCharacter.Scripts.FSM
{
    public class FsmStateRun : FsmStateMovement
    {
        public FsmStateRun(Fsm fsm, Transform transform, float speed) : base(fsm, transform, speed) { }

        public override void Update()
        {
            Debug.Log("Run state [UPDATE]");

            var inputDirection = ReadInput();

            if (inputDirection.sqrMagnitude == 0f)
            {
                Fsm.SetState<FsmStateIdle>();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Fsm.SetState<FsmStateWalk>();
            }

            Move(inputDirection);
        }
    }
}