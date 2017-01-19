using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PiecePool))]
[RequireComponent(typeof(Level))]
public class LevelMaker : Singleton<LevelMaker> {

  #region Fields

  private PiecePool piecePool;
  private List<GameObject> levelPieces;
  private Dictionary<PieceType, float> levelPiecesByType = new Dictionary<PieceType, float>  {
    {PieceType.None, 0},
    {PieceType.OneHitPiece, Config.MinPieceAmount / 3},
    {PieceType.TwoHitPiece, Config.MinPieceAmount / 12},
    {PieceType.NoHitsPiece, Config.MinPieceAmount / 14}
  };

  #endregion

  #region Mono Behaviour

  void Awake() {
    piecePool = GetComponent<PiecePool>();
  }

  #endregion

  #region Public Behaviour

  public List<GameObject> GenerateNewLevel(int levelNumber) {
    levelPieces = new List<GameObject>();
    IncreaseLevelPieceAmount();

    Vector3 position;
    foreach (PieceType pieceType in levelPiecesByType.Keys) {
      for (int i = 0; i < Mathf.Round(levelPiecesByType[pieceType]); i++) {
        position = GetSpawnPiecePosition();
        levelPieces.Add(SpawnPiece(position, pieceType));
        levelPieces.Add(SpawnPiece(new Vector3(-position.x, 0, position.z), pieceType));
      }
    }
    return levelPieces;
  }

  // Creación de niveles a partir de datos
  public List<GameObject> SetNewLevel() {
    levelPieces = new List<GameObject>();
    for (int i = 0; i < Levels.TestLevel.Length; i++)
      levelPieces.Add(SpawnPiece(new Vector3(Levels.TestLevel[i][0], 0, Levels.TestLevel[i][1])));
    
    return levelPieces;
  }

  public GameObject SpawnPiece(Vector3 position, PieceType pieceType = PieceType.None) {
    GameObject piece = piecePool.PopPiece();
    piece.transform.position = position;
    piece.GetComponent<Piece>().PieceType = pieceType == PieceType.None ? PieceType.OneHitPiece : pieceType;
    piece.SetActive(true);

    return piece; 
  }

  #endregion

  #region Private Behaviour

  private void IncreaseLevelPieceAmount() {
    levelPiecesByType[PieceType.OneHitPiece] += 1;
    levelPiecesByType[PieceType.TwoHitPiece] += .5f;
    levelPiecesByType[PieceType.NoHitsPiece] += .5f;
  }
 
  private Vector3 GetSpawnPiecePosition() {
    Vector3 position = RandomBoardPosition();
    float startTime = Time.realtimeSinceStartup;
    while (!IsEmptyPosition(position)) {
      position = RandomBoardPosition();
      // TODO: mejorar esto con una clase auxiliar para gestionar el tiempo
      if (Time.realtimeSinceStartup - startTime > .01f) {
        return Vector3.zero;
      }
    }
    return position;
  }

  private Vector3 RandomBoardPosition() {
    Vector3 position = new Vector3();
    position.x = Config.SpawnPieceGridOrigin.x + Random.Range(0, Config.HorizontalMaxPieces) * Config.PieceSize.x;
    position.z = Config.SpawnPieceGridOrigin.z + Random.Range(0, Config.VerticalMaxPieces) * Config.PieceSize.z;
    
    return position;
  }

  private bool IsEmptyPosition(Vector3 position) {
    return !Physics.CheckBox(position, Config.PieceSize / 2);
  }

  #endregion

}