using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {
    public ClickFeedback feedback;
    public float playerSpeed = 4.2f;
    public float rotationSpeed = 360.0f;

    private Transform _target = null;

    private void Update() {
        if(Input.GetMouseButtonDown(MouseButton.Left)) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(EventSystem.current.currentSelectedGameObject == null && Physics.Raycast(ray, out var hit)) InstantiateClickFeedback(hit.point);
        }

        if(_target != null) {
            var directionTowards = Vector3.Normalize(_target.position - transform.position);

            if(Vector3.Dot(transform.forward, directionTowards) < 0.95f) {
                var angle = Vector3.SignedAngle(transform.forward, directionTowards, Vector3.up);
                transform.RotateAround(transform.position, Vector3.up, (angle < 0 ? -1 : 1) * rotationSpeed * Time.deltaTime);
            }

            if(Vector3.Distance(transform.position, _target.position) > 0.05f) {
                transform.position += directionTowards * playerSpeed * Time.deltaTime;
            }
            else {
                Destroy(_target.gameObject);
            }
        }
    }

    public void InstantiateClickFeedback(Vector3 position) {
        if(_target != null) Destroy(_target.gameObject, feedback.lifetime);
        var f = Instantiate(feedback.gameObject, feedback.gameObject.transform.position + position, feedback.gameObject.transform.rotation);
        _target = f.transform;
    }
}
