using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEfect : MonoBehaviour
{
    [SerializeField] GameObject clickEfect;
    [SerializeField] Camera mainCamera;
    Coroutine efectCoroutine;
    Vector3 _mousePos;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clickEfect.SetActive(false);
            clickEfect.SetActive(true);

            if (efectCoroutine != null)
                StopCoroutine(efectCoroutine);
            _mousePos = Input.mousePosition;
            efectCoroutine = StartCoroutine(clickEfectDestroy());
        }

        

        _mousePos.z = 1;
        transform.position = mainCamera.ScreenToWorldPoint(_mousePos);
    }


    IEnumerator clickEfectDestroy()
    {
        yield return new WaitForSeconds(1f);
        clickEfect.SetActive(false);
    }
}
