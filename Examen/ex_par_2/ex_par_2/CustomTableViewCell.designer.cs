// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ex_par_2
{
	[Register ("CustomTableViewCell")]
	partial class CustomTableViewCell
	{
		[Outlet]
		UIKit.UIImageView imagen { get; set; }

		[Outlet]
		UIKit.UILabel LblTweet { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imagen != null) {
				imagen.Dispose ();
				imagen = null;
			}

			if (LblTweet != null) {
				LblTweet.Dispose ();
				LblTweet = null;
			}
		}
	}
}
