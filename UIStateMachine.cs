using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateMachine : MonoBehaviour
{
    public enum UIState
    {
        Debug,
        Main,
        EroSystem
    }
    private UIState _currentState = UIState.Main;

    public UIState CurrentState => _currentState;


    public void ChangeState(UIState newState)
    {
        if (_currentState == newState) return;

        ExitState(_currentState);
        _currentState = newState;
        EnterState(newState);

        //OnStateChanged?.Invoke(newState);
    }

    private void ExitState(UIState state)
    {
        UIManager.Instance.HideCurrentUI();

    }

    private void EnterState(UIState state)
    {
        UIManager.Instance.ShowCurrentUI(state);
    }
}
