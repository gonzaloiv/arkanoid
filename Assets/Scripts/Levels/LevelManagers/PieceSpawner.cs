using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : Singleton<PieceSpawner> {

  #region Fields

  [SerializeField] private GameObject piecePrefab;

  #endregion

  #region Mono Behaviour

  void Awake() {
    Pooler.CreateGameObjectPool(piecePrefab, Config.InitialPiecePoolAmount, transform);
  }

  #endregion

  #region Public Behaviour

  public static GameObject SpawnPiece(PieceInfo pieceInfo) {
    return SpawnPiece(Instance.GetSpawnPiecePosition(), pieceInfo);
  }

  public static GameObject SpawnPiece(Vector3 position, PieceInfo pieceInfo) {
    GameObject piece = Pooler.GetPooledGameObject("PiecePool");
    piece.transform.position = position;
    piece.GetComponent<Piece>().PieceInfo = pieceInfo;
    piece.SetActive(true);

    return piece; 
  }

  public static GameObject SpawnSymmetricPiece(Vector3 piecePosition, PieceInfo pieceInfo) {
    return SpawnPiece(new Vector3(-piecePosition.x, piecePosition.y, piecePosition.z), pieceInfo);
  }
  
  #endregion

  #region Public Behaviour

  private Vector3 GetSpawnPiecePosition() {
    Vector3 position = RandomBoardPosition();
    float startTime = Time.realtimeSinceStartup;
    while (!IsEmptyPosition(position)) {
      position = RandomBoardPosition();
      if (Time.realtimeSinceStartup - startTime > .01f) {
        return Vector3.zero;
      }
    }
    return position;
  }

  private Vector3 RandomBoardPosition() {
    Vector3 position = new Vector3();
    position.x = Config.SpawnPieceGridOrigin.x + Mathf.Round(Random.Range(0, Config.BoardWidth / Config.PieceSize.x)) * Config.PieceSize.x;
    position.y = Config.PieceSize.y / 2;
    position.z = Config.SpawnPieceGridOrigin.z + Mathf.Round(Random.Range(0, Config.BoardHeight / Config.PieceSize.z)) * Config.PieceSize.z;
    
    return position;
  }

  private bool IsEmptyPosition(Vector3 position) {
    return !Physics.CheckBox(position, Config.PieceSize / 4);
  }

  #endregion

}
