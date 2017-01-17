using UnityEngine;
using System.Collections;

public abstract class LevelState : State {

  #region Fields

  public Level Level { get { return level; } }

  private Level level;

  #endregion

  #region Mono Behaviour

  protected virtual void Awake() {
    level = GetComponent<Level>();
  }

  #endregion

}