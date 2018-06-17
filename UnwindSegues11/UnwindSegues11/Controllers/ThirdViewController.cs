using System;
using Foundation;
using UIKit;

namespace UnwindSegues11.Controllers
{
    public partial class ThirdViewController : BaseViewController
    {
        #region Constructor
        public ThirdViewController(IntPtr handle) : base(handle)
        {
        }
        #endregion

        #region Controller Life
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            Message = $"My message is: I'm coming from {nameof(ThirdViewController)}";
        }
        #endregion

        #region User interactions
        //Abrir modal
        partial void GoToModal_TouchUpInside(Foundation.NSObject sender)
        {
            var viewController = Storyboard.InstantiateViewController("MyModalViewController");
            PresentViewController(viewController, true, null);
        }

        //Abrir 1ra
        partial void BtnGoFirst_TouchUpInside(Foundation.NSObject sender)
        {
            PerformSegue("PrepareForUnwindToFirstViewController",this);
        }

        partial void BtnDoUnwind(NSObject sender)
        {
            PerformSegue("PrepareForUnwind", this);
        }

        #endregion

        #region Unwind segues
        [Action("prepareForUnwind:")]
        void PrepareForUnwind(UIStoryboardSegue segue)
        {
            var sourceViewController = segue.SourceViewController as BaseViewController;
            //Siempre se puede hacer cast para arriba del PADRE pero nunca para abajo. 
            Console.WriteLine(sourceViewController.Message);
        }

        public override bool CanPerformUnwind(ObjCRuntime.Selector segueAction, UIViewController fromViewController, NSObject sender)
        {
            if(RespondsToSelector(segueAction)){
                return swtUnwindHere.On;
            }

            return true;
        }

        #endregion
    }
}

