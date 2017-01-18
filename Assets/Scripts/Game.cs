using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

  #region Fields

  [SerializeField] GameObject levelPrefab;

  #endregion

  #region Mono Behaviour

  void Start() {
    Instantiate(levelPrefab);
  }

  #endregion

}
