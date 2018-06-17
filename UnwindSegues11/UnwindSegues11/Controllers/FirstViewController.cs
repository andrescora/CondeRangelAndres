using System;
using Foundation;
using UIKit;

namespace UnwindSegues11.Controllers
{
    public partial class FirstViewController : BaseViewController
    {
        #region Contructor
        public FirstViewController(IntPtr handle) : base(handle)
        {
        }
        #endregion

        #region Controller Life
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            Message = $"My message is: I'm coming from {nameof(FirstViewController)}";
        }
        #endregion

        #region Unwind segues

        public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
        }

        [Action ("prepareForUnwindToFirstViewController:")]
        void PrepareForUnwindToFirstViewController(UIStoryboardSegue segue)
        {
            var sourceViewController = segue.SourceViewController as BaseViewController;
            //Siempre se puede hacer cast para arriba del PADRE pero nunca para abajo. 
            Console.WriteLine(sourceViewController.Message);
        }

        [Action("prepareForUnwind:")]
        void PrepareForUnwind(UIStoryboardSegue segue)
        {
            var sourceViewController = segue.SourceViewController as BaseViewController;
            //Siempre se puede hacer cast para arriba del PADRE pero nunca para abajo. 
            Console.WriteLine(sourceViewController.Message);
        }

        #endregion



    }
}

