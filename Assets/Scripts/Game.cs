using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using static UnityEngine.Object;

public static class Game
{
    public static Scene ItemsScene { get; private set; }
    public static Scene EnemiesScene { get; private set; }
    public static Scene BulletsScene { get; private set; }
    public static JoystickController Joystick { get; private set; }
    public static DisplayingUI UI { get; private set; }

    [RuntimeInitializeOnLoadMethod]
    static void Initialize()
    {
        ItemsScene = SceneManager.CreateScene("Items");
        EnemiesScene = SceneManager.CreateScene("Enemies");
        BulletsScene = SceneManager.CreateScene("Bullets");
        Joystick = FindObjectOfType<JoystickController>();
        UI = FindObjectOfType<DisplayingUI>();
    }

    public static Vector3 GetInputFromJoystick()
    {
        Vector2 m = Joystick.JoystickPosition;
        Vector3 move = new Vector3(m.x, 0, m.y);
        return move;
    }
}