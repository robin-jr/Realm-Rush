using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Block start, end;
    List<Block> path = new List<Block>();
    Block[] blocks;
    // Start is called before the first frame update
    Dictionary<Vector2Int, Block> grid = new Dictionary<Vector2Int, Block>();
    void Start()
    {
        blocks = GetComponentsInChildren<Block>();
        foreach (Block block in blocks)
        {
            try { grid.Add(block.GetPos(), block); }
            catch (System.Exception) { }
        }
        print(grid.Count);
        // start.SetTopColor(Color.blue);
        // end.SetTopColor(Color.red);
        if (path.Count == 0)
            FindPath();
        // GetNeighbours(start);
    }
    List<Block> GetNeighbours(Block block)
    {
        List<Block> neighbors = new List<Block>();
        List<Vector2Int> directions = new List<Vector2Int> { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
        foreach (Vector2Int direction in directions)
        {
            try { neighbors.Add(grid[block.GetPos() + direction * 10]); }
            catch (System.Exception) { }
        }
        // foreach (Block neighbor in neighbors)
        // {
        //     neighbor.SetTopColor(Color.black);
        // }
        // print(neighbors.Count);
        return neighbors;
    }

    void FindPath()
    {
        Queue<Block> que = new Queue<Block>();
        que.Enqueue(start);
        List<Block> covered = new List<Block>();

        while (que.Count > 0)
        {
            Block temp = que.Dequeue();
            covered.Add(temp);
            if (temp == end)
            {
                print("Found Path");
                TracePath();
                return;
            }
            else
            {
                foreach (Block neighbor in GetNeighbours(temp))
                {
                    if (!covered.Contains(neighbor) && !que.Contains(neighbor))
                    {
                        neighbor.SetPreviousBlock(temp);
                        que.Enqueue(neighbor);
                    }
                }
            }
        }
        path.Add(start);
        print("Couldn't find path");
        BlockPath();
        return;

    }
    void TracePath()
    {
        List<Block> trace = new List<Block>();
        Block temp = end;
        while (temp)
        {
            trace.Add(temp);
            temp = temp.GetPreviousBlock();
        }
        foreach (Block block in trace)
        {
            path.Add(block);
            block.SetTopColor(Color.white);
        }
        start.SetTopColor(Color.blue);
        end.SetTopColor(Color.red);
        trace.Reverse();
        path = trace;
        BlockPath();
    }
    void BlockPath()
    {
        foreach (var item in path)
        {
            item.isBlocked = true;
        }
    }
    public List<Block> GetPath()
    {
        return path;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
