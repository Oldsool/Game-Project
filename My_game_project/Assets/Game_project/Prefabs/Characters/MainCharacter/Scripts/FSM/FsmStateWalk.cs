
using UnityEngine;


namespace Assets.Game_project.Prefabs.Characters.MainCharacter.Scripts.FSM
{
    public class FsmStateWalk : FsmStateMovement
    {
        public FsmStateWalk(Fsm fsm, Transform transform, float speed) : base(fsm, transform, speed) { } 
        
        public override void Update()
        {
            Debug.Log("Walk state [UPDATE]");

            var inputDirection = ReadInput();

            if (inputDirection.sqrMagnitude == 0f)
            {
                Fsm.SetState<FsmStateIdle>();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Fsm.SetState<FsmStateRun>();
            }

            Move(inputDirection);
        }
    }
}