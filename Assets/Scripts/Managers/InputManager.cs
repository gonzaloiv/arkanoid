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
    if (Input.GetMouseButtonDown(0))
      EventManager.TriggerEvent("NextLevel");

    if (Input.mousePosition.x < lastCoordinate.x)
      EventManager.TriggerEvent("MovePaddleLeft");

    if (Input.mousePosition.x > lastCoordinate.x)
      EventManager.TriggerEvent("MovePaddleRight");

    lastCoordinate = Input.mousePosition;
  }

  #endregion

}


