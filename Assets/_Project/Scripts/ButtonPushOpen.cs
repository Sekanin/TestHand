using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    public float openAngle = 90f;
    public float openSpeed = 2f;
    private bool isOpen = false;

    public void ToggleDoors()
    {
        isOpen = !isOpen;
        StopAllCoroutines();
        StartCoroutine(RotateDoor(leftDoor, isOpen ? openAngle : 0));
        StartCoroutine(RotateDoor(rightDoor, isOpen ? -openAngle : 0));
    }

    private IEnumerator RotateDoor(GameObject door, float targetAngle)
    {
        Quaternion startRotation = door.transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(0, targetAngle, 0);
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * openSpeed;
            door.transform.localRotation = Quaternion.Slerp(startRotation, endRotation, t);
            yield return null;
        }
    }
}

