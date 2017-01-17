using UnityEngine;
using System.Collections;

public class LevelState : State {

  #region Fields

  private Level level;

  #endregion

  #region Mono Behaviour

  protected virtual void Awake() {
    level = GetComponent<Level>();
  }

  #endregion

}
