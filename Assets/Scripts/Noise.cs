using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Noise : MonoBehaviour {
  public InAudioNode noise;

  void Start () {
    Cursor.visible = true;

    InAudio.Play(gameObject, noise);

    GetComponent<NoClipFirstPersonController>().enabled = false;
    GetComponent<NoClipMouseLook>().enabled = false;
  }

  void StartGame()
  {
    Cursor.visible = false;

    GameObject.Find("Start").GetComponent<RawImage>().enabled = true;
    GameObject.Find("End").GetComponent<RawImage>().enabled = true;

    if (Globals.language == "en")
    {
        GameObject.Find("Start").GetComponent<RawImage>().texture = Resources.Load<Texture>("start-en");
        GameObject.Find("End").GetComponent<RawImage>().texture = Resources.Load<Texture>("end-en");
    }

    GameObject.Find("ButtonEn").SetActive(false);
    GameObject.Find("ButtonRu").SetActive(false);

    StartCoroutine(RemoveStartScreen());
  }

  void FixedUpdate()
  {
    if (Input.GetKeyDown(KeyCode.Escape) && Application.platform != RuntimePlatform.WebGLPlayer)
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

  public void ChangeLanguageToEnglish()
  {
    Globals.language = "en";

    StartGame();
  }

  public void ChangeLanguageToRussian()
  {
    Globals.language = "ru";

    StartGame();
  }
}
