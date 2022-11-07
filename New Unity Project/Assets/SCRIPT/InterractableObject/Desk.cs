using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Desk : MonoBehaviour, IInterract
{
    [SerializeField] QueueManager qm;

    public TextMeshProUGUI _text;

    public int money = 0;


    private void Start()
    {
        UpdateMoneyUI();
    }

    public void Interract()
    {
        if(qm.clientOnSpots.Count > 0) //making sure there is a client
        {
            Debug.Log("I interract with client");
            ClientsMovement cm = qm.clientOnSpots[0].GetComponentInChildren<ClientsMovement>();
            List<Collider> hitColliders = Physics.OverlapSphere(transform.position, 2).ToList();
            Collider player = hitColliders.Find(c => c.CompareTag("Player"));

            if (player)
            {
                PlayerGrabbr playr = player.transform.root.GetComponentInChildren<PlayerGrabbr>();
                if(playr.GetGrabbedItem() != null)
                {
                    if (!cm.GetItemWanted() && playr.GetGrabbedItem().CompareTag("PolishedArmorFull")){
                        playr.RemoveGrabbedItem();
                        cm.SetClientHappy();
                        Debug.Log("You gave me what i want, nice");
                        money += 100;
                        UpdateMoneyUI();

                    }
                    else if (cm.GetItemWanted() && playr.GetGrabbedItem().CompareTag("SharpenSwordFull"))
                    {
                        playr.RemoveGrabbedItem();
                        cm.SetClientHappy();
                        Debug.Log("You gave me what i want, nice");
                        money += 100;
                        UpdateMoneyUI();
                    }
                    else
                    {
                        Debug.Log("That's not what i want");
                    }
                }
            }
        }
    }

    void UpdateMoneyUI()
    {
        _text.text = money.ToString() + " $";
    }



}
