using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

  #region Mono Behaviour
 
  void OnEnable() {
    EventManager.StartListening("MovePaddleLeft", MoveLeft);
    EventManager.StartListening("MovePaddleRight", MoveRight);
  }

  void OnDisable() {
    EventManager.StopListening("MovePaddleLeft", MoveLeft);
    EventManager.StopListening("MovePaddleRight", MoveRight);
  }

  #endregion

  #region Private Behaviour

  private void MoveLeft() {
    if(transform.position.x > -Config.BoardWidth / 2 + transform.localScale.x / 2 + 1)
      transform.Translate(-Config.PaddleVelocity, 0, 0);
  }

  private void MoveRight() {
    if(transform.position.x < Config.BoardWidth / 2 - transform.localScale.x / 2 - 1)
      transform.Translate(Config.PaddleVelocity, 0, 0);
  }

  #endregion

}
