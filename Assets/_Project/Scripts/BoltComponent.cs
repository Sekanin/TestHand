using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BoltTightening : MonoBehaviour
{
    public Transform bolt; // The bolt that needs to be tightened
    public float rotationSpeed = 100f; // Speed at which the bolt tightens
    private bool isTightening = false; // State to check if the bolt is being tightened

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wrench"))
        {
            // Start tightening when the wrench is in contact with the bolt
            isTightening = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wrench"))
        {
            // Stop tightening when the wrench is no longer in contact with the bolt
            isTightening = false;
        }
    }

    private void Update()
    {
        if (isTightening)
        {
            // Rotate the bolt to simulate tightening
            bolt.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
}

