using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public abstract class Mediator : MonoBehaviour
    {
        public void ChangeScene(int buildIndexScene) =>
            SceneManager.LoadScene(buildIndexScene);
        
        public void Exit() =>
            Application.Quit();
    }
}