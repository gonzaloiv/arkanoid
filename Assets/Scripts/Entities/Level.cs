using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

  [SerializeField] GameObject boardPrefab;
	[SerializeField] GameObject ballPrefab;
  [SerializeField] GameObject paddlePrefab;

	#region Mono Behaviour

	void Awake() {
    Instantiate(boardPrefab);
    Instantiate(ballPrefab);
    Instantiate(paddlePrefab);
	}

	void Start () {
		Debug.Log("Start!");
	}

	#endregion

}
