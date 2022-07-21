using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Pickable : MonoBehaviour
{  
     private  Rigidbody rb;
     private void Awake()
     {
         rb = gameObject.GetComponent<Rigidbody>();
        Material[] mats = new Material[this.GetComponent<MeshRenderer>().materials.Length + 1];
        for (int i = 1; i < mats.Length ; i++)
        {
            mats[i] = this.GetComponent<MeshRenderer>().materials[i - 1];
        }
        mats[0] = this.GetComponent<MeshRenderer>().materials[0];
        this.GetComponent<MeshRenderer>().materials = mats;
    }

     private IEnumerator Move(Transform place)
     {
         while (Vector3.Distance(transform.position,place.position)>0.2f && rb.isKinematic)
         {
             transform.position = Vector3.Lerp(transform.position, place.position, UnityEngine.Time.deltaTime * 2f);
             yield return null;
         }
         
     }
     public void OnPick(Transform place)
     {
        print("PIcking");
        rb.isKinematic = true;
        GameManager.instance.AddItem(rb.gameObject);
        transform.SetParent(place);
        StartCoroutine(this.Move(place));
        GetComponent<Collider>().enabled = false;
    }
    public void OnUse()
    {
    }
    public void OnDrop()
    {
        GetComponent<MeshRenderer>().material.SetFloat("mult", 0f);
        rb.isKinematic  = false;
        transform.SetParent(null);
        GetComponent<Collider>().enabled = true;
    }
}