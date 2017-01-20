using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelMaker : Singleton<LevelMaker> {

  #region Fields

  private List<GameObject> levelPieces = new List<GameObject>();

  #endregion

  #region Public Behaviour

  public List<GameObject> GenerateNewLevel(int levelNumber) {
    IncreasePieceAmount();
    foreach (PieceInfo pieceInfo in LevelConfig.PieceTypes.Values) {
      for (int i = 0; i < pieceInfo.amount; i++) {
        GameObject currentPiece = PieceSpawner.SpawnPiece(pieceInfo);
        levelPieces.Add(currentPiece);
        levelPieces.Add(PieceSpawner.SpawnSymmetricPiece(currentPiece.transform.position, pieceInfo));
      }
    }
    return levelPieces;
  }

  #endregion

  #region Private Behaviour

  private void IncreasePieceAmount() {
    foreach(PieceInfo pieceInfo in LevelConfig.PieceTypes.Values)
      pieceInfo.IncreaseAmount();
  }

  #endregion

}