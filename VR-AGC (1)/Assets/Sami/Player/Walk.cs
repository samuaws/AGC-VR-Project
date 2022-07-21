using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    Vector2 walkInput;
    [SerializeField][Range(0, 1)] float speed;
  public void RecieveInput(Vector2 _walkInput)
    {
        walkInput = _walkInput;
        
    }
    private void FixedUpdate()
    {
        this.transform.Translate(new Vector3(walkInput.x, 0, walkInput.y)*speed);
    }
}
