using UnityEngine;
using UnityEngine.SceneManagement; // Sahne (Bölüm) yüklemek için ÞART!

public class GameManager : MonoBehaviour
{
    void Update()
    {
        // Klavyeden 'R' tuþuna basýlýrsa
        if (Input.GetKeyDown(KeyCode.R))
        {
            YenidenBaslat();
        }

        // Klavyeden 'ESC' (Escape) tuþuna basýlýrsa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OyundanCik();
        }
    }

    // Ekrandaki butonlarýn da týklayabilmesi için baþýna "public" yazýyoruz
    public void YenidenBaslat()
    {
        // Þu anki aktif sahnenin adýný al ve o sahneyi en baþtan tekrar yükle
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Eðer oyun Game Over'da durdurulduysa, zamaný tekrar normale döndür
        Time.timeScale = 1f;
    }

    public void OyundanCik()
    {
        // Unity editöründe oyun kapanmaz, çalýþtýðýný anlamak için konsola yazý yazdýrýyoruz
        Debug.Log("Oyundan Çýkýlýyor...");

        // Oyunu bilgisayara .exe olarak kaydettiðinde (Build) oyunu tamamen kapatacak kod:
        Application.Quit();
    }
}