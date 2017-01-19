using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinState : State {

  #region Fields

  [SerializeField] private GameObject gameWinScreenPrefab;
  private GameObject gameWinScreen;

  #endregion

  #region Mono Behaviour

  void Awake() {
    gameWinScreen = Utils.InstantiateAsChild(gameWinScreenPrefab, transform, false) as GameObject;
  }

  #endregion

  #region State Behaviour

  public override void Enter() {
    base.Enter();

    gameWinScreen.SetActive(true);
  }

  public override void Exit() {
    base.Exit();

    gameWinScreen.SetActive(false);
  }

  #endregion

}
