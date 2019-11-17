using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Character player1;
    public Character player2;
    public GameObject endGame;
    public Text gameInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player1.Direction = (player2.transform.position.x > player1.transform.position.x);
        player2.Direction = (player1.transform.position.x > player2.transform.position.x);

        if (endGame.active && Input.GetKey(KeyCode.R)) SceneManager.LoadScene(0);

        transform.position = new Vector3(Vector3.Lerp(player1.transform.position, player2.transform.position,0.5f).x, transform.position.y, transform.position.z);
    }
    public void Kill(Character p)
    {
        p.Kill();
        if(player2.state.GetName() == "Kill" && player1.state.GetName()=="Kill")
        {
            gameInfo.text = "Equality";
            gameInfo.color = Color.black;
        }
        else if(p == player2)
        {
            gameInfo.text = "Player 1 win!";
            gameInfo.color = Color.blue;
        }
        else
        {
            gameInfo.text = "Player 2 win!";
            gameInfo.color = Color.red;
        }
        endGame.SetActive(true);

    }
}
