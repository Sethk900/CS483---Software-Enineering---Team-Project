using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool{
        public string tag;
        public GameObject prefab;
        public int size;
    }
    #region Singleton

    public static objectPooler Instance;

    private void Awake(){
        Instance = this;
    }

    #endregion

    //ie playerBullets or enemyBullets
    public List<Pool> pools;
    //takes tag and object pool queue
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        
        //add pools to the dictionary
        foreach (Pool pool in pools){
            Queue<GameObject> objectPool = new Queue<GameObject>();

            //instantiate, set inactive and add to pool queue
            for (int i = 0; i< pool.size; i++){
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            //actually add to dictionary
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    //take inactive objects and spawn into world by passing tag to spawn, where to spawn and quaternion for rotation
    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation){
        
        //check to make sure tag is actually in poolDictionary
        if(!poolDictionary.ContainsKey(tag)){
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }

        //take first element from queue and store object as objectToSpawn
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
    
        //configure objectToSpawn 
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        //Get component on spawning object
        IpooledObject pooledObj = objectToSpawn.GetComponent<IpooledObject>();
        if (pooledObj != null){
            //find instantiation of OnObjectSpawn() and call it
            pooledObj.OnObjectSpawn();
        }

        //add to end of queue for reuse
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

}
