using JiangH.Interfaces;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

class PlayerSectData : MonoBehaviour
{
    public Button sectButton;
    public Button treasuaryButton;
    public Button personButton;
    public Button regionButton;

    public Text sectName;
    public Text officeName;

    public ISect sect { get; set; }
    public IOffice office { get; set; }

    public void FixedUpdate()
    {
        sectName.text = sect == null ? "--" : sect.name;
        officeName.text = office == null ? "--" : office.name;

        treasuaryButton.GetComponentInChildren<Text>().text = sect == null ? "--" : $"{sect.treasury.current}({sect.treasury.surplus})";
        personButton.GetComponentInChildren<Text>().text = sect == null ? "--" : sect.persons.Count().ToString();
        regionButton.GetComponentInChildren<Text>().text = sect == null ? "--" : sect.regions.Count().ToString();
    }
}
