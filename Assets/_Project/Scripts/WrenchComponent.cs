/*using UnityEngine;
using UnityEngine.XR;

public class WrenchVR : MonoBehaviour
{
    private Bolt currentBolt;
    private Vector3 lastControllerPosition;
    private Quaternion lastControllerRotation;

    void Update()
    {
        if (currentBolt != null)
        {
            Vector3 currentControllerPosition = InputTracking.GetLocalPosition(XRNode.RightHand);
            Quaternion currentControllerRotation = InputTracking.GetLocalRotation(XRNode.RightHand);

            Vector3 deltaPosition = currentControllerPosition - lastControllerPosition;
            float deltaRotation = Quaternion.Angle(lastControllerRotation, currentControllerRotation);

            if (deltaRotation > 0.1f) // Ajoute une tolérance pour éviter les mouvements accidentels
            {
                float rotationDirection = Mathf.Sign(Vector3.Dot(deltaPosition, transform.right));
                currentBolt.Unscrew(rotationDirection);
            }

            lastControllerPosition = currentControllerPosition;
            lastControllerRotation = currentControllerRotation;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt"))
        {
            currentBolt = other.gameObject.GetComponent<Bolt>();
            lastControllerPosition = InputTracking.GetLocalPosition(XRNode.RightHand);
            lastControllerRotation = InputTracking.GetLocalRotation(XRNode.RightHand);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt"))
        {
            currentBolt = null;
        }
    }
}*/
using UnityEngine;

public class Wrench : MonoBehaviour
{
    private Bolt currentBolt;
    private Vector3 lastMousePosition;

    void Update()
    {
        if (currentBolt != null)
        {
            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
            if (deltaMouse.magnitude > 0.1f)
            {
                float rotationDirection = Mathf.Sign(Vector3.Dot(deltaMouse, transform.right));
                currentBolt.Unscrew(rotationDirection);
            }
        }
        lastMousePosition = Input.mousePosition;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt"))
        {
            currentBolt = other.gameObject.GetComponent<Bolt>();
            lastMousePosition = Input.mousePosition;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt"))
        {
            currentBolt = null;
        }
    }
}
