using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace UltimateScriptable.Input {
  [CreateAssetMenu(fileName = "InputVaiable", menuName = "UltimateScriptable/InputVaiable", order = 0)]
  public class InputVariable : ScriptableObject {
    public InputActionReference InputAction;
    public UnityEvent<CallbackContext> InputEvent;
  }
}