using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBump : MonoBehaviour
{
    private AudioSource audioSource;
    //unity���ƂȂ���K�v�͖������߁Aprivate�C���q

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        //audiosorce���特��炷
    }

    void Update()
    {

    }

    // �R���C�_�[�Ƃ̐ڐG���ɌĂ΂��R�[���o�b�N
    void OnCollisionEnter(Collision hit)
        //oncollisionenter�ŏՓ˔���
        //�Փ˂����Ƃ��ɉ��ƏՓ˂�������hit����

    {
        // �ڐG�Ώۂ�Player�^�O�ł����H
        if (hit.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            Debug.Log("bbb");
        }
    }
}