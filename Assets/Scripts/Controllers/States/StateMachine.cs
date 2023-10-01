using System;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MENU,
    PLAYING,
    RESET_POSITION,
    END_GAME
}

public class StateMachine : MonoBehaviour
{
    private Dictionary<GameState, StateBase> stateDictionary;
    private StateBase currentState;

    public static StateMachine Instance;

    private void Start()
    {
        Instance = this;

        stateDictionary = new Dictionary<GameState, StateBase>
        {
            { GameState.MENU, new StateMenu() },
            { GameState.PLAYING, new StatePlaying() },
            { GameState.RESET_POSITION, new StateResetPosition() },
            { GameState.END_GAME, new StateEndGame() }
        };

        SwitchState(GameState.MENU);
    }

    public void SwitchState(GameState state)
    {
        currentState?.OnStateExit();

        currentState = stateDictionary[state];
        currentState.OnStateEnter();
    }

    [SerializeField]
    private void SwitchState(string state)
    {
        Enum.TryParse(state, out GameState gameState);

        SwitchState(gameState);
    }

    private void Update()
    {
        if (currentState == null) return;

        currentState.OnStateStay();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentState == stateDictionary[GameState.RESET_POSITION])
                SwitchState(GameState.PLAYING);
        }
    }
}
