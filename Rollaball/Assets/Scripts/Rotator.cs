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
        //Rotate一個でx,y,z全ての動きに対応できる
    }

    private AudioSource audioSource;

    void OnTriggerEnter(Collider hit)
    {

        // 接触対象はPlayerタグですか？
        if (hit.gameObject.CompareTag("Player"))
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.Play();
            Debug.Log("aaa");
        }
    }

}