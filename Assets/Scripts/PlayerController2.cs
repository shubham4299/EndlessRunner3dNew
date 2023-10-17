using System;
using System.Collections;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 originalScale;
    private Vector3 originalCenter;
    private float originalHeight;
    private float shrinkTime = 2f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        originalScale = transform.localScale;
        originalHeight = controller.height;
        originalCenter = controller.center;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(LeftShrink(Vector3.left));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(RightShrink(Vector3.right));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(Shrink());
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(Stretch());
        }
    }

    IEnumerator LeftShrink(Vector3 left)
    {
        throw new NotImplementedException();
    }

    IEnumerator RightShrink(Vector3 right)
    {
        throw new NotImplementedException();
    }

    IEnumerator Shrink()
    {
        transform.localScale = originalScale / 2;
        controller.height = originalHeight / 2;
        controller.center = originalCenter / 2;
        yield return new WaitForSeconds(shrinkTime);
        transform.localScale = originalScale;
        controller.height = originalHeight;
        controller.center = originalCenter;
    }

    IEnumerator Stretch()
    {
        transform.localScale = originalScale * 2;
        controller.height = originalHeight * 2;
        controller.center = originalCenter * 2;
        yield return new WaitForSeconds(shrinkTime);
        transform.localScale = originalScale;
        controller.height = originalHeight;
        controller.center = originalCenter;
    }
}