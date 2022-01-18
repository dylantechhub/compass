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

            SetActiveNPC(0);

        }
        else if (Input.GetKey(KeyCode.Alpha2)) {
            SetActiveNPC(1);
        } else if (Input.GetKey(KeyCode.Alpha3)) {
            SetActiveNPC(2);
        } else if (Input.GetKey(KeyCode.Alpha4)) {
            SetActiveNPC(3);
        } else if (Input.GetKey(KeyCode.Alpha5)) {
            SetActiveNPC(4);
        } else if (Input.GetKey(KeyCode.Alpha6)) {
            SetActiveNPC(5);
        }
    }

    private void SetActiveNPC(int num)
    {
        DisableAll();
        if (npcList.Length > num)
            npcList[num].SetActive(true);
    }

    private void DisableAll(){
        for (int i = 0; i < npcList.Length; i++) {
            npcList[i].SetActive(false);
        }
    }
}
