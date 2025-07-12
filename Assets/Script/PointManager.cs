using UnityEngine;
using TMPro;  // Menambahkan TextMesh Pro

public class PointManager : MonoBehaviour
{
    public TextMeshProUGUI pointsText;  // Menggunakan TextMesh Pro untuk tampilan poin
    private int points = 0;  // Variabel untuk menyimpan jumlah poin

    void Start()
    {
        // Menampilkan poin pertama kali saat game dimulai
        UpdatePointsDisplay();
    }

    // Fungsi untuk menambah poin
    public void AddPoints(int amount)
    {
        points += amount;  // Menambahkan poin
        UpdatePointsDisplay();  // Memperbarui tampilan poin
    }

    // Fungsi untuk mengupdate tampilan poin
    void UpdatePointsDisplay()
    {
        pointsText.text = "Poin: " + points.ToString();  // Menampilkan poin dalam format string
    }
}