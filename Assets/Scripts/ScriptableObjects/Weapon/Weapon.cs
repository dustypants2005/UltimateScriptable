using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateScriptable.Variables;
using UltimateScriptable.Pools;

namespace UltimateScriptable.Weapons {
  [CreateAssetMenu(fileName = "Weapon", menuName = "UltimateScriptable/Weapon", order = 0)]
  public class Weapon : ScriptableObject {
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    [Tooltip("The Object to Spawn")]
    public GameObjectReference Reference;
    [HideInInspector]
    public GameObject ObjectInScene;
    public Pool pool;

    // TODO: all the properties below should be scriptable object references and not the current types.
    // [Min(1)]
    // [Tooltip("How many bullet we spawning before cooldown/reload")]
    // public int MaxFireCount = 1;
    [Min(1)]
    [Tooltip("How many bullets per Fire()")]
    public int ProjectileCount = 1;
    [Tooltip("How fast are we firing between each shot?")]
    public float FireRate = .1f;
    [Tooltip("Angle Step.")]
    public Vector3 Spread = Vector3.up * 30;
    // [Tooltip("How long to reload? Cooldown start after reaching max fire count")]
    // public float ReloadCooldown = 0f;
    // TODO: icon

    public GameObject SpawnProjectile(Transform tran) {
      return pool.TakeOutQueue(tran);
    }

    public GameObject SpawnProjectile(Vector3 position, Quaternion rotation) {
      return pool.TakeOutQueue(position, rotation);
    }
  }
}