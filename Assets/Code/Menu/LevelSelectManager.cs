using System.Collections.Generic;
using Code.Scene;
using Michsky.UI.Heat;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Menu
{
    [RequireComponent(typeof(ChapterManager))]
    public class LevelSelectManager : MonoBehaviour
    {
        public PanelManager panelManager;
        private ChapterManager _chapterManager;
        private SceneLoader _sceneLoader;
        
        private void Awake()
        {
            _chapterManager = GetComponent<ChapterManager>();
            _sceneLoader = FindObjectOfType<SceneLoader>();

            // Get all scenes in build that start with 'floor'
            var scenes = new List<string>();
            for (var i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                var scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                var sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
                if (sceneName.StartsWith("floor"))
                {
                    scenes.Add(sceneName);
                }
            }

            if (scenes.Count != _chapterManager.chapters.Count)
            {
                Debug.LogError("Number of scenes does not match number of chapters");
                return;
            }

            // Sort by floor number
            scenes.Sort((a, b) =>
            {
                var aNumber = int.Parse(a[5..]);
                var bNumber = int.Parse(b[5..]);
                return aNumber.CompareTo(bNumber);
            });

            // Make sure each chapter matches the scene
            for (var i = 0; i < scenes.Count; i++)
            {
                var scene = scenes[i];
                var chapter = _chapterManager.chapters[i];
                if (scene != chapter.chapterID)
                {
                    Debug.LogError($"Scene {scene} does not match chapter {chapter.chapterID}");
                    return;
                }
                
                chapter.onPlay.AddListener(() => OnPlay(chapter.chapterID));
                chapter.onReplay.AddListener(() => OnReplay(chapter.chapterID));
            }
        }

        public void OnReplay(string chapterID)
        {
            var chapterIndex = _chapterManager.chapters.FindIndex(chapter => chapter.chapterID == chapterID);
            ChapterManager.SetUnlocked(chapterID);

            // Set all future chapters to locked
            for (var i = chapterIndex + 1; i < _chapterManager.chapters.Count; i++)
            {
                var chapter = _chapterManager.chapters[i];
                ChapterManager.SetLocked(chapter.chapterID);
            }

            OnPlay(chapterID);
        }

        public void OnPlay(string chapterID)
        {
            _sceneLoader.SetScene(chapterID);
            panelManager.NextPanel();
        }
    }
}