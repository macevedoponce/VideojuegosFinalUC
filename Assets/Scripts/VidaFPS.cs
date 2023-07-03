using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VidaFPS : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public VidaSlider VidaSlider;
    bool isInmune;
    public float inmunityTime;

    public static event Action OnPlayerDeath;
    public static event Action OnPlayerWin;

    private AudioManager soundManager;

    private void Start() {
        currentHealth = maxHealth;
        VidaSlider.SetMaxHealth(maxHealth);
        soundManager = FindObjectOfType<AudioManager>();
    }

    private void Update() {
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }

        if(currentHealth <= 0){
            currentHealth = 0;
            //pantalla game over
            soundManager.ChooseAudio(5, 0.4f);
            print("PLAYER DEAD");            
            OnPlayerDeath?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider collision) {
        switch (collision.gameObject.tag)
        {
            case "Lava":
                if(!isInmune){
                    //soundManager.ChooseAudio(6, 2f);
                    currentHealth -= collision.GetComponent<LavaDamage>().LavaDamageToGive;
                    TakeDamageBarHP();
                    StartCoroutine(Inmunity());
                }
                break;
            case "Botiquin":
                soundManager.ChooseAudio(3, 0.4f);
                currentHealth += collision.GetComponent<Botiquin>().DarVida;
                TakeDamageBarHP();
                Destroy(GameObject.FindWithTag("Botiquin"));
                break;
            case "CajaGanar":
                soundManager.ChooseAudio(6, 0.4f);
                Destroy(GameObject.FindWithTag("CajaGanar"));
                OnPlayerWin?.Invoke();
                soundManager.ChooseAudio(4, 0.4f);
                break;
            case "Enemy":
                if(!isInmune){
                    //soundManager.ChooseAudio(6, 2f);
                    currentHealth -= collision.GetComponent<EnemyDamage>().EnemyDamageToGive;
                    TakeDamageBarHP();
                    StartCoroutine(Inmunity());
                }
                break;
            case "armaEnemySubordinado":
                if (!isInmune)
                {
                    //soundManager.ChooseAudio(6, 2f);
                    currentHealth -= collision.GetComponent<EnemyDamage>().EnemyDamageToGive;
                    TakeDamageBarHP();
                    StartCoroutine(Inmunity());
                }
                break;
            default:
                break;
        }
        // if(collision.gameObject.tag == "Lava" && !isInmune){
        //     currentHealth -= collision.GetComponent<LavaDamage>().LavaDamageToGive;
        //     TakeDamageBarHP();
        // }
    }

    void TakeDamageBarHP(){
        VidaSlider.Health(currentHealth);
    }

    IEnumerator Inmunity(){
        isInmune = true;
        yield return new WaitForSeconds(inmunityTime);
        isInmune = false;
    }
}
