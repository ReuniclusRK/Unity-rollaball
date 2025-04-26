using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBump : MonoBehaviour
{
    private AudioSource audioSource;
    //unity側とつなげる必要は無いため、private修飾子

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        //audiosorceから音を鳴らす
    }

    void Update()
    {

    }

    // コライダーとの接触時に呼ばれるコールバック
    void OnCollisionEnter(Collision hit)
        //oncollisionenterで衝突判定
        //衝突したときに何と衝突したかをhit判定

    {
        // 接触対象はPlayerタグですか？
        if (hit.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            Debug.Log("bbb");
        }
    }
}