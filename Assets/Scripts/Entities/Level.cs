using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

  #region Fields

	[SerializeField] GameObject boardPrefab;
	[SerializeField] GameObject ballPrefab;
	[SerializeField] GameObject paddlePrefab;

  private GameObject board;
  private GameObject ball;
  private GameObject paddle;

  #endregion

	#region Mono Behaviour

	void Awake() {
    board = Instantiate(boardPrefab) as GameObject;
    board.transform.parent = transform;
    ball = Instantiate(ballPrefab) as GameObject;
    ball.transform.parent = transform;
    paddle = Instantiate(paddlePrefab) as GameObject;
    paddle.transform.parent = transform;
	}
  
	#endregion

}
