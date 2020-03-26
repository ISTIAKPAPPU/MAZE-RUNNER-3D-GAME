using HutongGames.PlayMaker;

namespace FilmstormTouch.Playmaker
{
    [ActionCategory(FilmstormActionCategory.CategoryName)]
    [Tooltip("Sends an Event when a Button is pressed.")]
    public class FilmstormInputGetButtonDown : FsmStateAction
    {
        [RequiredField]
        [Tooltip("The name of the button. Set in the Unity Input Manager.")]
        public FsmString ButtonName;

        [Tooltip("Event to send if the button is pressed.")]
        public FsmEvent SendEvent;

        [Tooltip("Set to True if the button is pressed.")]
        [UIHint(UIHint.Variable)]
        public FsmBool StoreResult;

        public override void Reset()
        {
            ButtonName = "Fire1";
            SendEvent = null;
            StoreResult = null;
        }

        public override void OnUpdate()
        {
            var buttonDown = FilmstormTouchInputManager.GetButtonDown(ButtonName.Value);

            if (buttonDown)
            {
                Fsm.Event(SendEvent);
            }

            StoreResult.Value = buttonDown;
        }
    }
}