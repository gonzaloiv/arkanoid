using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

  #region Fields

  Vector3 lastMouseCoordinate;

  #endregion

  #region Mono Behaviour

  void Start() {
    lastMouseCoordinate = Input.mousePosition;
  }

  void Update() {   
    if (Input.mousePosition.x < lastMouseCoordinate.x)
      EventManager.TriggerEvent("MovePaddleLeft");
    if (Input.mousePosition.x > lastMouseCoordinate.x)
      EventManager.TriggerEvent("MovePaddleRight");

    lastMouseCoordinate = Input.mousePosition;
  }

  #endregion

}


