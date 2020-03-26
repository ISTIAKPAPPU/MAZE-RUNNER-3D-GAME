using HutongGames.PlayMaker;

namespace FilmstormTouch.Playmaker
{
    [ActionCategory(FilmstormActionCategory.CategoryName)]
    [Tooltip("Sends an Event when a Button is released.")]
    public class FilmstormInputGetButtonUp : FsmStateAction
    {
        [RequiredField]
        [Tooltip("The name of the button. Set in the Cn Input README file.")]
        public FsmString ButtonName;

        [Tooltip("Event to send if the button is released.")]
        public FsmEvent SendEvent;

        [UIHint(UIHint.Variable)]
        [Tooltip("Set to True if the button is released.")]
        public FsmBool StoreResult;

        public override void Reset()
        {
            ButtonName = "Fire1";
            SendEvent = null;
            StoreResult = null;
        }

        public override void OnUpdate()
        {
            var buttonUp = FilmstormTouchInputManager.GetButtonUp(ButtonName.Value);

            if (buttonUp)
            {
                Fsm.Event(SendEvent);
            }

            StoreResult.Value = buttonUp;
        }
    }
}