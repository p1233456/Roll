using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<Map> maps;
    Queue<GameObject> mapObjectsQue;
    [SerializeField]
    private int maxQueSize;
    private float madeMapDistance;


    private void Start()
    {
        mapObjectsQue = new Queue<GameObject>();
        madeMapDistance = 0;
        InstaniateMap(maps[0]);
    }

    private void Update()
    {
        LevelUpdate();   
    }

    public void LevelUpdate()
    {
        if (mapObjectsQue.Count < maxQueSize)
        {
            InstaniateMap(maps[Random.Range(0, maps.Count)]);
        }
    }

    public void RemovePassMap()
    {
        RemoveMap(mapObjectsQue.Dequeue());
    }
   
    private void InstaniateMap(Map map)
    {
        GameObject instantiedMap = Instantiate(map.MapObject);
        instantiedMap.transform.position = new Vector3(0, -1, madeMapDistance + map.StartPosition.z * -1);
        madeMapDistance += map.MapSize;
        mapObjectsQue.Enqueue(instantiedMap);
    }

    private void RemoveMap(GameObject mapObject)
    {
        Destroy(mapObject, 1f);
    }
}
