using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PiecePool))]
public class Level : MonoBehaviour {

  #region Fields

  [SerializeField] GameObject boardPrefab;
  [SerializeField] GameObject ballPrefab;
  [SerializeField] GameObject paddlePrefab;

  private GameObject board;
  private GameObject ball;
  private GameObject paddle;
  private PiecePool piecePool;

  #endregion

  #region Mono Behaviour

  void Awake() {
    board = Instantiate(boardPrefab) as GameObject;
    board.transform.parent = transform;
    ball = Instantiate(ballPrefab) as GameObject;
    ball.transform.parent = transform;
    paddle = Instantiate(paddlePrefab) as GameObject;
    paddle.transform.parent = transform;
    piecePool = GetComponent<PiecePool>();
  }

  void Start() {
    // for testing purposes
    for (int i = 0; i < Config.InitialPieceAmount; i++) {
      GameObject piece = piecePool.PopPiece();
      piece.transform.Translate(Levels.Level1[i][0], 0, Levels.Level1[i][1]);
//      piece.GetComponent<Renderer>().material.color = Levels.PieceColors[Levels.Level1[i][2]];
      piece.SetActive(true);
    }
  }

  #endregion

}
