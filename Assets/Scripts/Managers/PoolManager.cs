using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager : Singleton<PoolManager> {

  #region Fields

  private Dictionary<string, GameObjectPool> pools = new Dictionary<string, GameObjectPool>();

  #endregion

  #region Public Behaviour

  public GameObjectPool CreateGameObjectPool(GameObject prefab, int initialObjectAmount) {
    GameObjectPool gameObjectPool = new GameObjectPool(prefab, initialObjectAmount);
    pools.Add(prefab.name, gameObjectPool);
    return gameObjectPool;
  }

  public GameObject GetGameObjectByPoolName(string poolName) {
    if(pools.ContainsKey(poolName))
      return null;
    return pools[poolName].PopObject();
  }

  public GameObject CreatePoolGameObject(GameObject prefab) {
    GameObject obj = Instantiate(prefab, transform) as GameObject;
    return obj;
  }

  #endregion

}
