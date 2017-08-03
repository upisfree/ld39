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

  void Update () {
	}

  IEnumerator RemoveStartScreen()
  {
    yield return new WaitForSeconds(12);
    
    GameObject.Find("Canvas").SetActive(false);

    GetComponent<NoClipFirstPersonController>().enabled = true;
    GetComponent<NoClipMouseLook>().enabled = true;
  }
}
