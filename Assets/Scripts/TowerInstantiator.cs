using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInstantiator : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int towersLimit = 5;

    Queue<Tower> towers = new Queue<Tower>();

    bool HasIt(Vector3 position)
    {
        foreach (var item in towers)
        {
            if (item.transform.position == position)
                return true;
        }
        return false;
    }
    public void InstantiateTower(Vector3 position)
    {
        if (towerPrefab)
        {
            if (HasIt(position))
            {
                print("Has it");
                return;
            }
            Tower tower = Instantiate(towerPrefab, position, Quaternion.identity);
            tower.transform.parent = transform;
            towers.Enqueue(tower);
            if (towers.Count > towersLimit)
            {
                print("dequ");
                Tower dequedTower = towers.Dequeue();
                Destroy(dequedTower.gameObject);
            }
            print("Enqued");
        }
    }

}
