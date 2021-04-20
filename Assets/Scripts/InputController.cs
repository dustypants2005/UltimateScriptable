using UnityEngine;

namespace UltimateScriptable.Input {
  public class InputController : MonoBehaviour {
    public InputCollection inputCollection;

    void OnEnable() {
      foreach (var item in inputCollection.Collection) {
        if (!item.InputAction.asset.enabled) {
          item.InputAction.asset.Enable();
        }
      }
    }

    void OnDisable() {
      foreach (var item in inputCollection.Collection) {
        if (item.InputAction.asset.enabled) {
          item.InputAction.asset.Disable();
        }
      }
    }

    void Awake() {
      foreach (var item in inputCollection.Collection) {
        item.InputAction.action.performed += ctx => {
          item.InputEvent?.Invoke(ctx);
        };
      }
    }
  }
}