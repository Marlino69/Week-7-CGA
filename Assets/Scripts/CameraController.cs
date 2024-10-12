using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f;          // Speed for movement
    public float rotateSpeed = 100f;      // Speed for rotation
    public float mouseSensitivity = 2f;   // Sensitivity for mouse look

    private float yaw;                     // Horizontal rotation
    private float pitch;                   // Vertical rotation

    void Update()
    {
        // Mouse look around
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity; // Horizontal mouse movement
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity; // Vertical mouse movement
        pitch = Mathf.Clamp(pitch, -89f, 89f); // Limit vertical rotation

        // Apply the rotation
        transform.eulerAngles = new Vector3(pitch, yaw, 0);

        // Translation with W, A, S, D keys
        Vector3 moveDirection = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += -transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += -transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
        }

        // Move the camera
        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
    }
}
