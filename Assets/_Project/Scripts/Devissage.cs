using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoltUnscrewer : MonoBehaviour
{
    public Button yourButton;
    public GameObject[] bolts;
    public float unscrewSpeed = 90f;
    public float moveSpeed = 0.1f;
    public float maxDistance = 0.1f;

    void Start()
    {
        yourButton.onClick.AddListener(UnscrewBolts);
    }

    void UnscrewBolts()
    {
        foreach (GameObject bolt in bolts)
        {
            StartCoroutine(UnscrewAndMoveBolt(bolt));
        }
    }

    IEnumerator UnscrewAndMoveBolt(GameObject bolt)
    {
        Vector3 startPosition = bolt.transform.position;
        while (Vector3.Distance(startPosition, bolt.transform.position) < maxDistance)
        {
            bolt.transform.Rotate(0, 0, unscrewSpeed * Time.deltaTime);
            
            bolt.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            
            yield return null;
        }
    }
}


