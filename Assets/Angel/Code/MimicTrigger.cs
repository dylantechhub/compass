using UnityEngine;

public class MimicTrigger : MonoBehaviour
{
    public GameObject mimic;
    public GameObject gargoyle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gargoyle.GetComponent<GargoylePathFollowing>().enabled = true;
        mimic.SetActive(false);
        Debug.Log("Mimic Starts");
    }
}
