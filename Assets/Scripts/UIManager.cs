using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MagicPigGames;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject winObj;
    public GameObject loseObj;

    [SerializeField] TMP_Text treesCountText;

    public MagicPigGames.ProgressBar healthProgressBar;

    private void Awake()
    {
        Instance = this;
    }

    public void ToggleLoseUI() => loseObj.SetActive(!loseObj.activeSelf);

    public void ToggleWinUI()
    {
        if (SceneManager.GetActiveScene().name == "Night") winObj.transform.GetChild(1).GetComponent<TMP_Text>().text = "To be continued...";
        winObj.SetActive(!winObj.activeSelf);
    }

    public void UpdateTreesCountDisplay(int treesCount)
    {
        treesCountText.text = treesCount.ToString();
    }

    public void UpdateHealthBar(int health)
    {
        healthProgressBar.SetProgress((float)health / (float)PlayerHealth.Instance.maxHealth);
    }
}
