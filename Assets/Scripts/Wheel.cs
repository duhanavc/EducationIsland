using UnityEngine;

public class WheelOfFortune : MonoBehaviour
{
    // Tekerleðin dönüþ hýzý
    public float spinSpeed = 100f;

    // Tekerleðin duracaðý hedef açý (X ekseni)
    public float targetAngle = 202.5f;

    // Tekerlek dönüyor mu kontrolü
    private bool isSpinning = false;

    // Þu anki açý (X ekseni)
    private float currentAngle = 0f;

    // Y ve Z eksenlerindeki sabit açýlar
    private float fixedYAngle = -90f;
    private float fixedZAngle = -90f;

    void Update()
    {
        // Sol týklama ile dönmeye baþlat
        if (Input.GetMouseButtonDown(0))
        {
            isSpinning = true;
        }

        // Sol týklama býrakýldýðýnda otomatik dönmeye baþla
        if (Input.GetMouseButtonUp(0))
        {
            isSpinning = false;
            // Hedef açýya ulaþmak için kalan açýyý hesapla ve dönüþ hýzýný ayarla
            float remainingAngle = targetAngle - currentAngle;
            spinSpeed = Mathf.Abs(remainingAngle) / 0.5f;
        }

        // Tekerlek dönüyorsa
        if (isSpinning)
        {
            // Þu anki açýyý güncelle
            currentAngle += spinSpeed * Time.deltaTime;

            // Tekerleðin rotasyonunu güncelle (X, Y, Z)
            transform.rotation = Quaternion.Euler(currentAngle, fixedYAngle, fixedZAngle);

            // Hedef açýya yaklaþýldýysa dönmeyi durdur
            if (Mathf.Abs(currentAngle - targetAngle) < 0.1f)
            {
                isSpinning = false;
                currentAngle = targetAngle;
            }
        }
    }
}