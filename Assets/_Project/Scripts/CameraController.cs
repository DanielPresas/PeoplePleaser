using UnityEngine;

public class CameraController : MonoBehaviour {
    public float panSpeed = 15.0f;
    public float rotateSpeed = 15.0f;
    public float zoomSpeed = 15.0f;

    void Update() {
        //
        // Camera movement with WASD
        //
        var f = transform.forward; f.y = 0.0f; f = f.normalized;
        var r = transform.right;   r.y = 0.0f; r = r.normalized;
        var pos = transform.position;
        var speed = panSpeed * Time.deltaTime;

        // Panning movement
        if(Input.GetKey(KeyCode.W)) { pos += f * speed; }
        if(Input.GetKey(KeyCode.S)) { pos -= f * speed; }
        if(Input.GetKey(KeyCode.A)) { pos -= r * speed; }
        if(Input.GetKey(KeyCode.D)) { pos += r * speed; }

        // Zoom movement
        var mouseScroll = Input.GetAxisRaw("Mouse ScrollWheel");
        pos += transform.forward * mouseScroll * zoomSpeed * Time.deltaTime;

        // Apply movement
        transform.position = pos;

        //
        // Camera rotation while holding MMB
        //
        var mouseDragX = 0.0f;
        var mouseDragY = 0.0f;
        if(Input.GetMouseButton(MouseButton.Middle)) {
            Cursor.lockState = CursorLockMode.Locked;
            mouseDragX = Input.GetAxisRaw("Mouse X") * rotateSpeed * Time.deltaTime;
            mouseDragY = Input.GetAxisRaw("Mouse Y") * rotateSpeed * Time.deltaTime;
        }
        else {
            Cursor.lockState = CursorLockMode.None;
        }

        transform.RotateAround(transform.position, Vector3.up, mouseDragX);
        transform.RotateAround(transform.position, r, -mouseDragY);

        // @Incomplete: clamp up/down rotation on the camera
        // if(transform.localRotation.eulerAngles.x > 65.0f) { // find a better clamp value, or set in editor
        //     var rot = transform.localRotation;
        //     rot.eulerAngles = new Vector3(65.0f, rot.y, rot.z); // see above
        //     transform.localRotation = rot;
        // }
    }
}
