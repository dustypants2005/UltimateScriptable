using System.Diagnostics.Tracing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(MoveController))]
public class JumpController : MonoBehaviour {
  [SerializeField] InputActionReference JumpUpActionReference;
  [SerializeField] InputActionReference JumpDownActionReference;
  [SerializeField] float JumpPower = 10f;

  [SerializeField] float Gravity = 1f;
  [SerializeField] float HiGravity = 30f;
  [SerializeField] float LowGravity = 10f;
  MoveController controller {
    get {
      if (_controller == null) {
        _controller = GetComponent<MoveController>();
      }
      return _controller;
    }
  }
  MoveController _controller;
  [SerializeField] bool IsJumping = false;
  bool Jumped = false;


  void OnEnable() {
    JumpUpActionReference.action.performed += JumpUpEventHandler;
    JumpUpActionReference.action.canceled += JumpUpEventHandlerCanceled;
    JumpDownActionReference.action.performed += JumpDownEventHandler;
    JumpDownActionReference.action.canceled += JumpDownEventHandlerCanceled;
    Gravity = LowGravity;
  }

  void OnDisable() {
    JumpUpActionReference.action.performed -= JumpUpEventHandler;
    JumpUpActionReference.action.canceled -= JumpUpEventHandlerCanceled;
    JumpDownActionReference.action.performed -= JumpDownEventHandler;
    JumpDownActionReference.action.canceled -= JumpDownEventHandlerCanceled;
  }

  void Update() {
    if (Jumped) {
      Jumped = false; // pressed Jump this frame
      return;
    }
    if (IsJumping && controller.Controller.velocity.y < 0) { // reached peek jump
      IsJumping = false;
      Gravity = HiGravity;
    }
    if (controller.IsGrounded) {
      controller.VerticalVelocity = -1;
    } else {
      controller.VerticalVelocity -= Gravity * Time.deltaTime;
    }
  }

  /// <summary>
  /// Jump Button Released
  /// </summary>
  /// <param name="context"></param>
  void JumpUpEventHandler(CallbackContext context) {
    Gravity = HiGravity;
    IsJumping = false;
  }
  void JumpUpEventHandlerCanceled(CallbackContext context) {

  }

  /// <summary>
  /// Jump Button Down
  /// </summary>
  /// <param name="context"></param>
  void JumpDownEventHandler(CallbackContext context) {
    if (IsJumping) return; // can't jump while jumping
    if (!controller.IsGrounded) return; // Jump only on ground
    Gravity = LowGravity;
    controller.VerticalVelocity = JumpPower;
    IsJumping = true;
    Jumped = true;
  }
  void JumpDownEventHandlerCanceled(CallbackContext context) {

  }
}
