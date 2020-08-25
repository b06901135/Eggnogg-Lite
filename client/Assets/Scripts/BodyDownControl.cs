﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyDownControl : MonoBehaviour
{
    public PlayerController PlayerControllerbody;
    public PlayerManager playermanager;
    private Animator animator;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerbody = gameObject.transform.parent.gameObject.GetComponent<PlayerController>();
        animator = PlayerControllerbody.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "sword") {
            player = other.gameObject.transform.parent.parent.parent.parent.gameObject;
            playermanager = player.GetComponent<PlayerManager>();
            Debug.Log(player.name);
            Debug.Log("AaronMESSage : down being hit");
            if(player.transform.Find("bodydown").gameObject != gameObject){
                if(playermanager.face_right != PlayerControllerbody.face_right){
                    bool is_up = animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle_Sword_Down");
                    bool is_run = animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Run_Sword_Down");
                    bool is_up_attack = animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle_Attack_Sword_Down");
                    bool is_run_attack = animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Run_Attack_Sword_Down");
                    if(!is_up && !is_up_attack && !is_run && !is_run_attack){
                        Debug.Log("Aaron : " + PlayerControllerbody.gameObject.name + " down dead 1");
                        PlayerControllerbody.trigger_dead();
                    }
                }
                else{
                    Debug.Log("Aaron : " + PlayerControllerbody.gameObject.name + " down dead 2");
                    PlayerControllerbody.trigger_dead();
                }
            }
        }
    }
}
