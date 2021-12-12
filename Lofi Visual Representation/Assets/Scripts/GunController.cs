using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public PlayerController fpsGun;
    public LineRenderer bulletTrail;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }
    }

    void Shoot(){
        Debug.Log("Enter shoot");
        RaycastHit hit;
        if(Physics.Raycast(fpsGun.transform.position, fpsGun.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null){
                Debug.Log("if");
                target.TakeDamage(damage);
            }

            SpawnVoidTrail(hit.point);
        }
    }

    private void SpawnVoidTrail(Vector3 hitpoint){
        GameObject bulletTraillEffect = Instantiate(bulletTrail.gameObject, fpsGun.transform.position, Quaternion.identity);
        LineRenderer lineR = bulletTraillEffect.GetComponent<LineRenderer>();

        lineR.SetPosition(0, fpsGun.transform.position);
        lineR.SetPosition(1, hitpoint);

        Destroy(bulletTraillEffect, 0.2f);
    }
}
