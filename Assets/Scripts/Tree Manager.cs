using System.Collections;
using UnityEngine;
public class TreeManager : MonoBehaviour
{
    [SerializeField] GameObject Tree;
    private void OnEnable()
    {
        Wood.OnTreeDestruct +=  RespTree;
    }
    private void OnDisable() 
    {
        Wood.OnTreeDestruct -=  RespTree;
    }
    private void RespTree()
    {
        StartCoroutine(RespawnTree());
    }
    IEnumerator RespawnTree()
    {
        yield return new WaitForSeconds(15);
        Instantiate(Tree,transform.position,transform.rotation);
    }
}
