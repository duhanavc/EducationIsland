using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 1000f;
    public float decelerationSpeed = 2f; // D�n���n yava�lama h�z�
    private float currentRotationSpeedX; // �u anki X eksenindeki d�n�� h�z�
    private bool isDragging = false; // Fare ile d�nme i�lemi yap�l�yor mu?

    void Update()
    {
        // Fare sol tu�una bas�ld���nda objeyi d�nd�r
        if (Input.GetMouseButton(0))
        {
            isDragging = true;

            // Fare hareketlerini oku
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

            // Fare hareketine g�re X ekseninde d�n�� h�z�n� ayarla
            currentRotationSpeedX = -mouseX;

            // Objeyi sadece X ekseninde d�nd�r
            transform.Rotate(Vector3.forward, -mouseX, Space.World);
        }
        else
        {
            // Sol tu� b�rak�ld�, art�k yava��a d�nme i�lemi yava�layacak
            if (isDragging)
            {
                isDragging = false;
            }

            // D�n�� h�z�n� Lerp ile yava�lat (sadece X ekseninde)
            currentRotationSpeedX = Mathf.Lerp(currentRotationSpeedX, 0f, decelerationSpeed * Time.deltaTime);

            // Objenin X ekseninde d�nmeye devam etmesi
            transform.Rotate(Vector3.up, currentRotationSpeedX);
        }
    }
}
