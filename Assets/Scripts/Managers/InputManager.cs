using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

  #region Fields

  Vector3 lastCoordinate;

  #endregion

  #region Mono Behaviour

  void Start() {
    lastCoordinate = Input.mousePosition;
  }

  void Update() {   

    if (Input.mousePosition.x < lastCoordinate.x)
      EventManager.TriggerEvent(new MovePaddleLeft());

    if (Input.mousePosition.x > lastCoordinate.x)
      EventManager.TriggerEvent(new MovePaddleRight());

    lastCoordinate = Input.mousePosition;
  }

  #endregion

}


