using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject BreakBox;
    bool Digging = true;
    float speed = 2;
    int isWalkingHash;
    int isRunningHash;
    int IsDestroyingHash;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        isWalkingHash = Animator.StringToHash("IsWalking");
        isRunningHash = Animator.StringToHash("IsRunning");
        IsDestroyingHash = Animator.StringToHash("IsDestroying");
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalMouse = Input.GetAxis("Mouse X");

        if (Input.GetKey("w") | Input.GetKey("a") | Input.GetKey("s") | Input.GetKey("d"))
        {
            animator.SetBool(isWalkingHash, true);
        }
        else
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (Input.GetKey(KeyCode.LeftShift) && animator.GetBool(isWalkingHash))
        {
            animator.SetBool(isRunningHash, true);
            speed = 6;
        }
        else
        {
            animator.SetBool(isRunningHash, false);
            speed = 2;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool(IsDestroyingHash, true);
            speed = 0;
            if (Digging)
            {
                StartCoroutine(DigSequence());
                Digging = false;
                //speed = 0;
            }
        }
        else
        {
            Digging = true;
            StopCoroutine(DigSequence());
            BreakBox.SetActive(false);
            animator.SetBool(IsDestroyingHash, false);
        }

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Rotate(0, horizontalMouse, 0);
    }
    IEnumerator DigSequence()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            BreakBox.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            BreakBox.SetActive(false);
        }

    }
}
