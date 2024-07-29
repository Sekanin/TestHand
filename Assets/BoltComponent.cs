using UnityEngine;

public class BoltComponent : MonoBehaviour
{
    private Transform wrench, bolt;
    private void Update()
    {
        // Assuming wrench and bolt are Transform objects
        wrench.position = bolt.position; 
        wrench.rotation = wrench.rotation * Quaternion.FromToRotation(wrench.up, 
            Vector3.ProjectOnPlane(wrench.up, bolt.right));
            
        // Assuming you have an Animator component attached to the wrench GameObject
        Animator wrenchAnimator = wrench.GetComponent<Animator>();
        wrenchAnimator.SetTrigger("Rotate");
        
    }
}

