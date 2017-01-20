using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : State {

  #region Fields

  [SerializeField] private GameObject gameOverScreenPrefab;
  private GameObject gameOverScreen;

  #endregion

  #region Mono Behaviour

  void Awake() {
    gameOverScreen = Instantiate(gameOverScreenPrefab, transform) as GameObject;
    gameOverScreen.SetActive(false);
  }

  #endregion

  #region State Behaviour

  public override void Enter() {
    base.Enter();

    gameOverScreen.SetActive(true);
  }

  public override void Exit() {
    base.Exit();

    gameOverScreen.SetActive(false);
  }

  #endregion

}
