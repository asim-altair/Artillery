using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManging : MonoBehaviour
{
    public void LoadScene(int num){
        SceneManager.LoadScene(num);
    }
}
