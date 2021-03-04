using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{

    public void SetHealthText(string text)
    {
        GetComponent<Text>().text = text;
    }
}
