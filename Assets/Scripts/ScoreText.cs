using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public void SetScoreText(string text)
    {
        GetComponent<Text>().text = text;
    }
}
