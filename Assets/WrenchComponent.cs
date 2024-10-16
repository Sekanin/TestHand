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
            if (deltaMouse.magnitude > 0.1f) // Ajoute une tolérance pour éviter les mouvements accidentels
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


