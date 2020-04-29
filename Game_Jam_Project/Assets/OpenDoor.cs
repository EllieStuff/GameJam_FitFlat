using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update
    bool lerp = false;
    bool open = true;
    float rotation = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lerp)
        {
            if(open)
            {
                transform.Rotate(Vector3.up * 90);
            }
            else if(!open)
            {
                transform.Rotate(Vector3.up * -90);
            }
            open = !open;
            lerp = false;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            lerp = true;
        }
    }

    IEnumerator Open()
    {
        yield return null;
    }
}
