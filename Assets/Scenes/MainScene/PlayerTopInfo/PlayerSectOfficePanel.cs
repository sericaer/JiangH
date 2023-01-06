using JiangH.Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSectOfficePanel : MonoBehaviour
{
    public Text sectName;

    public ISect sect { get; set; }

    private void FixedUpdate()
    {
        sectName.text = sect.name;
    }
}