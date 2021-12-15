using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class GunController : MonoBehaviour
{
    //Inisitaling variables
    public float damage = 10f;
    public float range = 50f;
    public PlayerController fpsGun;
    public LineRenderer bulletTrail;
    public AudioSource audio;

    // Update is called once per frame
    void Update()
    {   
        //Playing shoot sound effect and calling shoot function
        if (Input.GetKeyDown(KeyCode.Space)){
            audio.Play();
            Shoot();
        }
    }

    //Shoot Function
    void Shoot(){
        //Declaring Raycast
        RaycastHit hit;

        //Sending a raycast in the direction of spaceship at a certain range
        if(Physics.Raycast(fpsGun.transform.position, fpsGun.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);

            //Setting the target as the hit component
            Target target = hit.transform.GetComponent<Target>();

            //If we have hit a target take damage
            if(target != null){
                target.TakeDamage(damage);
            }

            //Spawning Trail
            SpawnVoidTrail(hit.point);
        }
    }

    private void SpawnVoidTrail(Vector3 hitpoint){
        //Spawn bullet trail from the gun
        GameObject bulletTraillEffect = Instantiate(bulletTrail.gameObject, fpsGun.transform.position, Quaternion.identity);
        
        //Using LineRenderer to visually see bullet trail
        LineRenderer lineR = bulletTraillEffect.GetComponent<LineRenderer>();

        //set the linerenderer from the spadeshit to the target(hitpoint)
        lineR.SetPosition(0, fpsGun.transform.position);
        lineR.SetPosition(1, hitpoint);

        //destroy line after .2 seconds
        Destroy(bulletTraillEffect, 0.2f);
    }
}
