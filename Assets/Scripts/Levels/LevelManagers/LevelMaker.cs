using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelMaker : Singleton<LevelMaker> {

  #region Fields

  public static List<GameObject> LevelPieces { get { return Instance.levelPieces; } }
  private List<GameObject> levelPieces = new List<GameObject>();

  #endregion

  #region Public Behaviour

  public static List<GameObject> GenerateNewLevel(int levelNumber) {
    foreach (PieceInfo pieceInfo in LevelConfig.PieceTypes.Values) {
      for (int i = 0; i < pieceInfo.amount + pieceInfo.increaseAmount * levelNumber; i++) {
        GameObject currentPiece = PieceSpawner.SpawnPiece(pieceInfo);
        Instance.levelPieces.Add(currentPiece);
        Instance.levelPieces.Add(PieceSpawner.SpawnSymmetricPiece(currentPiece.transform.position, pieceInfo));
      }
    }
    return Instance.levelPieces;
  }

  #endregion

}