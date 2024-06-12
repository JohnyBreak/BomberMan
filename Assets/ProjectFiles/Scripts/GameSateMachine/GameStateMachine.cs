using System;
using System.Collections.Generic;
using Zenject;

namespace GameState
{
    public class GameStateMachine
    {
        public Action<IExitableState> StateChangedEvent;

        private Dictionary<Type, IExitableState> m_States;
        private IExitableState m_ActiveState;
        private readonly StateFactory _stateFactory;

        public GameStateMachine(StateFactory factory)
        {
            _stateFactory = factory;
        }

        public void Initialize() 
        {
            m_States = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = _stateFactory.CreateState<BootstrapState>(),
                [typeof(LoadLevelState)] = _stateFactory.CreateState<LoadLevelState>(),
                [typeof(WinState)] = _stateFactory.CreateState<WinState>(),
                [typeof(LoseState)] = _stateFactory.CreateState<LoseState>(),
                [typeof(GamePlayState)] = _stateFactory.CreateState<GamePlayState>(),
                [typeof(ReloadLevelState)] = _stateFactory.CreateState<ReloadLevelState>(),
                [typeof(TimeOutState)] = _stateFactory.CreateState<TimeOutState>(),
                [typeof(GamePauseState)] = _stateFactory.CreateState<GamePauseState>(),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
            StateChangedEvent?.Invoke(state);
        }
        
        public void Enter<TState, TPayload>(TPayload payload) where TState :class, IPayLoadState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
            StateChangedEvent?.Invoke(state);
        }

        public bool IsCurrentState<T>() where T: class, IExitableState
        {
            if (m_ActiveState is T state) 
            {
                return true;
            }

            return false;
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            m_ActiveState?.Exit();
            
            TState state = GetState<TState>();
            m_ActiveState = state;
            
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            return m_States[typeof(TState)] as TState;

        }
    }

    public class StateFactory 
    {
        private readonly DiContainer _container;

        public StateFactory(DiContainer container) 
        {
            _container = container;
        }

        public T CreateState<T>() where T : IExitableState 
        {
            return _container.Resolve<T>();
        }
    }
}

