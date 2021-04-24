using System;
using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace UltimateScriptable.Pools {
  [Serializable]
  public class Poolable : MonoBehaviour {
    public Pool Pool;
    [Tooltip("How long does this projectile live?")]
    public FloatReference LifeTime;
    public UnityEvent OnSpawn;
    public UnityEvent OnDespawn;

    void OnEnable() {
      Pool.Add(gameObject);
      OnSpawn?.Invoke();
      StartCoroutine(AutoRemove());
    }

    void OnDisable() {
      OnDespawn?.Invoke();
      Pool.Remove(gameObject);
    }

    IEnumerator AutoRemove() {
      yield return new WaitForSeconds(LifeTime.Value);
      Pool.PutInQueue(gameObject);
    }

    public void Despawn() {
      Pool.PutInQueue(gameObject);
    }

    public void SetPool(Pool pool) {
      Pool = pool;
    }
  }
}
