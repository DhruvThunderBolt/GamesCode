using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    private AudioSource audioSource;
    
    [SerializeField]
    private AudioClip attack1, attack2, death, hit1, hit2, hit3;
    
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Attack1()
    {
        audioSource.clip = attack1;
        audioSource.Play();
    }

    public void Attack2()
    {
        audioSource.clip = attack2;
        audioSource.Play();
    }

    public void Die() 
    {
        audioSource.clip = death;
        audioSource.Play();
    }

    public void Hit1()
    {
        audioSource.clip = hit1;
        audioSource.Play();
    }

    public void Hit2()
    {
        audioSource.clip = hit2;
        audioSource.Play();
    }

    public void Hit3()
    {
        audioSource.clip = hit3;
        audioSource.Play();
    }
}
