using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections; // Include this to use IEnumerator and coroutines

public class ReturnToHangPoint : MonoBehaviour
{
    public Transform hangPoint; // The position where the cube should return
    public float returnThreshold = 0.5f; // Distance to auto-return the cube
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    private bool returning;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        // Disable gravity initially
        rb.useGravity = false;

        // Subscribe to events
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnRelease(SelectExitEventArgs arg)
    {
        if (Vector3.Distance(transform.position, hangPoint.position) < returnThreshold)
        {
            StartCoroutine(ReturnToHang()); // Correct usage to start a coroutine
        }
        else
        {
            rb.useGravity = true;
        }
    }

    private IEnumerator ReturnToHang() // Correct method signature
    {
        returning = true;
        rb.useGravity = false;
        rb.isKinematic = true;

        while (Vector3.Distance(transform.position, hangPoint.position) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, hangPoint.position, Time.deltaTime * 5f);
            yield return null; // Correct usage within a coroutine
        }

        transform.position = hangPoint.position;
        rb.isKinematic = false;
        returning = false;
    }
}


