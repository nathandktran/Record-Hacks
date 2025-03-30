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
  SerialPort data_stream = new SerialPort("COM3", 9600);
  public string receivedstring;

  // Initialization
  void Start() {
    theSR = GetComponent<SpriteRenderer>();
    data_stream.Open();
  }

  // Update once per frame
  void Update() {
    if (Input.GetKeyDown(keyToPress)) {
      theSR.sprite = pressedImage;
    }

    if (Input.GetKeyUp(keyToPress)) {
      theSR.sprite = defaultImage;
    }
  }
}
