using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelState : LevelState {

  #region Fields

  [SerializeField] private GameObject nextLevelScreenPrefab;
  private GameObject nextLevelScreen;

  #endregion

  #region Public Behaviour

  public override void Enter() {
    base.Enter();

    nextLevelScreen = Instantiate(nextLevelScreenPrefab) as GameObject;
  }

  public override void Exit() {
    base.Exit();

    Destroy(nextLevelScreen);
  }

  #endregion

}
