using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class BlockEditor : MonoBehaviour
{
    TextMesh text;
    void Start()
    {
        text = GetComponentInChildren<TextMesh>();
    }

    void Update()
    {
        float xPos = Mathf.RoundToInt(transform.position.x / 10f) * 10f;
        float zPos = Mathf.RoundToInt(transform.position.z / 10f) * 10f;
        Vector3 snapPos = new Vector3(xPos, 0f, zPos);
        transform.position = snapPos;
        string label = (snapPos.x / 10).ToString() + "," + (snapPos.z / 10).ToString();
        if (text)
            text.text = label;
        gameObject.name = label;
    }
}
