using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] GameObject Item_1;
    [SerializeField] GameObject Item_2;


    private void Awake()
    {
        Item_1.gameObject.SetActive(false);
        Item_2.gameObject.SetActive(false);
    }
    public void SelItem()
    {
        int RandNumber = Random.Range(0, 100);
        if (RandNumber >= 80)
        {
            Item_1.gameObject.SetActive(true);
        }
        else if (RandNumber >= 60)
        {
            Item_2.gameObject.SetActive(true);
        }

        else
        {
            Item_1.gameObject.SetActive(false);
            Item_2.gameObject.SetActive(false);

        }
    }

}
