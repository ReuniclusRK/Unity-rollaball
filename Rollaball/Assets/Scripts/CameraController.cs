using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraController : MonoBehaviour

{
    public GameObject player;
    private Vector3 offset;
    //ofsetの中にx,y,zが入っている

    void Start()
    {
        offset = transform.position - player.transform.position;
        //=は一つだが、x,y,zが纏めて入っているので3つ一気に計算できる
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

    }
}