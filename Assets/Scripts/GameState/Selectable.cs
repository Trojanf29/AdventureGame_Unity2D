using Assets.Scripts.StatelessData;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selectable : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        if (name == Constants.Selectable.VirtualGuy)
        {
            anim = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        if (anim != null)
        {
            anim.SetInteger("state", 0);
        }
    }

    private void OnMouseDown()
    {
        GameSessionHandler.ResetProfile(name);
        LevelHandler.ResetLevelHandler();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
