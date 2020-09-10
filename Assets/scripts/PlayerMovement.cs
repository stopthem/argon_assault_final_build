using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("General")]
    [SerializeField] float xSpeed = 35f;
    [SerializeField] float restrictXpos = 24f;
    [SerializeField] float restrictYpos = 17f;
    [SerializeField] GameObject[] guns;
    
    [Header("Pitch Control")]
    [SerializeField] float positionPitch = -1f;
    [SerializeField] float controlRotationPitch = -20f;
    [Header("Yaw Control")]
    [SerializeField] float positionYaw = 1f;
    [SerializeField] float controlRoll = -45f;
    float xThrow;
    float yThrow;
    bool isControlEnabled = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled == true)
        {
            TranslatePosition();
            TranslateRotation();
            TranslateFiring();
        }


    }


    private void TranslateRotation()
    {
        float pitch = transform.localPosition.y * positionPitch + yThrow * controlRotationPitch;
        float yaw = transform.localPosition.x * positionYaw;
        float roll = xThrow * controlRoll;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void TranslatePosition()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float xOffsetThisFrame = xThrow * xSpeed * Time.deltaTime;
        float rawNewXposition = transform.localPosition.x + xOffsetThisFrame;
        float clampedXpos = Mathf.Clamp(rawNewXposition, -restrictXpos, restrictXpos);
        float yOffset = yThrow * xSpeed * Time.deltaTime;
        float rawYPosition = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPosition, -restrictYpos, restrictYpos);

        transform.localPosition = new Vector3(clampedXpos, clampedYPos, transform.localPosition.z);
    }
    void TranslateFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunActive(true);
        }
        else
        {
            SetGunActive(false);
        }
    }
    private void SetGunActive(bool isActive)
    {
        foreach (GameObject gun in guns)
        {
            
            var gunE=gun.GetComponent<ParticleSystem>().emission;
                gunE.enabled=isActive;
            
        }
    }


    public void PlayerOnDeath()
    {
        isControlEnabled = false;
    }
}

