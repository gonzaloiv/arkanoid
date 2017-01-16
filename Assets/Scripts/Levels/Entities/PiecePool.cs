using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PiecePool : MonoBehaviour {

	#region Fields

  [SerializeField] GameObject piecePrefab;

  private List<GameObject> pieces = new List<GameObject>();
  private GameObject poolObject;

  #endregion


  #region Mono Behaviour

  void Awake() {
    poolObject = new GameObject("PiecePool");
    poolObject.transform.SetParent(transform);
    for(int i = 0; i < Config.InitialPieceAmount; i++){ 
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
    GameObject piece = Instantiate(piecePrefab) as GameObject;
    piece.SetActive(false);
    piece.transform.parent = poolObject.transform;
    pieces.Add(piece);
    return piece;
  }

  #endregion

}
