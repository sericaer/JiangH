using JiangH.Interfaces;
using JiangH.Messages;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

class SectDetail : MonoBehaviour
{
    public ISect gmData { get; set; }

    public Text sectName;

    public UnityEvent<IPerson> recruitMemember;

    public SelectPersonPanel willRecruitPersonPanel;

    public void Start()
    {
        willRecruitPersonPanel.gmData = gmData.willJoininPersons;
        willRecruitPersonPanel.selectPersonEvent.AddListener((person) =>
        {
            var message = new MESSAGE_PERSON_JOININ_SECT();
            message.person = person;
            message.sect = gmData;

            MainScene.SendMessage(message);
        });
    }

    public void FixedUpdate()
    {
        sectName.text = gmData.name;
    }
}
