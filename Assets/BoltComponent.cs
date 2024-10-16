using UnityEngine;

public class Bolt : MonoBehaviour
{
    public float unscrewSpeed = 90f;
    public float moveSpeed = 0.1f;
    public float maxDistance = 0.1f;
    private bool isUnscrewing = false;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    public void Unscrew(float direction)
    {
        if (!isUnscrewing)
        {
            float unscrewAmount = direction * unscrewSpeed * Time.deltaTime;
            float moveAmount = moveSpeed * Time.deltaTime;

            transform.Rotate(Vector3.forward, unscrewAmount);
            transform.Translate(Vector3.forward * moveAmount);

            if (Vector3.Distance(transform.position, initialPosition) >= maxDistance)
            {
                isUnscrewing = true; // Prevent further unscrewing
                MakeBoltDisappear();
            }
        }
    }

    void MakeBoltDisappear()
    {
        Destroy(gameObject, 0.1f);
    }
}



