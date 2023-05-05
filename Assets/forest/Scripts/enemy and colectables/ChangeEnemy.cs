﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeEnemy : MonoBehaviour{
    [SerializeField] string TagPlayer="Jugador";
    [SerializeField] Collider capsuleCollider;
    [SerializeField]Color Verde, Rojo;    
    [SerializeField] Renderer renderer;    
    [SerializeField] float waitTime;
    [SerializeField]int _Sound;
    [SerializeField] AudioClip _EnemyChange;
    [SerializeField]Text TextCargar;
    
    GameManager GameManager;
    SoundFXManagerv FXManager;

    void OnTriggerEnter(Collider other){
		if (other.tag == TagPlayer){
        FXManager.SoundPlay(_EnemyChange,_Sound);        
        GameManager.IsCoin=true;
        capsuleCollider.isTrigger=false;
        renderer.material.color=Rojo;
        StartCoroutine(VidaEnemy());
        }
    }  
    
    void SearchManagers() {      
           if(GameManager==null){
        GameManager=FindObjectOfType<GameManager>();
        if(FXManager==null){
        FXManager=FindObjectOfType<SoundFXManagerv>();
        } 
      }   
    }
     void Awake(){
        SearchManagers();
        renderer.material.color=Verde;

        }    
      IEnumerator VidaEnemy(){
        TextCargar.text="Tu turno de atacar!";
      yield return new WaitForSeconds(waitTime);
      TextCargar.text="";
      GameManager.IsCoin=false;
      capsuleCollider.enabled=false;
      Debug.Log("tiempo acabado");
      renderer.enabled = false;   

      }

}
