using System;
using UnityEngine;
using System.Collections.Generic;

public class GameObjectPool {

  #region Fields

  private List<GameObject> objects = new List<GameObject>();
  private int initialObjectAmount;
  private GameObject prefab;

  #endregion

  #region Contructors

  public GameObjectPool(GameObject prefab, int initialObjectAmount) {
    this.prefab = prefab;
    for(int i = 0; i < initialObjectAmount; i++)
      PushObject(); 
  }

  #endregion

  #region Public Behaviour

  public GameObject PopObject() {
    foreach(GameObject obj in objects) {
      if(!obj.activeInHierarchy)
        return obj;
    }
    return PushObject();
  }
 
  public GameObject PushObject() {
    GameObject obj = PoolManager.Instance.CreatePoolGameObject(prefab);
    obj.SetActive(false);
    objects.Add(obj);

    return obj;
  }

  #endregion

}