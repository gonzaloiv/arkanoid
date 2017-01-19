using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Utils : MonoBehaviour {

  public static GameObject InstantiateAsChild(GameObject prefab, Transform parent, bool isActive = true){
    GameObject child = Instantiate(prefab) as GameObject;
    child.transform.SetParent(parent);
    child.SetActive(isActive);

    return child;
  }

  public static GameObject InstantiateAsChild(string childName, Transform parent, bool isActive = true){
    GameObject child = new GameObject(childName);
    child.transform.SetParent(parent);
    child.SetActive(isActive);

    return child;
  }

}
