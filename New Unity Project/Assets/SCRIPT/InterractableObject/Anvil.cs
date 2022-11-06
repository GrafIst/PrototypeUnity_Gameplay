using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Oven;

public class Anvil : MonoBehaviour, IInterract
{

    public void Interract()
    {
        Debug.Log("Anvil is interracted");
        List<Collider> hitColliders = Physics.OverlapSphere(transform.position, 2).ToList();
        Collider player = hitColliders.Find(c => c.CompareTag("Player"));

        if (player)
        {
            PlayerGrabbr playr = player.transform.root.GetComponentInChildren<PlayerGrabbr>();
            if (playr.GetGrabbedItem() != null)
            {
                if (playr.GetGrabbedItem().GetComponent<IHammer>() != null)
                {
                    playr.RemoveGrabbedItem();
                    GameObject item = playr.GetGrabbedItem().GetComponent<IHammer>().Hammered();
                    Instantiate(item, player.transform.position + new Vector3(0,1,0), Quaternion.identity);
                }
            }
            
        }

    }


}
