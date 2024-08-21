using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DuplicateOnGrab : MonoBehaviour
{
    public GameObject objectToClone;
    public Vector3 fixedPosition; // The position where the duplicate will always appear

    void Start()
    {
        // Ensure the object has an XRGrabInteractable component
        XRGrabInteractable grabInteractable = objectToClone.GetComponent<XRGrabInteractable>();
        if (grabInteractable == null)
        {
            grabInteractable = objectToClone.AddComponent<XRGrabInteractable>();
        }

        // Subscribe to the select entered event
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        // Duplicate the object at the fixed position
        Instantiate(objectToClone, fixedPosition, objectToClone.transform.rotation);
    }
}