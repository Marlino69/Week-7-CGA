using UnityEngine;

public class SphereOrbit : MonoBehaviour
{
    public GameObject pointLight; // Referensi ke point light
    public float orbitSpeed = 10f; // Kecepatan perputaran
    public float orbitDistance = 5f; // Jarak dari point light
    public float groundY = 0f; // Posisi Y dari alas

    void Update()
    {
        if (pointLight != null)
        {
            // Menghitung posisi orbit di sekitar point light
            float angle = orbitSpeed * Time.deltaTime;
            transform.RotateAround(pointLight.transform.position, Vector3.up, angle);

            // Menjaga jarak sphere dengan point light
            Vector3 direction = (transform.position - pointLight.transform.position).normalized;
            transform.position = pointLight.transform.position + direction * orbitDistance;

            // Atur posisi Y sphere agar menyentuh alas di posisi groundY
            transform.position = new Vector3(transform.position.x, groundY + (transform.localScale.y / 2), transform.position.z);
        }
    }
}
