using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject item;
    public float speedRotation;
    public float minTime;
    public float maxTime;
    private GameObject clone_item; 

    // Start is called before the first frame update
    void Start()
    {   waiter();
        startSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
       if(clone_item) {
           
           clone_item.transform.Rotate(Vector3.up, speedRotation * Time.deltaTime); 
       }      
             

            
    }

    public void startSpawn(){
        
        StartCoroutine("spawnItem");
    }
    IEnumerator waiter(){
        yield return new WaitForSeconds(3);

    }

    IEnumerator spawnItem()
    {
        clone_item = Instantiate(item) as GameObject;
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        Destroy(clone_item);
        StartCoroutine("spawnItem");  
    }
}
