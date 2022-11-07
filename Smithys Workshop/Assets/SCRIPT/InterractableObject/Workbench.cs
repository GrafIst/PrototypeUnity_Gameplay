using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Workbench : MonoBehaviour, IInterract
{
    public List<GameObject> craftItem;

    public List<GameObject> visibleSlotItem;

    public List<Transform> craftSlots;

    public GameObject armorPlate;
    public GameObject fullBlade;
    public GameObject fullArmor;

    public void Interract()
    {
        Debug.Log("Workbench is interracted");
        List<Collider> hitColliders = Physics.OverlapSphere(transform.position, 2).ToList();
        Collider player = hitColliders.Find(c => c.CompareTag("Player"));

        if (player)
        {
            PlayerGrabbr playr = player.transform.root.GetComponentInChildren<PlayerGrabbr>();

            //first we verify if anything is craftable
            if(craftItem.Count == 1)
                if (craftItem[0].CompareTag("HeatedIngot"))
                {
                    Instantiate(armorPlate, player.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                    Destroy(craftItem[0]);
                    craftItem.Clear();
                }
            if (craftItem.Count == 2)
                if (craftItem[0].CompareTag("ProcessedSwordBlade") 
                    && craftItem[1].CompareTag("Ingot") 
                    || craftItem[0].CompareTag("Ingot")
                    && craftItem[1].CompareTag("ProcessedSwordBlade"))
                {
                    //Get full blade
                    Instantiate(fullBlade, player.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                    Destroy(craftItem[0]);
                    Destroy(craftItem[1]);

                    craftItem.Clear();
                }
            if (craftItem.Count == 3)
                if(craftItem[0].CompareTag("ProcessedArmorPlate") && craftItem[1].CompareTag("ProcessedArmorPlate") && craftItem[2].CompareTag("Leather")
                    || craftItem[0].CompareTag("ProcessedArmorPlate") && craftItem[1].CompareTag("Leather") && craftItem[2].CompareTag("ProcessedArmorPlate")
                    || craftItem[0].CompareTag("Leather") && craftItem[1].CompareTag("ProcessedArmorPlate") && craftItem[2].CompareTag("ProcessedArmorPlate"))
                {
                    //Get full armor
                    Instantiate(fullArmor, player.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                    Destroy(craftItem[0]);
                    Destroy(craftItem[1]);
                    Destroy(craftItem[2]);
                    
                    craftItem.Clear();
                }


            //then we add item in the inventory
            if (craftItem.Count <= 2)
            {
                if (playr.GetGrabbedItem() != null)
                {
                    GameObject copy = Instantiate(playr.GetGrabbedItem(), craftSlots[craftItem.Count].position, Quaternion.identity);
                    craftItem.Add(copy);
                    playr.RemoveGrabbedItem();  
                }
                else //quicker reset, interraction, no object, no craft possible
                {
                    foreach (var item in craftItem)
                    {
                        item.transform.position = player.transform.position + new Vector3(0, 1, 0);
                    }
                    craftItem.Clear();
                }
            }
            else //the user f*cked up the recipe
            {
                foreach(var item in craftItem)
                {
                    
                    item.transform.position = player.transform.position + new Vector3(0, 1, 0);
                }
                craftItem.Clear();
            }

        }
    }
}
