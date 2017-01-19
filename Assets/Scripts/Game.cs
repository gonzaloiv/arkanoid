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
    EventManager.Instance.StartListening<StartGame>(ToLevelGameState);
    EventManager.Instance.StartListening<GameOver>(ToGameOverState);
  }

  void OnDisable() {
    EventManager.Instance.StopListening<StartGame>(ToLevelGameState);
    EventManager.Instance.StopListening<GameOver>(ToGameOverState);
  }

  #endregion

  #region Private Behaviour

  private void ToLevelGameState() {
    if (CurrentState is OpeningGameState || CurrentState is GameOverState)
      ChangeState<LevelGameState>();
  }

  private void ToGameOverState() {
    if (CurrentState is LevelGameState) {
      ChangeState<GameOverState>();
    }
  }

  #endregion

}
