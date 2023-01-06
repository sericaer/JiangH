using JiangH.Interfaces;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

class RegionDetail : MonoBehaviour
{
    public IRegion gmData { get; set; }

    public Text regionName;
    public Text treausryPdt;

    public PatrolerPanel defaultPatroler;

    public UnityEvent<IPerson> addPatroler;
    public UnityEvent<IPerson> removePatroler;

    public Button addPatrolerButton;
    public Button removePatrolerButton;

    public SelectPersonPanel pefabSelectPersonPanel;

    void Start()
    {
        defaultPatroler.gameObject.SetActive(false);

        addPatrolerButton.onClick.AddListener(() =>
        {
            var table = Instantiate(pefabSelectPersonPanel, MainScene.UIRoot);
            table.SetVaildColums("name");
            table.gmData = gmData.sect.persons.Where(x => x.patrolRegion == null);

            table.selectPersonsEvent.AddListener((persons) =>
            {
                foreach(var person in persons)
                {
                    addPatroler.Invoke(person);
                }
            });
        });

        removePatrolerButton.onClick.AddListener(() =>
        {
            var table = Instantiate(pefabSelectPersonPanel, MainScene.UIRoot);
            table.SetVaildColums("name");
            table.gmData = gmData.patrolers;

            table.selectPersonsEvent.AddListener((persons) =>
            {
                foreach (var person in persons)
                {
                    removePatroler.Invoke(person);
                }
            });
        });
    }

    void FixedUpdate()
    {
        regionName.text = gmData.name;
        treausryPdt.text = gmData.productor.value.ToString();

        var container = defaultPatroler.transform.parent;

        foreach (var patrolerPanel in container.GetComponentsInChildren<PatrolerPanel>())
        {
            if(gmData.patrolers.All(x=> x != patrolerPanel.gmData))
            {
                Destroy(patrolerPanel.gameObject);
            }
        }

        foreach (var patroler in gmData.patrolers)
        {
            if(container.GetComponentsInChildren<PatrolerPanel>().All(x=>x.gmData != patroler))
            {
                var item = Instantiate(defaultPatroler, container);
                item.gmData = patroler;
                item.gameObject.SetActive(true);
            }
        }
    }
}
