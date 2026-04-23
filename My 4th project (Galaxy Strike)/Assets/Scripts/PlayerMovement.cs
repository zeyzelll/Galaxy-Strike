using UnityEngine;
using UnityEngine.InputSystem;
public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 10f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 5f;

    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float controlPitchFactor = 18f;
    [SerializeField] float rotationSpeed = 10f;

    Vector2 movement;
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    // public void OnMove(InputValue value) = Oyuncu bir yere gitmek iiçin bir tuşa bastığında bu kodu çalıştır.
    // OnMove = Hareket olayı olduğunda çalış.
    // InputValue = Oyuncudan gelen hareket bilgisini temsil eder.
    // value.Get<Vector2>() = Oyuncunun hareket bilgisini alır ve bu bilgiyi bir Vector2 -(1.0, 0.0)- olarak döndürür.

    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);
        // Oyuncunun ekrandan çıkmasını engelliyor. 

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }
    // xOffset değeri, hız ile zaman çarpılarak bulunur. Bu sayede, her karede aynı miktarda hareket sağlanır.
    // Bu değişken, hareketin ne kadar olacağını belirler.
    // transform.localPosition.x + xOffset: Nesnenin mevcut x konumuna, yukarıda hesapladığımız xOffset değerini ekliyoruz.(Sonrasında bunu yukarı rawXPos a aldık.)
    // Yani, nesne sağa doğru hareket eder.
    // controlSpeed ile hızı ayarlayabilirsin ve her saniye nesne ne kadar hareket edeceğini bu şekilde hesaplar.

    void ProcessRotation()
    {
        float pitch = -controlPitchFactor * movement.y;
        float roll = -controlRollFactor * movement.x;
        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
        // transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, timeCount * speed);
        // Quaternion.Euler ile nesnenin dönüşünü ayarlar.
    }
}
