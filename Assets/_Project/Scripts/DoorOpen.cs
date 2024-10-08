using UnityEngine;
using UnityEngine.UI;

public class DoorOpen : MonoBehaviour
{
    public GameObject doorLeft;
    public GameObject doorRight;
    public Button sampleButton;
    private bool isOpen = false;

    void Start()
    {
        sampleButton.onClick.AddListener(ToggleDoors);
    }

    void ToggleDoors()
    {
        isOpen = !isOpen;
        float targetAngle = isOpen ? 90f : 0f;

        doorLeft.transform.localRotation = Quaternion.Euler(0, targetAngle, 0);
        doorRight.transform.localRotation = Quaternion.Euler(0, -targetAngle, 0);
    }
}

