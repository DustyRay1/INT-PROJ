using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Loot : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Text;
    static int WoodCollected;

    private void Start() 
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward*200);
        Text = GameObject.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            WoodCollected++;
            Text.text = "Wood Collected:" + WoodCollected;
            Destroy(gameObject);
        }
    }
}
