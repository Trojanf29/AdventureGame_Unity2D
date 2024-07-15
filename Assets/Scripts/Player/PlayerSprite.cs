using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField]
    public Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        var selectedHero = GameSessionHandler.CurrentProfile.SelectedHero;

        if (Resource.AnimatorControllers.ContainsKey(selectedHero))
        {
            Anim.runtimeAnimatorController = Resource.AnimatorControllers[selectedHero];
        }
    }
}
