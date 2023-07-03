using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovEnemy : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    private Animator anim;
    private bool isattacking;

    private int rutina;
    private float cronometro;
    private Quaternion angulo;
    private float grado;

    private float distancia;
    // private GameObject target;


    private void Start() {
        agent = gameObject.GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        isattacking = false;
        //target = GameObject.FindWithTag("Player");
    }

    private void Update() {
        EnemyBehavior();
    }

    public void EnemyBehavior(){
        //Movimiento al azar del enemigo
        if(Vector3.Distance(transform.position, target.transform.position) > 5){

            anim.SetBool("Run", false);

            cronometro += 1 * Time.deltaTime;

            if(cronometro >= 4){
                rutina = Random.Range(0,2);
                cronometro = 0;
            }

            switch(rutina){
                case 0:
                    anim.SetBool("Walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    anim.SetBool("Walk", true);
                    break;
            }
        }
        else{
            //if(Vector3.Distance(transform.position, target.transform.position) > 2 && !isattacking){
                // var lookPos = target.transform.position - transform.position;
                // lookPos.y = 0;
                // var rotation = Quaternion.LookRotation(lookPos);

                // transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                agent.destination = target.position;
                anim.SetBool("Run", true);

                distancia = Vector3.Distance(agent.transform.position, target.transform.position);
                if(distancia <= 2.5f){
                    // transform.Translate(Vector3.zero);
                    // anim.SetBool("Run", false);
                    // anim.SetBool("Walk", false);
                    anim.SetBool("Attack", true);
                }else{
                    anim.SetBool("Attack", false);
                }
                // transform.Translate(Vector3.forward * 2 * Time.deltaTime);

                // anim.SetBool("Attack", false);
            //}
            // else{
            //     anim.SetBool("Walk", false);
            //     anim.SetBool("Run", false);

            //     anim.SetBool("Attack", true);
            //     isattacking = true;
            // }
        }
    }

    // public void notAttacking(){
    //     anim.SetBool("Attack", false);
    //     isattacking = false;
    // }
}
