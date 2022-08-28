using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinControl : MonoBehaviour
{
    public float rotateSpeed;
    public AudioSource playSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,-rotateSpeed,0, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.CompareTag("Player"))
            {
                playSound.Play();
            }
             if (collision.gameObject.CompareTag("Player"))
            {
               
                Destroy(gameObject);
            }
    }
}
