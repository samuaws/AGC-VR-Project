using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   //instance men rouhou 
   public  static GameManager instance;
  public  List<GameObject> ListItems=new List<GameObject>();
    void Awake()
    {
        instance = this;
    }
    //Add a Componenet to the list
    public void AddItem(GameObject obj)
    {
      if(ListItems.Count<=6)
      {
      ListItems.Add(obj);
      }
      else
      {
        print("Invetory is Full ..");
      }
      print(ListItems);
    }

    //when he choose one from the list , il sera supp de la liste
    public void DeleteItem(GameObject obj)
    {
      ListItems.Remove(obj);
    }
    
   
   //clear
    // Update is called once per frame
    void Update()
    {
        
    }
}
