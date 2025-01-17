﻿using HutongGames.PlayMaker;

namespace FilmstormTouch.Playmaker
{
    [ActionCategory(FilmstormActionCategory.CategoryName)]
    [HutongGames.PlayMaker.Tooltip("Gets the pressed state of the specified Button and stores it in a Bool Variable. See Filmstorm Controls README file.")]
    public class FilmstormInputGetButton : FsmStateAction
    {
        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The name of the button. Set in the Unity Input Manager and in Filmstorm Input Controls.")]
        public FsmString ButtonName;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [HutongGames.PlayMaker.Tooltip("Store the result in a bool variable.")]
        public FsmBool StoreResult;

        [HutongGames.PlayMaker.Tooltip("Repeat every frame.")]
        public bool EveryFrame;

        public override void Reset()
        {
            ButtonName = "Fire1";
            StoreResult = null;
            EveryFrame = true;
        }

        public override void OnEnter()
        {
            DoGetButton();

            if (!EveryFrame)
            {
                Finish();
            }
        }

        public override void OnUpdate()
        {
            DoGetButton();
        }

        void DoGetButton()
        {
            StoreResult.Value = FilmstormTouchInputManager.GetButton(ButtonName.Value);
        }
    }
}