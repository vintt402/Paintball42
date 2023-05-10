using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlagAcceptor : MonoBehaviour
{
    public int team;
    public string winnerText;
    public Text winnerTextField;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            if (collision.GetComponent<Player>().team == team && collision.GetComponent<Player>().hasFlag && !GameManager.Instance.getGameOver())
            {
                winnerTextField.text = winnerText;
                GameManager.Instance.setGameOver(true);
                StartCoroutine(restart());
            }
        }
    }

    IEnumerator restart()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
