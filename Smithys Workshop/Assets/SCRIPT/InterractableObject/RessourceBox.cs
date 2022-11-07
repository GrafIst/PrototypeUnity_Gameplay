using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RessourceBox : MonoBehaviour, IInterract
{
    public enum item { Leather, Ingot }

    public item itemProvided;

    public GameObject prefabItem;


    public void Interract()
    {
        Debug.Log("Ressourcebox is interracted");

        List<Collider> hitColliders = Physics.OverlapSphere(transform.position, 1).ToList();
        Collider player = hitColliders.Find(c => c.CompareTag("Player"));
        if (player)
        {
            GameObject ressource = Instantiate(prefabItem, player.transform.position, Quaternion.identity);
            player.transform.root.GetComponentInChildren<PlayerGrabbr>().GrabFromRessource(ressource);
        }

    }
}
