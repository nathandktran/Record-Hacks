using UnityEngine;
using System.Collections;
using System.Collections.Generic;
// using System.IO.Ports;
using System;

public class ButtonController : MonoBehaviour {

  private SpriteRenderer theSR;
  public Sprite defaultImage;
  public Sprite pressedImage;

  public KeyCode keyToPress;
  // SerialPort data_stream = new SerialPort("COM3", 9600);
  public string receivedstring;

  public KeyCode test = KeyCode.A;

  // Initialization
  void Start() {
    theSR = GetComponent<SpriteRenderer>();
    // data_stream.Open();s
  }

  // Update once per frame
  void Update() {
    if (Input.GetKeyDown(keyToPress)) {
      theSR.sprite = pressedImage;
      Debug.Log(keyToPress);
    }

    if (Input.GetKeyUp(keyToPress)) {
      
      theSR.sprite = defaultImage;
    }
  }
}
