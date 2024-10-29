using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable newPrefab;
    
    private XRGrabInteractable grabInteractable;
    
    private void Start()
    {
        StartCoroutine(CreateWithDelay(1.0f));
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
    }
    private void OnGrabbed(SelectEnterEventArgs args)
    {
        StartCoroutine(CreateWithDelay(1.0f));
    }
    
    private IEnumerator CreateWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        var created = Instantiate(newPrefab);
        
        created.transform.position = transform.position;

        /*var rb = created.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }*/
        
        if (grabInteractable != null) grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        
        grabInteractable = created;
        //grabInteractable.selectEntered.AddListener(OnGrabbed);
    }
}
