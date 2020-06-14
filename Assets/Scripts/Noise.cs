using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour {
  public InAudioNode noise;

  void Start () {
    Cursor.visible = false;

    InAudio.Play(gameObject, noise);

    GetComponent<NoClipFirstPersonController>().enabled = false;
    GetComponent<NoClipMouseLook>().enabled = false;

    GameObject.Find("Start").SetActive(true);

    StartCoroutine(RemoveStartScreen());
  }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator RemoveStartScreen()
  {
    yield return new WaitForSeconds(10);
    
    GameObject.Find("Start").SetActive(false);
    GameObject.Find("End").SetActive(false);

    GetComponent<NoClipFirstPersonController>().enabled = true;
    GetComponent<NoClipMouseLook>().enabled = true;
  }
}
