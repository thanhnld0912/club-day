using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MAINMENU : MonoBehaviour
{
    public Rigidbody2D startButtonRigidbody;
    public float initialForce = 10.0f; // Lực ban đầu
    public float delayBeforeStart = 2.0f; // Thời gian chờ trước khi bắt đầu trò chơi

    private bool gameStarted = false;

    public void PlayGame()
    {
        if (!gameStarted)
        {
            StartCoroutine(ShootStartButtonAndStartGame());
        }
    }

    private IEnumerator ShootStartButtonAndStartGame()
    {
        gameStarted = true;

        // Tắt xác định va chạm của nút bắt đầu
        startButtonRigidbody.collisionDetectionMode = CollisionDetectionMode2D.Discrete;

        // Áp dụng lực ban đầu cho nút bắt đầu
        startButtonRigidbody.velocity = Vector2.zero;
        startButtonRigidbody.AddForce(Vector2.right * initialForce, ForceMode2D.Impulse);

        // Chờ 2 giây trước khi bắt đầu trò chơi
        yield return new WaitForSeconds(delayBeforeStart);

        // Bắt đầu trò chơi
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
