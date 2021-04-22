using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(CharacterController))]
public class MoveController : MonoBehaviour {
  [SerializeField] float Speed = 1f;
  public CharacterController Controller {
    get {
      if (controller == null) {
        controller = GetComponent<CharacterController>();
      }
      return controller;
    }
  }
  CharacterController controller;
  [SerializeField] InputActionReference actionReference;
  [SerializeField] Vector3 moveDirection = Vector3.zero;
  void OnEnable() {
    actionReference.action.performed += OnMove;
    actionReference.action.canceled += OnMoveCancel;
  }
  void OnDisable() {
    actionReference.action.performed -= OnMove;
    actionReference.action.canceled -= OnMoveCancel;
  }
  void Update() {
    var md = transform.TransformDirection(moveDirection);
    Controller.Move(md.normalized * Speed * Time.deltaTime);
  }

  void OnMove(CallbackContext context) {
    Vector2 ls = context.ReadValue<Vector2>();
    moveDirection = new Vector3(ls.x, 0, ls.y);
  }

  void OnMoveCancel(CallbackContext context) {
    moveDirection = Vector3.zero;
  }
}
