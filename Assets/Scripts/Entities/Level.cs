using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

  [SerializeField] GameObject boardPrefab;
	[SerializeField] GameObject ballPrefab;

	#region Mono Behaviour

	void Awake() {
    Instantiate(boardPrefab);
    Instantiate(ballPrefab);
	}

	void Start () {
		Debug.Log("Start!");
	}

	#endregion

}
