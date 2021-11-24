using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleNPCS_Debug : MonoBehaviour
{

    public GameObject[] npcList;

    // Start is called before the first frame update
    void Start()
    {
        npcList[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1)){
            // enable first

            DisableAll();

            npcList[0].SetActive(true);

        }else if (Input.GetKey(KeyCode.Alpha2)) {
            DisableAll();
            if(npcList.Length > 1)
                npcList[1].SetActive(true);
        } else if (Input.GetKey(KeyCode.Alpha3)) {
            DisableAll();
            if (npcList.Length > 2)
                npcList[2].SetActive(true);
        } else if (Input.GetKey(KeyCode.Alpha3)) {
            DisableAll();
            if (npcList.Length > 3)
                npcList[3].SetActive(true);
        } else if (Input.GetKey(KeyCode.Alpha4)) {
            DisableAll();
            if (npcList.Length > 4)
                npcList[4].SetActive(true);
        } else if (Input.GetKey(KeyCode.Alpha5)) {
            DisableAll();
            if (npcList.Length > 5)
                npcList[5].SetActive(true);
        }
    }

    private void DisableAll(){
        for (int i = 0; i < npcList.Length; i++) {
            npcList[i].SetActive(false);
        }
    }
}
