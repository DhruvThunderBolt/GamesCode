using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public float baseHealth = 250;
    public float health = 250f;
    private float x_death =  -90f;
    private float death_smooth = 0.9f;
    private float rotate_Time = 0.23f;
    private bool isDead;
    private float timeSinceDeath = 0f;

    private SoundEffects audio;

    [SerializeField]
    private Image healthUI;

    [HideInInspector]
    public bool shieldActivated;

    // public CameraFollow mainCamera;

    public bool isPlayer;

    void Awake() 
    {
        // mainCamera = GetComponent<CameraFollow>();
        audio = GetComponentInChildren<SoundEffects>();
        if(isPlayer)
            health = 250f;
    }

    void Update() 
    {
        if(isDead)
        {
            RotateAfterDeath();
            audio.Die();
        }
    }

    public void applyDamage(float Damage)
    {
        
        if(shieldActivated)
        {
            health -= (Damage*0.3f);
            if(healthUI != null)
            {
                healthUI.fillAmount = health/baseHealth;
                // audio.Hit1();
            }
            return;
        }

        health -= Damage;
        // if(Random.Range(0, 2) >0)
        // {
        //     audio.Hit2();
        // }
        // else
        // {
        //     audio.Hit3();
        // }

        if(healthUI != null)
        {
            healthUI.fillAmount = health/baseHealth;
        }
        if(health <= 0)
        {
            GetComponent<Animator>().enabled = false;
            StartCoroutine(AllowRotate());
            if(isPlayer)
            {
                GetComponent<PlayerMovement>().enabled = false;
                GetComponent<PAttacking>().enabled = false;

                transform.GetChild(3).parent = null;
                

                GameObject.FindGameObjectWithTag(Tags.EnemyTag).
                GetComponent<EnemyController>().enabled = false;
            }
            else
            {
                GetComponent<NavMeshAgent>().enabled = false;
                GetComponent<EnemyController>().enabled = false;
            }
        }
    }

    IEnumerator AllowRotate()
    {
        isDead = true;
        yield return new WaitForSeconds(rotate_Time);
        isDead = false;
    }

    void RotateAfterDeath()
    {
        timeSinceDeath+=Time.deltaTime;
        if(timeSinceDeath<rotate_Time)
        {
            transform.eulerAngles = new Vector3(
                Mathf.Lerp(transform.eulerAngles.x, x_death, timeSinceDeath/rotate_Time),
                transform.eulerAngles.y, transform.eulerAngles.z);
        }
        else
        {
            transform.eulerAngles = new Vector3(x_death,transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
