using JiangH.Interfaces;
using UnityEngine;
using UnityEngine.UI;

class SectPanel : MonoBehaviour
{
    public Text text;
    public IRegion.SectInfo gmData { get; set; }

    public void Update()
    {
        if (gmData == null || !gmData.isSectLocation)
        {
            text.gameObject.SetActive(false);
            return;
        }

        text.gameObject.SetActive(true);
        text.text = gmData.sect.name;
    }
}