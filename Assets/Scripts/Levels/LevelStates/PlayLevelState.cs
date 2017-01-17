using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PiecePool))]
public class PlayLevelState : LevelState {

  #region Fields

  private PiecePool piecePool;
  private List<GameObject> levelPieces;

  #endregion


  #region Mono Behaviour

  protected override void Awake() {
    piecePool = GetComponent<PiecePool>();
    levelPieces = new List<GameObject>();
  }

  void Update() {
    if(CheckLevelEnd())
//      Debug.Log("End Game Please!");
     EventManager.TriggerEvent("EndLevel");
  }

  #endregion

  #region Public Behaviour

  public override void Enter() {
    base.Enter();

    GenerateNewLevel();
  }

  #endregion

  #region Private Behaviour

  private void GenerateNewLevel() {
  // for testing purposes
    for (int i = 0; i < Levels.TestLevel.Length; i++) {
      GameObject piece = piecePool.PopPiece();
      piece.transform.Translate(Levels.TestLevel[i][0], 0, Levels.TestLevel[i][1]);
      piece.SetActive(true);
      levelPieces.Add(piece);
    }
  }

  // TODO: esto tiene que se mediante eventos
  private bool CheckLevelEnd(){
    foreach(GameObject piece in levelPieces) {
      if(piece.activeInHierarchy)
        return false;
    }
    return true;
  }

  #endregion

}
