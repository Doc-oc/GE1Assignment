using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject[] targetPrefab;
    private List<GameObject> targetRoad = new List<GameObject>();
    public float health = 50f;

    public Transform playerTransform;

    void Start()
    {
        for(int i=0; i<numOfRoads; i++){
            SpawnTarget(Random.Range(0, targetPrefab.Length));
        }
  
    }
    void Update()
    {
        if(playerTransform.position.z > gameObject.transform.position.z){
            SpawnTarget(Random.Range(0, targetPrefab.Length));
        }
    }

    public void TakeDamage(float amount){
        health -= amount;
        if (health <= 0f){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }

    public void SpawnTarget(int tarIndex){
        GameObject tObj = Instantiate(targetPrefab[tarIndex], transform.forward * zSpawn, transform.rotation);
        targetRoad.Add(tObj);

    }

    private void DeleteRoad(){
        Destroy(targetRoad[0]);
        targetRoad.RemoveAt(0);
    }

}
