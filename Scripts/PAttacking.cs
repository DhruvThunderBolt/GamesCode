using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttacking : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterAnimations playerAnim;

    public GameObject AttackPoint;

    private PlayerShield shield;

    private SoundEffects audio;

    void Awake()
    {
        playerAnim = GetComponent<CharacterAnimations>();
        shield = GetComponent<PlayerShield>();
        audio = GetComponentInChildren<SoundEffects>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            playerAnim.Defend(true);
            shield.Shielded(true);
        }

        if(Input.GetKeyUp(KeyCode.B))
        {
            playerAnim.unFreeze();
            playerAnim.Defend(false);
            shield.Shielded(false);
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(Random.Range(0, 2) >0)
            {
                playerAnim.Attack1();
                audio.Attack1();
            }
            else
            {
                playerAnim.Attack2();
                audio.Attack2();
            }
        }
    }

    void ActivateAttackPoint()
    {
        AttackPoint.SetActive(true);
    }

    void DeactivateAttackPoint()
    {
        if(AttackPoint.activeInHierarchy)
        {
            AttackPoint.SetActive(false);
        }
    }
}
