using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

  #region Mono Behaviour

  [SerializeField] GameObject levelPrefab;

  #endregion

  #region Mono Behaviour

  void Start() {
    Instantiate(levelPrefab);
  }

  #endregion

}
