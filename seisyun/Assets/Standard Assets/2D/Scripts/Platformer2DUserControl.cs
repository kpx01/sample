using System;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        public Text text;
        public Text highScore;

        const string SCORE_KEY = "score";
        const string HIGH_SCORE_KEY = "highScore";

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            highScore.text = LoadHighScore() + " m";
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float h = 1.0f;
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
            text.text = (int)transform.position.x + " m";
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.name == "ballobject")
            {
                if((int)transform.position.x > LoadHighScore())
                    SaveHighScore((int)transform.position.x);
                else
                    SaveScore((int)transform.position.x);
                Application.LoadLevel("Result");
            }
        }

        void SaveScore(int score)
        {
            PlayerPrefs.SetInt(SCORE_KEY, score);
            PlayerPrefs.Save();
        }

        void SaveHighScore(int score)
        {
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, score);
            PlayerPrefs.Save();
        }

        int LoadHighScore()
        {
            return PlayerPrefs.GetInt(HIGH_SCORE_KEY, -1);
        }
    }
}
