using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PiecePool : MonoBehaviour {

	#region Fields

  [SerializeField] GameObject piecePrefab;

  private List<GameObject> pieces = new List<GameObject>();
  private GameObject piecePool;

  #endregion


  #region Mono Behaviour

  void Awake() {
    piecePool = Utils.InstantiateAsChild("PiecePool", transform);
    for(int i = 0; i < Config.InitialPiecePoolAmount; i++){ 
      PushPiece();
    }
  }

  #endregion

  #region Public Behaviour

  public GameObject PopPiece() {
    foreach(GameObject piece in pieces) {
      if(!piece.activeInHierarchy)
        return piece;
    }
    return PushPiece();
  }
 
  #endregion

  #region Private Behaviour

  private GameObject PushPiece() {
    GameObject piece = Utils.InstantiateAsChild(piecePrefab, piecePool.transform, false);
    pieces.Add(piece);
    return piece;
  }

  #endregion

}
