using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraController : MonoBehaviour

{
    public GameObject player;
    private Vector3 offset;
    //ofset‚Ì’†‚Éx,y,z‚ª“ü‚Á‚Ä‚¢‚é

    void Start()
    {
        offset = transform.position - player.transform.position;
        //=‚Íˆê‚Â‚¾‚ªAx,y,z‚ª“Z‚ß‚Ä“ü‚Á‚Ä‚¢‚é‚Ì‚Å3‚Âˆê‹C‚ÉŒvZ‚Å‚«‚é
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

    }
}