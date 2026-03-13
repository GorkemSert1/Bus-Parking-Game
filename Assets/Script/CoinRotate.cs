using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    [Header("Dönüþ Ayarý")]
    public float donusHizi = 150f; // Altýnýn kendi etrafýnda dönme hýzý

    void Update()
    {
        // Altýný Y ekseninde (kendi ekseni etrafýnda) sürekli döndür
        transform.Rotate(0f, donusHizi * Time.deltaTime, 0f);
    }
    void Start()
    {
        // Bu altýn doðduktan 15 saniye sonra kimse almazsa kendini yok etsin (kasmayý engellemek için)
        Destroy(gameObject, 15f);
    }
}