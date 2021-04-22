using UltimateScriptable.Variables;
using UnityEngine;

namespace UltimateScriptable {
  public class PlayerController : MonoBehaviour {
    public PlayerManager Manager;
    public GameObject WeaponMount;
    public GameObjectVariable player;

    void OnEnable() {
      player.SetValue(gameObject);
      Manager.SetController(this);
      Manager.OnEnableEvent?.Invoke();
      Manager.Init(WeaponMount);
    }

    void OnDisable() {
      Manager.OnDisableEvent?.Invoke();
    }
  }
}