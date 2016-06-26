using UnityEngine;
using System.Collections;
 
public enum SceneType
{
    None = -1,
    Title,
    Lobby,
    Game,

    Max,

}
public class SceneManager : SingleTon<SceneManager> 
{

    private SceneBase m_currentScene;
    private SceneType m_currentSceneType = SceneType.None;

    public SceneBase currentScene { get { return m_currentScene; } }
    public SceneType currentSceneType { get { return m_currentSceneType; } }

    public void ChangeScene(SceneType sceneType)
    {
        if(m_currentScene != null)
        {
            m_currentScene.Exit();
        }

        m_currentScene = GetScene(sceneType);

        if (m_currentScene != null)
        {
            m_currentScene.Enter();
        }
        m_currentSceneType = sceneType;
    }

    SceneBase GetScene(SceneType sceneType)
    {
        SceneBase scene = null;
        switch (sceneType)
        {
            case SceneType.Title:
                scene = new SceneTitle();
                break;
            case SceneType.Lobby:
                scene = new SceneLobby();
                break;
            case SceneType.Game:
                scene = new SceneGame();
                break;
        }
        return scene;
    }

}
