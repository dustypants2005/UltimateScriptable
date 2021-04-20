using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Variables;
using UltimateScriptable.Variables;
using UnityEngine;

namespace UltimateScriptable.Pools {
  [CreateAssetMenu(fileName = "Pool", menuName = "UltimateScriptable/Pool", order = 0)]
  public class Pool : ScriptableObject {
    [Tooltip("We making copies of this.")]
    public GameObjectReference SpawnerObject;
    [Tooltip("Parent for the Spawns")]
    public GameObjectReference Parent;

    [Tooltip("Store non-active objects to save memory.")]
    public Queue<GameObject> PoolQueue = new Queue<GameObject>();

    [Tooltip("Initial Size of the pool.")]
    public FloatReference Size;
    public List<GameObject> Active;
    [Tooltip("At max spawn size, do we want to create new spawns or cap the spawn size \n true for scaling max size\n false for strict max size")]
    public bool IsScalable = true;

    public void Add(GameObject poolable) {
      Active.Add(poolable);
    }

    public void Remove(GameObject poolable) {
      if (Active.Contains(poolable))
        Active.Remove(poolable);
    }

    public void PutInQueue(GameObject poolable) {
      poolable.SetActive(false);
      PoolQueue.Enqueue(poolable);
    }

    public GameObject TakeOutQueue(Transform tran) {
      return TakeOutQueue(tran.position, tran.rotation);
    }

    public GameObject TakeOutQueue(Vector3 position, Quaternion rotation) {
      if (IsScalable && PoolQueue.Count == 0) { CreateNew(); } else if (!IsScalable && PoolQueue.Count == 0) { return null; }
      var obj = PoolQueue.Dequeue();
      obj.transform.position = position;
      obj.transform.rotation = rotation;
      obj.SetActive(true);
      return obj;
    }

    public void Init() {
      for (var i = 0; i < Size; i++) {
        CreateNew();
      }
    }

    public void CreateNew() {
      var obj = Instantiate(SpawnerObject.Value);
      var poolable = obj.GetComponent<Poolable>();
      if (Parent.Value != null) {
        obj.transform.parent = Parent.Value.transform;
      }
      if (poolable != null) {
        poolable.SetPool(this);
      }
      obj.SetActive(false);
      PoolQueue.Enqueue(obj);
    }
  }
}
