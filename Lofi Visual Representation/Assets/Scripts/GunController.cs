using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Transform BulletSpawnPoint;
    private TrailRenderer BulletTrail;
    

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
        Debug.Log("shoot entered");

        Vector3 direction = GetDirection();

        if(Physics.Raycast(BulletSpawnPoint.position, direction, out RaycastHit hit, range)){
            Debug.Log("if entered");
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            TrailRenderer trail = Instantiate(BulletTrail, BulletSpawnPoint.position, Quaternion.identity);
            StartCoroutine(SpawnTrailer(trail, hit));
            if(target != null){
                target.TakeDamage(damage);
            }
        }else {
            Debug.Log("else");
        }
    }

    private Vector3 GetDirection(){
        Vector3 direction = transform.forward;

        return direction;
    }

    private IEnumerator SpawnTrailer(TrailRenderer trail, RaycastHit hit){
        float time = 0;
        Vector3 startPosition = trail.transform.position;

        while(time > 1){
            trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
            time += Time.deltaTime / trail.time;
            yield return null;
        }
        trail.transform.position = hit.point;

        Destroy(trail.gameObject, trail.time);
    }
}
