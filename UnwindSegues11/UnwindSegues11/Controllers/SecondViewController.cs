using System;
using Foundation;
using UIKit;

namespace UnwindSegues11.Controllers
{
    public partial class SecondViewController : BaseViewController
    {
        #region Constructors
        public SecondViewController(IntPtr handle) : base(handle)
        {
        }
        #endregion

        #region Controller Life Cycle
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            Message = $"My message is: I'm coming from {nameof(SecondViewController)}";
        }
        #endregion

        #region User interactions
        partial void BtnGoToThird_TouchUpInside(Foundation.NSObject sender)
        {
            var viewController = Storyboard.InstantiateViewController("ThirdViewController");
            NavigationController.PushViewController(viewController, true);
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
            if (RespondsToSelector(segueAction))
            {
                return swtUnwindHere.On;
            }

            return true;
        }

        #endregion


    }
}

