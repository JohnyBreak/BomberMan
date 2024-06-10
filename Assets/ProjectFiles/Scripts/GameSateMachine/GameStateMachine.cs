using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace GameState
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> m_States;
        private IExitableState m_ActiveState;
        private AssetProvider m_AssetProvider;
        
        public GameStateMachine(SceneLoader sceneLoader)
        {
            m_AssetProvider = new();
            m_States = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, m_AssetProvider),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader),
                [typeof(WinState)] = new WinState(this),
                [typeof(LoseState)] = new LoseState(this),
                [typeof(GamePlayState)] = new GamePlayState(this),
                [typeof(ReloadLevelState)] = new ReloadLevelState(this, sceneLoader),
                
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }
        
        public void Enter<TState, TPayload>(TPayload payload) where TState :class, IPayLoadState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
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
}

