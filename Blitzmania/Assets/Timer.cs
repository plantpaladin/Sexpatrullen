using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Timer : MonoBehaviour {
    private Text m_diplayTime;
    private float m_timer;
    private int m_numbPlayers;
    private int m_playerWithCrown;//gives the number of the player
    private System.Collections.Generic.List<float> m_playerScoreList;
	// Use this for initialization
	void Start () {
        m_diplayTime = GetComponent<Text>();
        if (PlayerPrefs.HasKey("timeToPlay"))//checks if the value exists
        {
            m_timer = PlayerPrefs.GetFloat("timeToPlay");//then loads it
        }
        else
        {
            m_timer = 300;//or is set to a default value
        }
        
        if (PlayerPrefs.HasKey("numberOfPlayers"))//same as previous
        {
            m_numbPlayers = PlayerPrefs.GetInt("numberOfPlayers");//gets the number of players
        }
        else
        {
            m_numbPlayers = 3;//or is set to a default value
        }
        for (int i = 0; i < m_numbPlayers; i++)//runs the script once for each player
        {
            m_playerScoreList.Add(0.0f);//all of them start at zero score
        }//the players score is placed at index playerNumber-1 (because there is no player 0)
        m_playerWithCrown = 1;

    }
	
	// Update is called once per frame
	void Update () {
        m_timer -= Time.deltaTime; ;//removes the time since last update
        for (int i = 0; i < m_playerScoreList.Count; i++)
        {
            if (i == (m_playerWithCrown - 1))//decrease by one as there is still no player 0
            {
                m_playerScoreList[i] += Time.deltaTime; ;
            }
        }
        if (m_timer > 0)//has to make check after or the last score wont be added
        {
            m_diplayTime.text = "Time Left = " + m_timer.ToString() + "\n";//the \n means it's a new line
            for (int i = 0; i < m_playerScoreList.Count; i++)
            {
                m_diplayTime.text += "Player " + (i + 1) + " score equals "+ m_playerScoreList[i]  + "\n";
            }
        }
        else
        {
            m_timer = 300;
        }
	}
}
