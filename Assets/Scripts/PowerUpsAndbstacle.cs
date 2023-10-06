using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsAndbstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            PlayerController.Instance.life -= 1;
            StopCoroutine("Shield");
            //Debug.Log("life -1 ke baad:" + life);
            FindObjectOfType<AudioManager>().PlaySound("GameOver");



            /* if (life == 0)
             {
                 //Debug.Log("life in if life==0:" + life);
                 PlayerManager.gameOver = true;
                 FindObjectOfType<AudioManager>().PlaySound("GameOver");
             }*/
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
