using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static float money;
    public float startMoney = 400f;

    public static int lives;
    public int startLives = 20;

    void Start()
    {
        money = startMoney;
        lives = startLives;
    }

}
