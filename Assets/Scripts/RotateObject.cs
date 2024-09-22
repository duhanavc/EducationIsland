using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 1000f;
    public float decelerationSpeed = 2f; // Dönüþün yavaþlama hýzý
    private float currentRotationSpeedX; // Þu anki X eksenindeki dönüþ hýzý
    private bool isDragging = false; // Fare ile dönme iþlemi yapýlýyor mu?

    void Update()
    {
        // Fare sol tuþuna basýldýðýnda objeyi döndür
        if (Input.GetMouseButton(0))
        {
            isDragging = true;

            // Fare hareketlerini oku
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

            // Fare hareketine göre X ekseninde dönüþ hýzýný ayarla
            currentRotationSpeedX = -mouseX;

            // Objeyi sadece X ekseninde döndür
            transform.Rotate(Vector3.forward, -mouseX, Space.World);
        }
        else
        {
            // Sol tuþ býrakýldý, artýk yavaþça dönme iþlemi yavaþlayacak
            if (isDragging)
            {
                isDragging = false;
            }

            // Dönüþ hýzýný Lerp ile yavaþlat (sadece X ekseninde)
            currentRotationSpeedX = Mathf.Lerp(currentRotationSpeedX, 0f, decelerationSpeed * Time.deltaTime);

            // Objenin X ekseninde dönmeye devam etmesi
            transform.Rotate(Vector3.up, currentRotationSpeedX);
        }
    }
}
