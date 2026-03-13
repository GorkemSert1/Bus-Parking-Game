using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    [Header("Skor Ayarlarý")]
    public int skor = 0;
    public TextMeshProUGUI skorYazisi;

    [Header("Görev Ayarlarý")]
    public int hedefSkor = 100; // Park yerinin açýlmasý için gereken skor
    public TextMeshProUGUI gorevYazisi; // Ekrana eklediðimiz Görev Yazýsý

    [Header("Ses Ayarlarý")]
    public AudioClip toplamaSesi;

    void Start()
    {
        skorYazisi.text = "Skor: " + skor.ToString();
        if (gorevYazisi != null) gorevYazisi.text = "Görev: " + hedefSkor + " Altýn Topla!";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            skor += 10;
            skorYazisi.text = "Skor: " + skor.ToString();

            if (toplamaSesi != null)
            {
                AudioSource.PlayClipAtPoint(toplamaSesi, transform.position);
            }

            Destroy(other.gameObject);

            // YENÝ KISIM: Altýn hedefine ulaþýldýysa görev yazýsýný deðiþtir!
            if (skor >= hedefSkor && gorevYazisi != null)
            {
                gorevYazisi.text = "Görev: Yeþil Alana Park Et!";
                gorevYazisi.color = Color.green; // Yazýyý yeþil yap
            }
        }
    }
}