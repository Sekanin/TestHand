using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DuplicateOnGrab : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable newPrefab;
    
    private XRGrabInteractable grabInteractable;
    
    private void Start()
    {
        StartCoroutine(CreateWithDelay(1.0f)); // 1 second delay
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
    }
    private void OnGrabbed(SelectEnterEventArgs args)
    {
        // Start the coroutine to duplicate the object with a delay
        StartCoroutine(CreateWithDelay(1.0f)); // 1 second delay
    }
    
    private IEnumerator CreateWithDelay(float delay)
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delay);

        var created = Instantiate(newPrefab);

        //duplicate.transform.position = fixedPosition;
        created.transform.position = transform.position;

        var rb = created.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }
        
        if (grabInteractable != null) grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        
        grabInteractable = created;
        grabInteractable.selectEntered.AddListener(OnGrabbed);
    }
}
