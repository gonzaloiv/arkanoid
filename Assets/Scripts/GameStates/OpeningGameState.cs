using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningGameState : State {

  #region Fields

  [SerializeField] private GameObject openingScreenPrefab;
  private GameObject openingScreen;

  #endregion

  #region Mono Behaviour

  void Awake() {
    openingScreen = Utils.InstantiateAsChild(openingScreenPrefab, transform, false) as GameObject;
  }

  #endregion

  #region State Behaviour

  public override void Enter() {
    base.Enter();

    openingScreen.SetActive(true);
  }

  public override void Exit() {
    base.Exit();

    openingScreen.SetActive(false);
  }

  #endregion

}
