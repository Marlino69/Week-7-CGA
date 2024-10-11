using System.Collections;
using UnityEngine;

public class RandomLightColor : MonoBehaviour
{
    private Light pointLight;

    void Start()
    {
        pointLight = GetComponent<Light>();
        
        StartCoroutine(ChangeLightColor());
    }

    IEnumerator ChangeLightColor()
    {
        while (true)
        {
            pointLight.color = new Color(Random.value, Random.value, Random.value);
            
            yield return new WaitForSeconds(1f);
        }
    }
}
