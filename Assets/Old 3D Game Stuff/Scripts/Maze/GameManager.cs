using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    #region PublicVariables
    public Maze mazePrefab;
    public Player playerPrefab;
    #endregion 

    #region PrivateVariables
    private Maze mazeInstance;
    private Player playerInstance;
    #endregion

    #region PublicMethods

    #endregion

    #region PrivateMethods
    private void Start()
    {
        StartCoroutine(BeginGame());

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            RestartGame();
        }
    }

    private IEnumerator BeginGame()
    {
        Camera.main.clearFlags = CameraClearFlags.Skybox;
        Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
        mazeInstance = Instantiate(mazePrefab) as Maze;
        yield return StartCoroutine(mazeInstance.Generate());
        playerInstance = Instantiate(playerPrefab) as Player;
        playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
        Camera.main.clearFlags = CameraClearFlags.Depth;
        Camera.main.rect = new Rect(0f, 0f, 0.5f, 0.5f);
    }

    private void RestartGame()
    {
        StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
        if (playerInstance != null)
        {
            Destroy(playerInstance.gameObject);
        }
        StartCoroutine(BeginGame());
    }
    #endregion


}
