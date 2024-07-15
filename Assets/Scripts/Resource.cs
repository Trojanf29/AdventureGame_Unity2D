using Assets.Scripts.StatelessData;
using System.Collections.Generic;
using UnityEngine;

// Requires correct relative path
public class Resource : MonoBehaviour
{
    private static bool Inited;

    public static Dictionary<string, RuntimeAnimatorController> AnimatorControllers = new Dictionary<string, RuntimeAnimatorController>();

    public static void Import()
    {
        if (Inited)
            return;

        Dictionary<string, string> controller_path = new Dictionary<string, string>()
        {
            { Constants.Selectable.VirtualGuy, Constants.Path.Animators.VirtualGuy },
            { Constants.Selectable.PinkMan, Constants.Path.Animators.PinkMan },
            { Constants.Selectable.NinjaFrog, Constants.Path.Animators.NinjaFrog },
            { Constants.Selectable.MaskDude, Constants.Path.Animators.MaskDude },

            { Constants.Selectable.Hero, Constants.Path.Animators.Hero }
        };

        foreach (var item in controller_path)
        {
            AnimatorControllers.Add(
                item.Key,
                Resources.Load<RuntimeAnimatorController>(Constants.Path.Animator_Player + item.Value)
            );
        }

        Inited = true;
    }
}
