using UnityEngine;
using UnityEngine.UI;

public class cooldownSlider : MonoBehaviour
{
    public Slider cooldown;
    public RandomTeleport teleportScript;

    private void Start()
    {
        teleportScript = FindObjectOfType<RandomTeleport>();
        cooldown.maxValue = teleportScript.cooldown;
    }
    void Update()
    {
        // Assigning slider the value of the cooldown timer on the player teleport script
        cooldown.value = teleportScript.cooldownTimer;
    }
}
