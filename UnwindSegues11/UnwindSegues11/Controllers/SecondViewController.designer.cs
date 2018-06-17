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
	[Register ("SecondViewController")]
	partial class SecondViewController
	{
		[Outlet]
		UIKit.UISwitch swtUnwindHere { get; set; }

		[Action ("BtnGoToThird_TouchUpInside:")]
		partial void BtnGoToThird_TouchUpInside (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (swtUnwindHere != null) {
				swtUnwindHere.Dispose ();
				swtUnwindHere = null;
			}
		}
	}
}
