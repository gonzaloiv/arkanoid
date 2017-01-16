using UnityEngine;
using System.Collections;

public class Util : MonoBehaviour {

  public static Vector3 GetRandomBallDirection(){
    return new Vector3(Random.Range(-1f, 1f), 0, Random.Range(.5f, 1f));
  }

}
