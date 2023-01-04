using JiangH.Interfaces;
using UnityEngine;
using UnityEngine.UI;

class PatrolerPanel : MonoBehaviour
{
    public Text personName;

    public IPerson gmData { get; set; }

    void FixedUpdate()
    {
        personName.text = gmData.name;
    }
}