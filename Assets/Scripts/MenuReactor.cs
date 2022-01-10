﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuReactor : MonoBehaviour
{
    public MenuButtonWatcher watcher;
    public bool IsPressed = false; // used to display button state in the Unity __Inspector__ window
    public Vector3 rotationAngle = new Vector3(45, 45, 45);
    public float rotationDuration = 0.25f; // seconds
    private Quaternion offRotation;
    private Quaternion onRotation;
    private Coroutine rotator;

    void Start()
    {
        watcher.menuButtonPress.AddListener(onMenuButtonEvent);
        offRotation = this.transform.rotation;
        onRotation = Quaternion.Euler(rotationAngle) * offRotation;
    }

    public void onMenuButtonEvent(bool pressed)
    {
        IsPressed = pressed;
        if (rotator != null)
            StopCoroutine(rotator);
        if (pressed)
            rotator = StartCoroutine(AnimateRotation(this.transform.rotation, onRotation));
        else
            rotator = StartCoroutine(AnimateRotation(this.transform.rotation, offRotation));
    }

    private IEnumerator AnimateRotation(Quaternion fromRotation, Quaternion toRotation)
    {
        float t = 0;
        while (t < rotationDuration)
        {
            transform.rotation = Quaternion.Lerp(fromRotation, toRotation, t / rotationDuration);
            t += Time.deltaTime;
            yield return null;
        }
    }
}