using UnityEngine;

public class PointLightCuller : MonoBehaviour
{
    public Camera specificCamera; // Reference to the specific camera
    public float cullingDistance = 10f; // Distance at which the light will be culled

    private Light pointLight;

    void Start()
    {
        // Get the reference to the point light component
        pointLight = GetComponent<Light>();

        // Make sure the light is a point light
        if (pointLight == null || pointLight.type != LightType.Point)
        {
            Debug.LogWarning("PointLightCuller script requires a Point Light component.");
            enabled = false; // Disable the script if the light is not valid
            return;
        }

        // If specificCamera is not assigned, default to the main camera
        if (specificCamera == null)
        {
            specificCamera = Camera.main;
        }
    }

    void Update()
    {
        if (specificCamera == null)
            return;

        // Calculate the distance from the specific camera to the point light
        float distanceToCamera = Vector3.Distance(transform.position, specificCamera.transform.position);

        // Check if the distance is greater than the culling distance
        if (distanceToCamera > cullingDistance)
        {
            // Disable the light to cull it
            pointLight.enabled = false;
        }
        else
        {
            // Enable the light if it's within the culling distance
            pointLight.enabled = true;
        }
    }
}