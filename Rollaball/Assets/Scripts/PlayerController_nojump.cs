using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class PlayerController_nojump : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public int item_count;
    private float movementX;
    private float movementY;
    private Rigidbody rb;
    private int count;

    private int total_score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;
        SetCountText();
        //�v���O���}�[�����삵���֐�
        winTextObject.SetActive(false);

        total_score = PlayerPrefs.GetInt("TOTAL SCORE", 0);
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movementX = v.x;
        movementY = v.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            //other.gameObject.SetActive(false);
            other.gameObject.GetComponent<Renderer>().enabled = false;

            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        //�����O�𕶎���O�ɕύX
        if (count >= 12)
        {
            winTextObject.SetActive(true);

            // ���݂̃V�[���ԍ����擾
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;

            StartCoroutine(DelayMethod(5, () =>
            {
                total_score += count;
                PlayerPrefs.SetInt("TOTAL SCORE", total_score);
                PlayerPrefs.Save();
                // ���̃V�[�����ēǍ�����
                SceneManager.LoadScene(sceneIndex + 1);
            }));
        }
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}