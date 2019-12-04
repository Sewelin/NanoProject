public abstract class AbstractAttackState : AbstractState
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
    
    public AbstractAttackState(GameManager gameManager, AbstractController controller, StateParameters param, int dir) :
        base(gameManager, controller)
    {
        this.param = param;
        Dir = dir;
    }
}