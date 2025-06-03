using UnityEngine;

public static class SceneController
{
    private static SceneController _instance;

    static SceneController()
    {
        _instance = new SceneController();
    }

    public static async UniTask ChangeScene(int sceneIndex)
    {
        return await _instance.ChangeSceneInternal(sceneIndex);
    }
}