using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class MouseLookController : MonoBehaviour {
  public MouseLook mouseLook;
  [SerializeField] GameObject CameraMount;
  [SerializeField] InputActionReference actionReference;
  void OnEnable() {
    mouseLook.Init(transform, CameraMount.transform);
    actionReference.action.performed += Look;
  }

  void OnDisable() {
    actionReference.action.performed -= Look;
  }

  public void Look(CallbackContext context) {
    Vector2 rs = context.ReadValue<Vector2>();
    mouseLook.LookRotation(transform, CameraMount.transform, rs);
  }
}
