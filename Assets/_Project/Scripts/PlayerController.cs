using UnityEngine;

public class PlayerController : MonoBehaviour {

    public ClickFeedback feedback;
    public float playerSpeed = 5.0f;

    private Transform _target = null;

    void Update() {
        if(Input.GetMouseButtonDown(MouseButton.Left)) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out var hit)) {
                if(_target != null) Destroy(_target.gameObject, feedback.lifetime);
                var f = Instantiate(feedback.gameObject, feedback.gameObject.transform.position + hit.point, feedback.gameObject.transform.rotation);
                _target = f.transform;
            }
        }

        if(_target != null) {
            if(Vector3.Distance(transform.position, _target.position) > 0.05f) {
                transform.position += Vector3.Normalize(_target.position - transform.position) * playerSpeed * Time.deltaTime;
            }
            else {
                Destroy(_target.gameObject);
            }
        }

    }
}
