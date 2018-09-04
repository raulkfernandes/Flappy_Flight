using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceMenu : MonoBehaviour {

    [SerializeField] private GameObject botaoSair;
    [SerializeField] private Texture2D cursor;
    private float cursorHotspot = 2.5f;
    [SerializeField] [Range(0.1f, 0.5f)] private float tempoDeEsperaBotoes = 0.15f;

    private void Start()
    {
        //Vector2 hotspot = new Vector2(this.cursor.width / this.cursorHotspot, this.cursor.height / this.cursorHotspot);
        //Cursor.SetCursor(this.cursor, hotspot, CursorMode.ForceSoftware);
        Cursor.visible = true;

        Time.timeScale = 1;

        #if UNITY_STANDALONE || UNITY_EDITOR
            botaoSair.SetActive(true);
        #endif
    }

    public void JogarSolo ()
    {
        StartCoroutine(MudarCena(LiteralStrings.SoloScene));
    }

    public void JogarCoop ()
    {
        StartCoroutine(MudarCena(LiteralStrings.CoopScene));
    }

    public void JogarVersus ()
    {
        StartCoroutine(MudarCena(LiteralStrings.VersusScene));
    }

    IEnumerator MudarCena(string momeDaCena)
    {
        yield return new WaitForSecondsRealtime(tempoDeEsperaBotoes);
        SceneManager.LoadScene(momeDaCena);
    }

    public void SairDoJogo()
    {
        StartCoroutine(Sair());
    }

    IEnumerator Sair()
    {
        yield return new WaitForSecondsRealtime(tempoDeEsperaBotoes);
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
