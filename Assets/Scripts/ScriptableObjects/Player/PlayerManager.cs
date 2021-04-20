using System.Collections;
using System.Collections.Generic;
using UltimateScriptable.Weapons;
using UnityEngine;
using UnityEngine.Events;

namespace UltimateScriptable {
  [CreateAssetMenu(fileName = "PlayerManager", menuName = "UltimateScriptable/PlayerManager", order = 0)]
  public class PlayerManager : ScriptableObject {
    public WeaponManager WeaponManager;

    public UnityEvent OnEnableEvent;
    public UnityEvent OnDisableEvent;

    PlayerController controller;

    void OnEnable() {
      OnEnableEvent?.Invoke();
    }

    void OnDisable() {
      OnDisableEvent?.Invoke();
    }

    public void Init(GameObject mount) {
      WeaponManager.Init(mount);
    }

    public void SetController(PlayerController _controller) {
      controller = _controller;
    }
  }
}