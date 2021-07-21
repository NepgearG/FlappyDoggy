using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour
{
    int score = 0;

    enum GameState{
        Main,
        GameOver,
    }

    GameState state = GameState.Main;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        state = GameState.GameOver;
    }
    private void FixedUpdate()
    {
        if (state == GameState.Main)
        {
            score += 1;
        }
    }

    private void OnGUI()
    {
        DrawScore();

        float CenterX = Screen.width / 2;
        float CenterY = Screen.height / 2;
        if(state == GameState.GameOver)
        {
            DrawGameOver(CenterX, CenterY);
            if(DrawRetryButton(CenterX, CenterY))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    bool DrawRetryButton(float CenterX, float CenterY)
    {
        float ofsY = 40;
        float w = 100;
        float h = 64;
        Rect rect = new Rect(CenterX - w / 2, CenterY + ofsY, w, h);
        if(GUI.Button(rect, "Retry"))
        {
            return true;
        }
        return false;
    }
    void DrawGameOver(float CenterX, float CenterY)
    {
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        float w = 400;
        float h = 100;
        Rect position = new Rect(CenterX - w / 2, CenterY - h / 2, w, h);
        GUI.Label(position, "Game Over!");
    }

    void DrawScore()
    {
        GUI.skin.label.fontSize = 32;

        GUI.skin.label.alignment = TextAnchor.MiddleLeft;
        Rect position = new Rect(8, 8, 400, 100);
        GUI.Label(position, string.Format("score:{0}", score));
    }
}
