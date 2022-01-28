using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PortalReference : MonoBehaviour
{

    [Header("Portal references")]
    public GameObject skullPortal;
    public GameObject catPortal;
    public GameObject gargoylePortal;
    public GameObject slimePortal;
    public GameObject spiderPortal;
    public GameObject plantMonsterPortal;
    public GameObject deathNightPortal;

    [Header("Everything dead Unity Event")]
    public UnityEvent everythingDead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update() {
        /*
        if (skullDead & skullPortal != null) {
            skullPortal.SetActive(false);
        }

        if (catDead & catPortal != null) {
            catPortal.SetActive(false);
        }

        if (gargoyleDead & gargoylePortal != null) {
            gargoylePortal.SetActive(false);
        }

        if (slimeDead & slimePortal != null) {
            slimePortal.SetActive(false);
        }

        if (spiderDead & spiderPortal != null) {
            spiderPortal.SetActive(false);
        }

        if (plantMonsterDead & plantMonsterPortal != null) {
            plantMonsterPortal.SetActive(false);
        }

        if (deathNightDead & deathNightPortal != null) {
            deathNightPortal.SetActive(false);
        }

        if (skullDead & catDead & gargoyleDead & slimeDead & spiderDead & plantMonsterDead & deathNightDead) {
            everythingDead.Invoke();
        }
        */
    }
}
