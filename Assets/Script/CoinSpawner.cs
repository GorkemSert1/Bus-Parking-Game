using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Coin Ayarlarý")]
    public GameObject coinPrefab; // Üretilecek coin þablonu
    public float uretimHizi = 2f; // Kaç saniyede bir yeni coin üretilsin?

    [Header("Harita Sýnýrlarý (Rastgele Alan)")]
    public float minX = -40f;
    public float maxX = 40f;
    public float minZ = -40f;
    public float maxZ = 40f;

    // Coinlerin haritada çýkacaðý yükseklik
    public float yHeight = 1f;

    void Start()
    {
        // InvokeRepeating komutu bir iþlemi sürekli tekrarlamak için kullanýlýr.
        // 0f -> Oyun baþlar baþlamaz (beklemeden) ilk coini üretir.
        // uretimHizi -> Sonrasýnda her X saniyede bir bu iþlemi tekrarlar.
        InvokeRepeating("TekBirCoinUret", 0f, uretimHizi);
    }

    void TekBirCoinUret()
    {
        // Belirlediðimiz sýnýrlar içinde rastgele X ve Z koordinatlarý seç
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        // Rastgele pozisyonu oluþtur
        Vector3 randomPosition = new Vector3(randomX, yHeight, randomZ);

        // Coini sahnede o pozisyonda yarat
        Instantiate(coinPrefab, randomPosition, Quaternion.identity);
    }
}