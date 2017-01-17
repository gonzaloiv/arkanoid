using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

  #region Mono Behaviour

  private float boardConstraints { get { return Config.BoardWidth / 2 - transform.localScale.x / 1.5f; } }

  #endregion

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
    if (transform.position.x >= -boardConstraints)
      transform.Translate(-Config.PaddleVelocity, 0, 0);
  }

  private void MoveRight() {
    if (transform.position.x <= boardConstraints)
      transform.Translate(Config.PaddleVelocity, 0, 0);
  }

  #endregion

}
