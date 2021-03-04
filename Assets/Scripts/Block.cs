using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Block previousBlock;
    public bool isBlocked = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    public Vector2Int GetPos()
    {
        Vector2Int pos = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));
        return pos;
    }
    public void SetTopColor(Color color)
    {
        MeshRenderer mesh = transform.Find("Top").GetComponent<MeshRenderer>();
        mesh.material.color = color;
    }
    public Block GetPreviousBlock()
    {
        return previousBlock;
    }
    public void SetPreviousBlock(Block block)
    {
        previousBlock = block;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isBlocked)
            {
                print("Can place");
                FindObjectOfType<TowerInstantiator>().InstantiateTower(transform.position);
            }
            else
                print("Can't place");
        }
    }
    void Update()
    {

    }
}
