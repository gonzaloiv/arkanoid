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

    level = Utils.InstantiateAsChild(levelPrefab, transform) as GameObject;
  }

  public override void Exit() {
    base.Exit();

    Destroy(level);
  }

  #endregion

}
