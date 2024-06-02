namespace Assets.Scripts.StatelessData
{
    internal class Constants
    {
        public struct GameObjects
        {
            public const string Player = "Player";
            public const string Cherry = "Cherry";
        }

        public struct Selectable
        {
            public const string VirtualGuy = "HeroVirtualGuy";
            public const string PinkMan = "HeroPinkMan";
            public const string NinjaFrog = "HeroNinjaFrog";
            public const string MaskDude = "HeroMaskDude";
        }

        public struct Path
        {
            public const string Animator_Player = "Animation/Player/";

            public struct Animators
            {
                public const string VirtualGuy = "Player_01";
                public const string PinkMan = "Player_02";
                public const string NinjaFrog = "Player_03";
                public const string MaskDude = "Player_04";
            }
        }
    }
}
