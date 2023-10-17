using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    public static bool gameOver;
    //public float life = 1;

    [SerializeField] Animator myAnima;

    void Start()
    {
        gameOver = false;
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (gameOver)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        if (PlayerController.Instance.life <= 0)
        {
            Debug.Log("life in if life==0:" + PlayerController.Instance.life);
            PlayerManager.gameOver = true;
        }

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Life")
        {
            if (PlayerController.Instance.life == 1)  //only increasing life if life is equals to 1
            {
                PlayerController.Instance.life += 1;
                //Debug.Log("life:(Should be 2)" + life);
                FindObjectOfType<AudioManager>().PlaySound("PowerUp");

            }
            Destroy(hit.gameObject);
        }

        if (hit.transform.tag == "Superfood")
        {
            Debug.Log("Superfood called");
            FindObjectOfType<AudioManager>().PlaySound("PowerUp");
            Destroy(hit.gameObject);
            StartCoroutine("SuperFood");
        }

        if (hit.transform.tag == "Shield")
        {
            FindObjectOfType<AudioManager>().PlaySound("PowerUp");
            StartCoroutine("Shield");
            Destroy(hit.gameObject);
        }
    }


    private void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            PlayerController.Instance.life -= 1;
            StopCoroutine("Shield");
            //Debug.Log("life -1 ke baad:" + life);
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }


        if (hit.transform.tag == "LeftRoad")
        {
            //PlayerController.Instance.targetPosition = new Vector3(transform.position.x - 3, transform.position.y, transform.position.z);
            //transform.position = new Vector3(transform.position.x - 3, transform.position.y, transform.position.z);
            //transform.position=Vector3.left * 3;

            Debug.Log("Go left");
            myAnima.SetBool("Left", true);
            //PlayerController.Instance.targetPosition = PlayerController.Instance.targetPosition += Vector3.left * 3 * PlayerController.Instance.laneDistance;
        }
        if (hit.transform.tag == "RightRoad")
        {

            Debug.Log("Go Right");
            myAnima.SetBool("Left", false);
        }
        //if (hit.transform.tag == "jump")
        //{
        //    PlayerController.Instance.Jump();
        //}
    }

    IEnumerator Shield()
    {
        PlayerController.Instance.life++;
        Debug.Log("start");
        yield return new WaitForSeconds(30f);
        Debug.Log("end");
        PlayerController.Instance.life--;
    }


    IEnumerator SuperFood()
    {

        Physics.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(10);
        Physics.IgnoreLayerCollision(6, 7, false);
    }

    // Detecting Collision with burner flames 
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("true");
        PlayerController.Instance.life--;
    }
}
