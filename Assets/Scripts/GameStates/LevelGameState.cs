using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGameState : State {

  #region Fields

  [SerializeField] private GameObject levelPrefab;
  private GameObject level;

  #endregion

  #region State Behaviour

  public override void Enter() {
    base.Enter();

    if (!level) 
      level = Instantiate(levelPrefab, transform) as GameObject;
    level.SetActive(true);
  }

  public override void Exit() {
    base.Exit();

    level.SetActive(false);
  }

  #endregion

}
