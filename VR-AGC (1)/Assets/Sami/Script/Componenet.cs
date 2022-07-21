using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum compType
{
    rigidbody,
    collider
}
public class Componenet : MonoBehaviour
{
    public compType type;
    private Addable obj;

    private void OnTriggerEnter(Collider other)
    {
        obj = other.gameObject.GetComponent<Addable>();
        if (obj)
        {

            switch (type)
            {
                case compType.collider:
                    if (obj.coll)
                    {
                        obj.gameObject.AddComponent<BoxCollider>();
                        Destroy(this.gameObject);
                    }
                    break;
                case compType.rigidbody:
                    if (obj.rigid)
                    {
                        obj.gameObject.AddComponent<Rigidbody>();
                        Destroy(this.gameObject);
                    }
                    break;
            }

        }
    }
}
