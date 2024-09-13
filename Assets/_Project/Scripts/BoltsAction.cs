using UnityEngine;
using UnityEngine.UI;

public class BoltUnscrew : MonoBehaviour
{
    public Button unscrewButton;
    public Transform bolt;       
    public float unscrewSpeed = 50f;
    public float moveDistance = 0.1f;
    private bool isUnscrewing = false;

    void Start()
    {
        unscrewButton.onClick.AddListener(OnUnscrewButtonPressed);
    }
    void Update()
    {
        if (isUnscrewing)
        {
            bolt.Rotate(Vector3.up * unscrewSpeed * Time.deltaTime);
            
            bolt.Translate(Vector3.forward * moveDistance * Time.deltaTime);
            
            if (bolt.position.y >= 1.0f) 
            {
                isUnscrewing = false;
            }
        }
    }
    void OnUnscrewButtonPressed()
    {
        isUnscrewing = true;
    }
}