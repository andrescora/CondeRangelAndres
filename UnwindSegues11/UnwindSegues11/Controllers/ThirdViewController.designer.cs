// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace UnwindSegues11.Controllers
{
	[Register ("ThirdViewController")]
	partial class ThirdViewController
	{
		[Outlet]
		UIKit.UISwitch swtUnwindHere { get; set; }

		[Action ("BtnDoUnwind:")]
		partial void BtnDoUnwind (Foundation.NSObject sender);

		[Action ("BtnGoFirst_TouchUpInside:")]
		partial void BtnGoFirst_TouchUpInside (Foundation.NSObject sender);

		[Action ("GoToModal_TouchUpInside:")]
		partial void GoToModal_TouchUpInside (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (swtUnwindHere != null) {
				swtUnwindHere.Dispose ();
				swtUnwindHere = null;
			}
		}
	}
}
