using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(CharacterController))]
public class MoveController : MonoBehaviour {
  [SerializeField] InputActionReference actionReference;
  public Queue<Vector3> MoveQueue = new Queue<Vector3>();
  public float VerticalVelocity = -1f;
  [SerializeField] float Speed = 1f;
  public bool IsGrounded {
    get {
      return Controller.isGrounded;
    }
  }
  public CharacterController Controller {
    get {
      if (_controller == null) {
        _controller = GetComponent<CharacterController>();
      }
      return _controller;
    }
  }
  CharacterController _controller;
  Vector3 moveDirection = Vector3.zero;
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
    md.y = VerticalVelocity;
    for (var i = 0; i < MoveQueue.Count; i++) {
      md += MoveQueue.Dequeue();
    }
    Controller.Move(md.normalized * Speed * Time.deltaTime);
  }

  void OnMove(CallbackContext context) {
    Vector2 ls = context.ReadValue<Vector2>();
    moveDirection = new Vector3(ls.x, VerticalVelocity, ls.y);
  }

  void OnMoveCancel(CallbackContext context) {
    moveDirection = Vector3.zero;
  }
}
