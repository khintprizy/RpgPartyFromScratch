using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipManager : MonoBehaviour
{
    public void ShowToolTip(Item toolTipItem, Vector3 pos, GameObject panel, Text text, string textContent)
    {
        text.text = textContent;
        panel.transform.position = pos;
        panel.SetActive(true);
    }
    public void HideToolTip(GameObject panel)
    {
        panel.SetActive(false);
    }
}
