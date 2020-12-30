#if UNITY_EDITOR
    /// <summary>
    /// This method is strictly for editor use only.
    /// </summary>
    /// <param name="clip"></param>
    public void PlayClip(AudioClip clip)
    {
        if (clip != null)
        {
            Debug.Log($"EDITOR TOOL: Previewing Clip {clip.name} in {this.name}");
            System.Reflection.Assembly unityEditorAssembly = typeof(AudioImporter).Assembly;
            System.Type audioUtilClass = unityEditorAssembly.GetType("UnityEditor.AudioUtil");
            System.Reflection.MethodInfo method = audioUtilClass.GetMethod(
                "PlayClip",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public,
                null,
                new System.Type[] { typeof(AudioClip), typeof(int), typeof(bool) },
                null
            );
            method.Invoke(
                null,
                new object[] { clip, 0, false }
            );
        }
        else
            Debug.Log("EDITOR TOOL: Cannot preview clip as no clip is assigned.");
        
    }

#endif