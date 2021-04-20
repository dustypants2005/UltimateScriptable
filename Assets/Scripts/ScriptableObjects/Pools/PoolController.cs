using UnityEngine;

namespace UltimateScriptable.Pools {
  public class PoolController : MonoBehaviour {
    public Pool pool;
    public Transform SpawnPoint;
    [Tooltip("Parent to the poolable objects to help keep the scene clean")]
    public GameObject SpawnParent;
    void OnEnable() {
      pool.Parent.SetValue(SpawnParent);
      pool.Init();
    }

    public void Spawn() {
      Spawn(SpawnPoint ? SpawnPoint : transform);
    }

    public GameObject Spawn(Transform tran) {
      return pool.TakeOutQueue(tran);
    }

    public void Despawn(GameObject spawn) {
      pool.PutInQueue(spawn);
    }

    public void DespawnAll() {
      foreach (var item in pool.Active) {
        pool.PutInQueue(item.gameObject);
      }
    }
  }
}
