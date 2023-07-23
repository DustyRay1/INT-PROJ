using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Wood : MonoBehaviour
{
    [SerializeField] GameObject lootWood;
    [SerializeField] ParticleSystem woodShredding;
    [SerializeField] int woodDurability;
    [SerializeField] Rigidbody RBBush;
    public static Action OnTreeDestruct;
    Rigidbody RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Tool"))
        {
            int Reminder = woodDurability % 5;
            woodDurability--;
            if (Reminder == 0)
            {
                Instantiate(woodShredding, woodShredding.transform.position, woodShredding.transform.rotation);
                Instantiate(lootWood, transform.position, transform.rotation);
            }

            if (woodDurability < 1)
            {
                RBBush.isKinematic = false;
                gameObject.transform.DetachChildren();
                Instantiate(lootWood, transform.position, transform.rotation);
                OnTreeDestruct?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
