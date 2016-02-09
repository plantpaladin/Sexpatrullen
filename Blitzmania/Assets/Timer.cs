using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Timer : MonoBehaviour {
    private Text m_diplayTime;
    private float m_timer;

	// Use this for initialization
	void Start () {
        m_diplayTime = GetComponent<Text>();
        if (PlayerPrefs.HasKey("timeToPlay"))//checks if the value exists
        {
            m_timer = PlayerPrefs.GetFloat("timeToPlay");//then loads it
        }
        else
        {
            m_timer = 300;//just a default value
        }
	}
	
	// Update is called once per frame
	void Update () {
        
        m_timer -= Time.deltaTime;//removes the time since last update
        if (m_timer > 0)
        {
            m_diplayTime.text = "Time Left = " + m_timer.ToString();
        }
        else
        {
            m_timer = 300;
        }
	}
}
