using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

  [SerializeField] GameObject levelPrefab;

  #region Mono Behaviour

  void Start() {
    Instantiate(levelPrefab);
  }

  #endregion

}
