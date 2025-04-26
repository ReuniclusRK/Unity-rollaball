using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class PlayerController : MonoBehaviour
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

    //Jump系の処理
    public float jump_power = 5.0f;
    private bool isJump = false;

    private bool isCooldown = true;
    //jump処理

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;
        SetCountText();
        winTextObject.SetActive(false);

        total_score = PlayerPrefs.GetInt("TOTAL SCORE", 0);
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movementX = v.x;
        movementY = v.y;
    }    

    void OnJump()
    {
        if (isCooldown)
        {
            isJump = true;

            isCooldown = false; // Jump入力無効

            StartCoroutine(DelayMethod(0.5f, () =>
            {
                // 0.5秒後にJump入力有効に復帰
                isCooldown = true;
            }));

        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        if (isJump)
        {
            // ボールに力をImpulseモードで＋Y軸方向に一瞬加える

            // ボールのローカル座標系Y軸＋方向に力を加える場合のコード
            // ※ボール自身のY軸は移動により回転することに注意
            //rb.AddForce(transform.up * jump_power, ForceMode.Impulse);

            //ワールド座標系Y軸＋方向に力を加える場合のコード
            rb.AddForce(Vector3.up * jump_power, ForceMode.Impulse);
            isJump = false;
            //連続ジャンプしないように設定
        }
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