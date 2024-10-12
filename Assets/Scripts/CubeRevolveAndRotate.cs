using UnityEngine;

public class CubeRevolveAndRotate : MonoBehaviour
{
    public GameObject pointLight;    // Assign your point light GameObject in the inspector
    public float revolutionSpeed = 20f;  // Speed of revolution around the point light
    public float rotationSpeed = 50f;    // Speed of cube's own rotation
    public float orbitDistance = 5f;     // Adjustable orbit distance from the point light

    private float angleOffset; // To maintain the initial angle offset

    void Start()
    {
        // Set the initial angle offset based on the cube's current position
        Vector3 direction = (transform.position - pointLight.transform.position).normalized;
        angleOffset = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg; // Calculate the initial angle in degrees
    }

    void Update()
    {
        // Calculate the total angle for the revolution (positive for clockwise)
        float totalAngle = Time.time * revolutionSpeed + angleOffset;
        
        // Determine the orbit position around the point light
        Vector3 orbitPosition = Quaternion.AngleAxis(totalAngle, Vector3.up) * new Vector3(orbitDistance, 0, 0);
        transform.position = pointLight.transform.position + orbitPosition;

        // Rotate the cube counterclockwise around its own Y-axis
        transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
    }
}
