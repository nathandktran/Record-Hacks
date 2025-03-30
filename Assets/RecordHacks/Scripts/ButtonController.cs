using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System;

public class ButtonController : MonoBehaviour {

  private SpriteRenderer theSR;
  public Sprite defaultImage;
  public Sprite pressedImage;

  public KeyCode keyToPress;
  SerialPort data_stream = new SerialPort("/dev/tty.usbserial-0001", 9600);
  public string receivedstring;
  public int buttonNum; // NEW MY LINE

  // Initialization
  void Start() {
    theSR = GetComponent<SpriteRenderer>();
    data_stream.Open();

    // data_stream.Write("START");
  }
  

  // Update once per frame
  void Update() {
    // Debug.Log(GameManager.instance.gameFinished);
    if (data_stream.IsOpen && GameManager.instance.gameFinished == 1) {
      data_stream.Write(GameManager.instance.currentScore.ToString());
    }

    receivedstring = data_stream.ReadLine();
    // Debug.Log(receivedstring);
    string[] datas = receivedstring.Split(':');
    int buttondata = 0, slidepot = 0, reset = 0;
    if (datas.Length == 3) {
    buttondata = int.Parse(datas[0]);
    slidepot = int.Parse(datas[1]);
    reset = int.Parse(datas[2]);

    GameManager.instance.buttonData = buttondata;
    GameManager.instance.resetData = reset;
    GameManager.instance.potData = slidepot;

    if (reset == 1) {
      GameManager.instance.screen = 1;
    } 
  	}
   
    // Debug.Log(buttondata);
    // Debug.Log(slidepot);
    // Debug.Log(reset);

    if (Input.GetKeyDown(keyToPress)) {
      theSR.sprite = pressedImage;
    }

    if (Input.GetKeyUp(keyToPress)) {
      
      theSR.sprite = defaultImage;
    }
    // Debug.Log(buttonNum);
    if ((buttondata & (1<<buttonNum)) > 0) {
      // Debug.Log(buttonNum + " pressed");
      theSR.sprite = pressedImage;
    }
    if ((buttondata & (1<<buttonNum)) == 0) {
      theSR.sprite = defaultImage;
    }
  }
}
