using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraController : MonoBehaviour

{
    public GameObject player;
    private Vector3 offset;
    //ofset�̒���x,y,z�������Ă���

    void Start()
    {
        offset = transform.position - player.transform.position;
        //=�͈�����Ax,y,z���Z�߂ē����Ă���̂�3��C�Ɍv�Z�ł���
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

    }
}