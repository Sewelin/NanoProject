using UnityEngine;
public abstract class AbstractAttackState : AbstractControllerState
{
    protected struct AnimState
    {
        private bool _init;
        private bool _body;
        private bool _recovery;

        public bool Init
        {
            get => _init;
            set
            {
                if (!value) return;
                _init = true;
                _body = false;
                _recovery = false;
            }
        }
        public bool Body
        {
            get => _body;
            set
            {
                if (!value) return;
                _init = false;
                _body = true;
                _recovery = false;
            }
        }
        public bool Recovery
        {
            get => _recovery;
            set
            {
                if (!value) return;
                _init = false;
                _body = false;
                _recovery = true;
            }
        }
        
    }

    protected int Dir { get; private set; }
    protected float timer = 0f;
    protected StateParameters param;
    protected AnimState animState;
    public bool kill;
    
    public AbstractAttackState(GameManager gameManager, AbstractController controller, StateParameters param, int dir) :
        base(gameManager, controller)
    {
        this.param = param;
        Dir = dir;
    }
    public override void Update()
    {
        timer += Time.deltaTime;
        if (timer < param.timeSteps.x)
        {
            if (!animState.Init)
            {
                animState.Init = true;
                //TODO Suppr visual effect
                controller.characterInfo.Character.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
        else if (timer < param.timeSteps.x + param.timeSteps.y)
        {
            if (!animState.Body)
            {
                animState.Body = true;
                controller.characterInfo.Saber.GetComponent<Collider>().enabled = true;
                //TODO Suppr visual effect
                controller.characterInfo.Character.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        else if (timer < param.Duration)
        {
            if (!animState.Recovery)
            {
                animState.Recovery = true;
                controller.characterInfo.Saber.GetComponent<Collider>().enabled = false;
                //TODO Suppr visual effect
                controller.characterInfo.Character.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
        else
        {
            //TODO Suppr visual effect
            controller.characterInfo.Character.GetComponent<Renderer>().material.color = Color.white;
            SwitchState();
        }

        float progress = timer / param.Duration;
        controller.characterInfo.RigidBody.velocity = new Vector3(
            Dir* param.speed * param.curve.Evaluate(progress),
            0f, 0f);


        base.Update();
    }
    private void SwitchState()
    {
        Exit();
        switch (nextState)
        {
            case ControllerStateName.Idle:
                controller.SetState(new IdleState(gameManager, controller));
                break;
            case ControllerStateName.VerticalAttack:
                controller.SetState(new VerticalState(gameManager, controller, controller.dir));
                break;
            case ControllerStateName.DashAttack:
                controller.SetState(new DashState(gameManager, controller, controller.dir));
                break;
            case ControllerStateName.BackDash:
                controller.SetState(new BackDashState(gameManager, controller, controller.dir));
                break;
        }
    }

    protected override void Exit()
    {
        base.Exit();
        Debug.Log(kill +" " + controller.gameManager.roundTimer);
        if (kill && controller.gameManager.roundTimer < 0)
        {
            AbstractAnimation.AddAnimation(controller.characterInfo.Character,AbstractAnimation.AnimationName.Leave);
        }
    }
}