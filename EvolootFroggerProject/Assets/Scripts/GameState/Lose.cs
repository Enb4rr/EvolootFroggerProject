using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Lose : MonoBehaviour
{
    HealthController healthController;
    GameManager gameManager;
    [SerializeField] private CanvasGroup group;
    [SerializeField] private RectTransform gameOverRect;
    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        healthController = FindObjectOfType<HealthController>();
    }
    private void OnEnable()
    {
        healthController.OnGameOver += GameOver;
        gameManager.OnRestart += OnReset;
    }
    private void OnDisable()
    {
        healthController.OnGameOver -= GameOver;
        gameManager.OnRestart -= OnReset;
    }
    public void GameOver()
    {
        //group.gameObject.SetActive(true);
        group.DOFade(1, 1.5f).SetDelay(0.5f);
        Sequence ShowTitle = DOTween.Sequence();
        ShowTitle.Append(gameOverRect.DOAnchorPos(new Vector2(1028, 529), 1, false));
        ShowTitle.Append(gameOverRect.DOShakeAnchorPos(10, 10, 10, 90, false, false)).SetLoops(2);
    }

    public void OnReset()
    {
        //group.gameObject.SetActive(false);
        group.DOFade(0, 1.5f).SetDelay(0.5f);
    }
}