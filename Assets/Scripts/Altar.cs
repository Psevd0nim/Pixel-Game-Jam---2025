using TMPro;
using UnityEngine;

public class Altar : MonoBehaviour
{
    [SerializeField] private ResurrectMiniGame _resurrectMiniGame;
    [SerializeField] private TextMeshPro _textInterract;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _resurrectMiniGame.canSetActive = true;
            _textInterract.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _resurrectMiniGame.canSetActive = false;
            _textInterract.gameObject.SetActive(false);
        }
    }
}
