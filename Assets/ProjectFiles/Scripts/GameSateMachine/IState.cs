namespace GameState
{
    public interface IState : IExitableState
    {
        public void Enter();
    }

    public interface IPayLoadState<TPayload> : IExitableState
    {
        public void Enter(TPayload payload);
    }
    
    public interface IExitableState
    {
        public void Exit();
    }
}