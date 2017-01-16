using UnityEngine;
using System.Collections;

public class Helper : MonoBehaviour {

  public static Vector3 GetRandomDirection(){
    return new Vector3(Random.Range(-1f, 1f), 0, Random.Range(0, 1f));
  }

}
