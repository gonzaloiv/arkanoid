using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PiecePool))]
[RequireComponent(typeof(Level))]
public class LevelMaker : MonoBehaviour {

  #region Fields

  private static LevelMaker levelMaker;
  private PiecePool piecePool;
  private Level level;

  private List<GameObject> levelPieces;

  #endregion

  #region Singleton Pattern

  public static LevelMaker Instance {
    get {
      if (!levelMaker) {
        levelMaker = FindObjectOfType(typeof(LevelMaker)) as LevelMaker;
        if (!levelMaker)
          Debug.LogError("There needs to be one active LevelMaker script on a GameObject in your scene.");
      }
      return levelMaker;
    }
  }

  #endregion

  #region Public Behaviour

  void Awake() {
    piecePool = GetComponent<PiecePool>();
    level = GetComponent<Level>();
  }

  #endregion

  #region Public Behaviour

  public List<GameObject> GenerateNewLevel() {
    levelPieces = new List<GameObject>();
    int levelPieceAmount = LevelPieceAmount();
    Vector3 position;

    for (int i = 0; i < levelPieceAmount / 2; i++) {
      position = GetSpawnPiecePosition();
      levelPieces.Add(SpawnPiece(position));
      levelPieces.Add(SpawnPiece(new Vector3(-position.x, 0, position.z)));
    }

    return levelPieces;
  }

  public List<GameObject> SetNewLevel() {
    levelPieces = new List<GameObject>();
    for (int i = 0; i < Levels.TestLevel.Length; i++)
      levelPieces.Add(SpawnPiece(new Vector3(Levels.TestLevel[i][0], 0, Levels.TestLevel[i][1])));
    
    return levelPieces;
  }

  public GameObject SpawnPiece(Vector3 position) {
    GameObject piece = piecePool.PopPiece();
    piece.transform.position = position;
    piece.SetActive(true);
    
    return piece; 
  }

  #endregion

  #region Private Behaviour

  private int LevelPieceAmount() {
    int levelPieceAmount = Config.MinPieceAmount + level.LevelNumber;
    return levelPieceAmount < Config.MaxPieceAmount ? levelPieceAmount : Config.MaxPieceAmount;
  }

  private Vector3 GetSpawnPiecePosition() {
    Vector3 position = RandomBoardPosition();
      float startTime = Time.realtimeSinceStartup;
      while (!IsEmptyPosition(position)) {
        position = RandomBoardPosition();
        // TODO: mirar como mejorar esto
        if (Time.realtimeSinceStartup - startTime > 0.001f) {
          return Vector3.zero;
        }
      }
    return position;
  }

  private bool IsEmptyPosition(Vector3 position) {
    return !Physics.CheckBox(position, Config.PieceSize / 2);
  }

  private Vector3 RandomBoardPosition() {
    Vector3 position = new Vector3();
    position.x = Config.SpawnPieceGridOrigin.x + Random.Range(0, Config.HorizontalMaxPieces) * Config.PieceSize.x;
    position.z = Config.SpawnPieceGridOrigin.z + Random.Range(0, Config.VerticalMaxPieces) * Config.PieceSize.z;

    return position;
  }

  #endregion

}