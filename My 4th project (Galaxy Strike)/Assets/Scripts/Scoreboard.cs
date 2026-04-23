using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreboardText;
    int score = 0;

    public void IncreaseScore(int amount)
    {
        score += amount;
        //score = score + amount;
        //Debug.Log(score);
        scoreboardText.text = score.ToString();
        // ToString() metodu, sayısal değeri metin biçimine dönüştürür. Tamsayı veri türünü tuvalimizde bir metin öğesi olarak düzgün bir şekilde görüntülenecek bir dizeye değiştirecektir.
    }
}
