using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField]
    private GameObject poolingObjectPrefab;

    Queue<BulletMover> poolingObjectQueue = new Queue<BulletMover>();

    private void Awake()
    {
        Instance = this;

        Initialize(10);
     
    }

    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i ++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    private BulletMover CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<BulletMover>();
        newObj.gameObject.SetActive(false);
       newObj.transform.SetParent(transform);

        return newObj;
    }

    public static BulletMover GetObject(Vector2 pos, int damage)
    {
        if (Instance.poolingObjectQueue.Count > 0)
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            obj.gameObject.transform.position = pos;
            obj.gameObject.GetComponent<BulletMover>().damage = damage;
            return obj;
        }

        else
        {
            var newObj = Instance.CreateNewObject();
           newObj.gameObject.SetActive(true);
           newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnObject(BulletMover obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
        obj.gameObject.transform.position = new Vector2(100, 0);

    }

    private void Update()
    {
       // Debug.Log(Instance.poolingObjectQueue.Count);
    }
}
