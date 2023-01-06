using JiangH.Interfaces;
using UnityEngine;
using UnityEngine.UI;

class PlayerPanel : MonoBehaviour
{
    public Text roleName;

    public IPerson player { get; set; }

    private void FixedUpdate()
    {
        roleName.text = player.name;
    }
}
