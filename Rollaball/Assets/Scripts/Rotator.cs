using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        //Rotate���x,y,z�S�Ă̓����ɑΉ��ł���
    }

    private AudioSource audioSource;

    void OnTriggerEnter(Collider hit)
    {

        // �ڐG�Ώۂ�Player�^�O�ł����H
        if (hit.gameObject.CompareTag("Player"))
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.Play();
            Debug.Log("aaa");
        }
    }

}