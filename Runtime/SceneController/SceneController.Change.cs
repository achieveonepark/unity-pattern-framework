using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

using UniTask;

partial class SceneController
{
    public async Task ChangeSceneInternal(int sceneIndex)
    {
        await SceneManager.LoadSceneAsync(sceneIndex);
    }
}