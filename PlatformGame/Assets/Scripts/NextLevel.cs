using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    
    [SerializeField] private string levelName;
    private AssetBundle LoadedAssetBundle;
    private string[] scenePaths;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           SceneManager.LoadScene(levelName);
        }
    }

    


}
