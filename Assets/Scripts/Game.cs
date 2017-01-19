using UnityEngine;
using System.Collections;

[RequireComponent(typeof(OpeningGameState))]
[RequireComponent(typeof(LevelGameState))]
[RequireComponent(typeof(GameOverState))]
public class Game : StateMachine {

  #region Mono Behaviour

  void Start() {
    ChangeState<OpeningGameState>();
  }

  void OnEnable() {
    EventManager.StartListening<StartGame>(ChangeState<LevelGameState>);
    EventManager.StartListening<GameOver>(ChangeState<GameOverState>);
    EventManager.StartListening<EndGame>(ChangeState<GameWinState>);

  }

  void OnDisable() {
    EventManager.StopListening<StartGame>(ChangeState<LevelGameState>);
    EventManager.StopListening<GameOver>(ChangeState<GameOverState>);
    EventManager.StopListening<EndGame>(ChangeState<GameWinState>);
  }

  #endregion

}
