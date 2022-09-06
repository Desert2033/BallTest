using UnityEngine;
using TMPro;

public class CoinBank : MonoBehaviour
{
    private TextMeshProUGUI _coinCountText;

    private int _coins = 0;

    private void Start()
    {
        CoinEvents.TakeCoin.AddListener(AddCoin);
        _coinCountText = GetComponent<TextMeshProUGUI>();
    }

    public void AddCoin()
    {
        _coins++;
        _coinCountText.text = _coins.ToString();
    }

}
