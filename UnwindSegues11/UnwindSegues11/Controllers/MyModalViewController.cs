using System;

using UIKit;

namespace UnwindSegues11.Controllers
{
    public partial class MyModalViewController : BaseViewController
    {
        #region Constructors
        public MyModalViewController(IntPtr handle) : base(handle)
        {
        }
        #endregion

        #region Controller Life
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            Message = $"My message is: I'm coming from {nameof(MyModalViewController)}";
        }
        #endregion

        #region User interactions

        partial void BtnClose(Foundation.NSObject sender)
        {
            DismissViewController(true,null);
        }

        partial void BtnDoUnwind(Foundation.NSObject sender)
        {
            PerformSegue("PrepareForUnwind", this);
        }

        #endregion

    }
}

