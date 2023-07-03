using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private Ray rayo;
    private RaycastHit hit;
    public float distanciaDisparo;
    private Camera camara;
    private Vector2 centroCamara;
    public float tempoDisparo;
    public float tempoUltimoDisparo;
    private Quaternion rotDecal;
    private Vector3 posDecal;
    public LayerMask decallayermask; //afecta a los de la sala principal por ahora

    public GameObject[] decalsPrefabs;
    public GameObject[] createdDecals, createdDecals2;
    public int decalIndex;

    public float fuerzaHHit = 100f;
    public int escopetaDamage = 1;

    private AudioManager soundManager;

    void Awake()
    {
        this.camara = gameObject.transform.GetChild(0).GetComponent<Camera>();
        this.centroCamara.x = Screen.width / 2;
        this.centroCamara.y = Screen.height / 2;
        this.tempoUltimoDisparo = Time.time;

        for (int decalNum = 0; decalNum < this.createdDecals.Length; decalNum++) {

            this.createdDecals[decalNum] = GameObject.Instantiate(decalsPrefabs[0], Vector3.zero, Quaternion.identity) as GameObject;
            this.createdDecals[decalNum].GetComponent<Renderer>().enabled = false;
            
            this.createdDecals2[decalNum] = GameObject.Instantiate(decalsPrefabs[1], Vector3.zero, Quaternion.identity) as GameObject;
            this.createdDecals2[decalNum].GetComponent<Renderer>().enabled = false;
        }
        this.decalIndex = 0;
    }

    void Start()
    {
        soundManager = FindObjectOfType<AudioManager>();
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if ((Time.time - this.tempoUltimoDisparo) > this.tempoDisparo)
            {
                this.rayo = this.camara.ScreenPointToRay(this.centroCamara);
                this.tempoUltimoDisparo = Time.time;
                if (Physics.Raycast(this.rayo, out this.hit, this.distanciaDisparo, decallayermask))
                {
                    soundManager.ChooseAudio(8, 0.5f);
                    this.rotDecal = Quaternion.FromToRotation(Vector3.forward, this.hit.normal);
                    this.posDecal = this.hit.point + this.hit.normal * 0.01f;
                    this.createdDecals[this.decalIndex].transform.position = this.posDecal;
                    this.createdDecals[this.decalIndex].transform.rotation = this.rotDecal;
                    this.createdDecals[this.decalIndex].transform.parent = null;
                    this.createdDecals[this.decalIndex].GetComponent<Renderer>().enabled = true;
                    if (this.hit.collider.tag == "Puerta" || this.hit.collider.tag == "Caja")
                        this.createdDecals[this.decalIndex].transform.parent = this.hit.collider.gameObject.transform;
                    this.decalIndex++;
                    ContadorBalas.instance.MunicionQuitar(1);
                    if (this.decalIndex > 9) this.decalIndex = 0;

                    DestroyCajas salud = hit.collider.GetComponent<DestroyCajas>();
                    if (salud != null) salud.Damage(escopetaDamage);
                    if (hit.rigidbody != null) hit.rigidbody.AddForce(-hit.normal * fuerzaHHit);

                    DestroyEnemy saludEnemy = hit.collider.GetComponent<DestroyEnemy>();
                    if (saludEnemy != null) saludEnemy.Damage(escopetaDamage);
                    if (hit.rigidbody != null) hit.rigidbody.AddForce(-hit.normal * fuerzaHHit);


                }
            }


        }
        if (Input.GetButtonDown("Fire2"))
        {
            if ((Time.time - this.tempoUltimoDisparo) > this.tempoDisparo)
            {
                this.rayo = this.camara.ScreenPointToRay(this.centroCamara);
                this.tempoUltimoDisparo = Time.time;
                if (Physics.Raycast(this.rayo, out this.hit, this.distanciaDisparo, decallayermask))
                {
                    soundManager.ChooseAudio(7, 0.5f);
                    this.rotDecal = Quaternion.FromToRotation(Vector3.forward, this.hit.normal);
                    this.posDecal = this.hit.point + this.hit.normal * 0.01f;
                    this.createdDecals2[this.decalIndex].transform.position = this.posDecal;
                    this.createdDecals2[this.decalIndex].transform.rotation = this.rotDecal;
                    this.createdDecals2[this.decalIndex].transform.parent = null;
                    this.createdDecals2[this.decalIndex].GetComponent<Renderer>().enabled = true;
                    if (this.hit.collider.tag == "Puerta" || this.hit.collider.tag == "Caja")
                        this.createdDecals2[this.decalIndex].transform.parent = this.hit.collider.gameObject.transform;
                    this.decalIndex++;
                    ContadorBalas.instance.MunicionQuitar(3);
                    if (this.decalIndex > 9) this.decalIndex = 0;

                    DestroyCajas salud = hit.collider.GetComponent<DestroyCajas>();
                    if (salud != null) salud.Damage(3);
                    if (hit.rigidbody != null) hit.rigidbody.AddForce(-hit.normal * fuerzaHHit);

                    DestroyEnemy saludEnemy = hit.collider.GetComponent<DestroyEnemy>();
                    if (saludEnemy != null) saludEnemy.Damage(3);
                    if (hit.rigidbody != null) hit.rigidbody.AddForce(-hit.normal * fuerzaHHit);

                }
            }

        }
    }
    }