using JiangH.Interfaces;
using UnityEngine;
using UnityEngine.UI;

class SectPanel : MonoBehaviour
{
    public Text text;
    public ISect gmData { get; set; }

    public void Update()
    {
        if (gmData == null)
        {
            text.gameObject.SetActive(false);
            return;
        }

        text.gameObject.SetActive(true);
        text.text = gmData.name;
    }
}