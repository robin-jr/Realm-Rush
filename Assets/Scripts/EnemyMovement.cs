using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float dwellTime = 1f;
    PathFinder pathFinder;
    [SerializeField] List<Block> blocks;
    void Start()
    {
        pathFinder = FindObjectOfType<PathFinder>();
        if (pathFinder)
            Invoke("Move", 1f);
    }
    void Move()
    {
        blocks = pathFinder.GetPath();
        StartCoroutine(FollowPath());

    }
    IEnumerator FollowPath()
    {
        foreach (Block block in blocks)
        {
            transform.position = block.transform.position;
            yield return new WaitForSeconds(dwellTime);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
