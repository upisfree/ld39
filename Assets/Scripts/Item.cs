using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour {
  public static int WIN_COUNT = 0;

  private float X = GetRandomNumber(-1, 1);
  private float Y = GetRandomNumber(-1, 1);
  private float Z = GetRandomNumber(-1, 1);

  public int Distance = 2;
  public int Seconds = 0;
  public string Subtitle = "";
  public bool IsAlive = true;

  public InAudioNode music;
  public InAudioNode voice;

  public GameObject StartImage;
  public GameObject EndImage;
  public GameObject Canvas;
  public GameObject Cam;
  public TMP_Text SubtitleObject;

  void Start () {
    InAudio.Play(gameObject, music);

    StartImage = GameObject.Find("Start");
    EndImage = GameObject.Find("End");
    Canvas = GameObject.Find("Canvas");
    Cam = GameObject.Find("Main Camera");
    SubtitleObject = GameObject.Find("Subtitle").GetComponent<TMP_Text>();
  }
	
  void Update () {
    gameObject.transform.Rotate(X, Y, Z);

    //if (StartImage.active)
    //  StartImage.SetActive(false);
    //else
    //  StartImage.SetActive(true);

    if (IsAlive)
    {
      if (Vector3.Distance(transform.position, GameObject.Find("NoClipFirstPersonController").transform.position) < Distance)
      {
        X /= 10;
        Y /= 10;
        Z /= 10;

        StartCoroutine(KillObject());
      }
    }
  }

  IEnumerator KillObject()
  {
    IsAlive = false;
    
    yield return new WaitForSeconds(Seconds);

    SubtitleObject.text = Subtitle;

    InAudio.Play(gameObject, voice);
    InAudio.Stop(gameObject, music);

    WIN_COUNT += 1;
    
    if (WIN_COUNT > 10)
    {
      yield return new WaitForSeconds(6);

      //GetComponent<NoClipFirstPersonController>().enabled = false;
      //GetComponent<NoClipMouseLook>().enabled = false;

      SubtitleObject.text = "";
      StartImage.SetActive(false);
      EndImage.SetActive(true);
      Canvas.SetActive(true);
      Cam.SetActive(false);

      yield return new WaitForSeconds(10);
      
      WIN_COUNT = 0;

      SceneManager.LoadScene("scene");
    }
  }

  static float GetRandomNumber(double minimum, double maximum)
  {
    System.Random random = new System.Random();
    return (float)(random.NextDouble() * (maximum - minimum) + minimum);
  }
}
