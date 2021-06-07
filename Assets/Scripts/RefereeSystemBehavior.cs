using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class RefereeSystemBehavior : MonoBehaviour
    {
        public GameObject B1;
        public GameObject B2;
        public GameObject R1;
        public GameObject R2;
        
        public GameObject buffzone1;
        public GameObject buffzone2;
        public GameObject buffzone3;
        public GameObject buffzone4;
        public GameObject buffzone5;
        public GameObject buffzone6;
        
        private BuffZoneBehavior buffZoneBehavior1;
        private BuffZoneBehavior buffZoneBehavior2;
        private BuffZoneBehavior buffZoneBehavior3;
        private BuffZoneBehavior buffZoneBehavior4;
        private BuffZoneBehavior buffZoneBehavior5;
        private BuffZoneBehavior buffZoneBehavior6;
        
        private RobotStatus B1_Status;
        private RobotStatus B2_Status;
        private RobotStatus R1_Status;
        private RobotStatus R2_Status;
        
        // game status
        const byte PRE_MATCH = 0;
        const byte SETUP = 1;
        const byte INIT = 2;
        const byte FIVE_SEC_CD = 3;
        const byte ROUND = 4;
        const byte CALCULATION = 5;

        public int gameStatus;


        public double gameTime;
        public double timeLimit;
        public int numRound;
        public int totalRound;
        public int winner;

        public int B_Score;
        public int R_Score;
        

        private void Start()
        {
            gameStatus = INIT;
            InitObjs();
            B_Score = 0;
            R_Score = 0;
            numRound = 1;
            winner = 0;
        }


        private void Update()
        {
            DecideWhoVictory();
            gameStatus = ROUND;
            
            if (CheckWining() || (Input.GetKey(KeyCode.K)))
            {
                // a round is end
                gameStatus = SETUP;
                GameRestart();
                gameStatus = ROUND;
            }

            gameTime += 0.1;
        }


        

        private bool CheckWining()
        {

            // if within time limit
            if (gameTime < timeLimit)
            {
                // if each team has a survivor
                if ((!R1_Status.isDead || !R2_Status.isDead) && (!B1_Status.isDead || !B2_Status.isDead))
                {
                    return false;
                }

                gameStatus = CALCULATION;
            
                if (B1_Status.isDead && B2_Status.isDead && R1_Status.isDead && R2_Status.isDead)
                {
                    Debug.Log("no winner");
                    return true;
                }

                if (B1_Status.isDead && B2_Status.isDead)
                {
                    Debug.Log("R win");
                    R_Score++;
                    return true;
                }

                Debug.Log("B win");
                B_Score++;
                return true;
            }

            // time limit has passed. 
            gameStatus = CALCULATION;
            
            // if B has casualty while R does not
            if ((B1_Status.isDead || B2_Status.isDead) && (!R1_Status.isDead && !R2_Status.isDead))
            {
                Debug.Log("R win");
                R_Score++;
                return true;
            } 
                
            // time limit has passed. if R has casualty while B does not
            if ((R1_Status.isDead || R2_Status.isDead) && (!B1_Status.isDead && !B2_Status.isDead))
            {
                Debug.Log("B win");
                B_Score++;
                return true;
            }

            // time limit has passed. if all dead
            if (B1_Status.isDead && B2_Status.isDead && R1_Status.isDead && R2_Status.isDead)
            {
                Debug.Log("no winner");
                return true;
            }

            // time limit has passed. if B all dead
            if (B1_Status.isDead && B2_Status.isDead)
            {
                Debug.Log("R win");
                R_Score++;
                return true;
            }

            Debug.Log("B win");
            B_Score++;
            return true;
        }

        private void DecideWhoVictory()
        {
            if (totalRound == 0)
            {
                Debug.Log("Please set total Rounds");
                return;
            }
            
            if (numRound > totalRound/2 && R_Score == 0)
            {
                // B Victory
                winner = 1;
            } else if (numRound > totalRound/2 && B_Score == 0)
            {
                // R Victory
                winner = 2;
            } 
            else if (numRound >= totalRound)
            {
                if (B_Score > R_Score)
                {
                    // B Victory
                    winner = 1;
                } else if (B_Score < R_Score)
                {
                    // R Victory
                    winner = 2;
                }
                else
                {
                    // no Victory
                    winner = 3;
                }
            }
        }

        private void GameRestart()
        {
            numRound++;
            gameTime = 0;
            B1_Status.InitRobot();
            B2_Status.InitRobot();
            R1_Status.InitRobot();
            R2_Status.InitRobot();
            Debug.Log("game restarted");
        }
        
        private void InitObjs()
        {
            if(B1 == null) B1 = GameObject.Find("B1");
            if(B2 == null) B2 = GameObject.Find("B2");
            if(R1 == null) R1 = GameObject.Find("R1");
            if(R2 == null) R2 = GameObject.Find("R2");
            
            if(buffzone1 == null) buffzone1 = GameObject.Find("BuffZone1");
            if(buffzone2 == null) buffzone2 = GameObject.Find("BuffZone2");
            if(buffzone3 == null) buffzone3 = GameObject.Find("BuffZone3");
            if(buffzone4 == null) buffzone4 = GameObject.Find("BuffZone4");
            if(buffzone5 == null) buffzone5 = GameObject.Find("BuffZone5");
            if(buffzone6 == null) buffzone6 = GameObject.Find("BuffZone6");
            
            if (buffzone1 != null)
            {
                buffZoneBehavior1 = buffzone1.GetComponent<BuffZoneBehavior>();
            }
            else
            {
                Debug.LogWarning("referee can't find BuffZone1 Obj");
            }
            if (buffzone2 != null)
            {
                buffZoneBehavior2 = buffzone2.GetComponent<BuffZoneBehavior>();
            }
            else
            {
                Debug.LogWarning("referee can't find BuffZone2 Obj");
            }
            if (buffzone3 != null)
            {
                buffZoneBehavior3 = buffzone3.GetComponent<BuffZoneBehavior>();
            }
            else
            {
                Debug.LogWarning("referee can't find BuffZone3 Obj");
            }
            if (buffzone4 != null)
            {
                buffZoneBehavior4 = buffzone4.GetComponent<BuffZoneBehavior>();
            }
            else
            {
                Debug.LogWarning("referee can't find BuffZone4 Obj");
            }
            if (buffzone5 != null)
            {
                buffZoneBehavior5 = buffzone5.GetComponent<BuffZoneBehavior>();
            }
            else
            {
                Debug.LogWarning("referee can't find BuffZone5 Obj");
            }
            if (buffzone6 != null)
            {
                buffZoneBehavior6 = buffzone6.GetComponent<BuffZoneBehavior>();
            }
            else
            {
                Debug.LogWarning("referee can't find BuffZone6 Obj");
            }

            if (B1 != null)
            {
                B1_Status = B1.GetComponent<RobotStatus>();
            }
            else
            {
                Debug.LogWarning("referee can't find B1 bot Obj");
            }
            if (B2 != null)
            {
                B2_Status = B2.GetComponent<RobotStatus>();
            }
            else
            {
                Debug.LogWarning("referee can't find B2 bot Obj");
            }
            if (R1 != null)
            {
                R1_Status = R1.GetComponent<RobotStatus>();
            }
            else
            {
                Debug.LogWarning("referee can't find R1 bot Obj");
            }
            if (R2 != null)
            {
                R2_Status = R2.GetComponent<RobotStatus>();
            }
            else
            {
                Debug.LogWarning("referee can't find R2 bot Obj");
            }
        }

        public RobotStatus B1Status => B1_Status;

        public RobotStatus B2Status => B2_Status;

        public RobotStatus R1Status => R1_Status;

        public RobotStatus R2Status => R2_Status;
        
        public int Winner => winner;

        public double TimeLimit => timeLimit;

        public double GameTime => gameTime;

        public int GameStatus
        {
            get => gameStatus;
            set => gameStatus = value;
        }
    }
    
    
}