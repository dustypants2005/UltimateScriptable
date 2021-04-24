using UnityEngine;

namespace UltimateScriptable {
  public class CameraRaycast : MonoBehaviour {
    [SerializeField] private float camDistance = 15f;
    [SerializeField] private float adjustmentSpeed = 1f;
    [SerializeField] private GameObject vCam;
    public LayerMask LayerMask;
    private Vector3 defaultCameraPosition = Vector3.zero;


    void Start() {
      var campos = vCam.transform.localPosition;
      defaultCameraPosition = new Vector3(campos.x, campos.y, -camDistance);
    }

    void FixedUpdate() {
      var target = GetClosestCameraPosition();
      vCam.transform.localPosition = target;
    }

    Vector3 GetClosestCameraPosition() {
      var currentCamPos = GetCameraPosition(vCam.transform.position);
      var camtran = vCam.transform;
      camtran.localPosition = defaultCameraPosition;
      var defaultCamPos = GetCameraPosition(camtran.position);
      return currentCamPos.z >= defaultCamPos.z ? currentCamPos : defaultCamPos;
    }

    Vector3 GetCameraPosition(Vector3 camposition) {
      var direction = transform.position.Direction(camposition);
      var campos = vCam.transform.localPosition;
      var hit = Physics.Raycast(transform.position, direction, camDistance, LayerMask);
      var hits = Physics.RaycastAll(transform.position, direction, camDistance, LayerMask);
      Vector3 closestHit = ClosestHit(hits, campos);

      if (closestHit == Vector3.zero) {
        return defaultCameraPosition;
      } else {
        return closestHit;
      }
    }

    Vector3 ClosestHit(RaycastHit[] hits, Vector3 campos) {
      Vector3 closestHit = Vector3.zero;
      float closestDistance = Mathf.Infinity;
      foreach (var hit in hits) {
        if (hit.collider.isTrigger) continue;
        var h = transform.position - hit.point;
        var pos = new Vector3(campos.x, campos.y, -h.magnitude);
        var d = transform.position.Distance(pos);

        if (closestDistance > d) {
          closestHit = pos;
          closestDistance = d;
        }
      }
      return closestHit;
    }
  }
}