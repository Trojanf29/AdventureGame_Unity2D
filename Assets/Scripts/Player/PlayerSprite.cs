using Assets.Scripts.StatelessData;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField]
    public Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        var selectedHero = GameSessionHandler.CurrentProfile.SelectedHero;

        if (SceneManager.GetActiveScene().name.Contains("Boss"))
        {
            Anim.runtimeAnimatorController = Resource.AnimatorControllers[Constants.Selectable.Hero];
        }
        else if (Resource.AnimatorControllers.ContainsKey(selectedHero))
        {
            Anim.runtimeAnimatorController = Resource.AnimatorControllers[selectedHero];
        }
    }
}
