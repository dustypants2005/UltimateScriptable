using UltimateScriptable.Variables;
using UnityEngine;

namespace UltimateScriptable {
  public class PlayerController : MonoBehaviour {
    public PlayerManager Manager;
    public GameObject WeaponMount;

    void OnEnable() {
      Manager.SetController(this);
      Manager.OnEnableEvent?.Invoke();
      Manager.Init(WeaponMount);
    }

    void OnDisable() {
      Manager.OnDisableEvent?.Invoke();
    }
  }
}