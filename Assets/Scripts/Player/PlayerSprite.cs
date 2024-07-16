using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField]
    public Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        if (Resource.AnimatorControllers.ContainsKey(GameSessionHandler.SelectedHero))
        {
            Anim.runtimeAnimatorController = Resource.AnimatorControllers[GameSessionHandler.SelectedHero];
        }
    }
}
