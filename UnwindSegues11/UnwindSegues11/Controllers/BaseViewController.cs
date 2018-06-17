using System;

using UIKit;

namespace UnwindSegues11
{
    public partial class BaseViewController : UIViewController
    {

        #region Propperties

        public string Message { get; set; }

        #endregion

        #region Contructors
        public BaseViewController(IntPtr handle) : base(handle)
        {
        }
        #endregion


    }
}

