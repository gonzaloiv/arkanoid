using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

  #region Mono Behaviour

  private float boardConstraints { get { return Config.BoardWidth / 2 - transform.localScale.x / 1.5f; } }
  private int lives = Config.InitialPaddleLives;

  #endregion

  #region Mono Behaviour

  void OnEnable() {
    EventManager.StartListening<MovePaddleLeft>(MoveLeft);
    EventManager.StartListening<MovePaddleRight>(MoveRight);
    EventManager.StartListening<PaddleMiss>(LoseOneLife);
  }

  void OnDisable() {
    EventManager.StopListening<MovePaddleLeft>(MoveLeft);
    EventManager.StopListening<MovePaddleRight>(MoveRight);
    EventManager.StopListening<PaddleMiss>(LoseOneLife);
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

  private void LoseOneLife() {
    lives--;
    if(lives <= 0)
      EventManager.TriggerEvent(new GameOver());
  }

  #endregion

}
