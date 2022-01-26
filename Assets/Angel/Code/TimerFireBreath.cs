#pragma warning disable 8321 // disables editor warnings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading;
using System.Threading.Tasks;

public enum CurrentState
{
    Stone,
    Flying,
    Fire,
    Idle
}

public class TimerFireBreath : MonoBehaviour
{
    public CurrentState currentState;
    public float timer = 0f;
    public float timeBetweenAttacks = 5f;
    public float fireTime = 2f;


    //[Header("Attacks")]
    //public UnityEvent fireBreath;

    [Header("Sprites")]
    public SpriteRenderer rend;
    public Sprite fire;
    public Sprite idle;
    public Sprite attack;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks)
        {
            currentState = CurrentState.Fire;
            timer = 0f;
            
        }
        else if (timer >= fireTime && timer <= timeBetweenAttacks)
        {
            currentState = CurrentState.Idle;
        }

        if (currentState == CurrentState.Fire)
        {
            ActivateFireBreath();

        }

        if (currentState == CurrentState.Stone)
        {
            gameObject.GetComponent<PathFollowing>().enabled = false;
        }

        if (currentState == CurrentState.Idle)
        {
            gameObject.GetComponent<PathFollowing>().enabled = true;
            Deactivate();
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            ActivateAttack();
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            
        }

        // Changes sprite to fire and changes the collider
        void ActivateFireBreath()
        {
            rend.sprite = fire;

        }

        // Changes sprite to normal and changes the collider back
        void Deactivate()
        {
            rend.sprite = idle;
        }

        // Changes sprite to attack
        void ActivateAttack()
        {
            rend.sprite = attack;
        }
    }
}
