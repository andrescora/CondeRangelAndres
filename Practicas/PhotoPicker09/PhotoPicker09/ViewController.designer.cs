// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace PhotoPicker09
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIBarButtonItem btnEdit { get; set; }

		[Outlet]
		UIKit.UIImageView imgInferior { get; set; }

		[Outlet]
		UIKit.UIImageView imgSuperior { get; set; }

		[Outlet]
		UIKit.UILabel lblInferior { get; set; }

		[Outlet]
		UIKit.UILabel lblSuperior { get; set; }

		[Outlet]
		UIKit.UIView viewInferior { get; set; }

		[Outlet]
		UIKit.UIView viewSuperior { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnEdit != null) {
				btnEdit.Dispose ();
				btnEdit = null;
			}

			if (lblSuperior != null) {
				lblSuperior.Dispose ();
				lblSuperior = null;
			}

			if (lblInferior != null) {
				lblInferior.Dispose ();
				lblInferior = null;
			}

			if (imgInferior != null) {
				imgInferior.Dispose ();
				imgInferior = null;
			}

			if (imgSuperior != null) {
				imgSuperior.Dispose ();
				imgSuperior = null;
			}

			if (viewInferior != null) {
				viewInferior.Dispose ();
				viewInferior = null;
			}

			if (viewSuperior != null) {
				viewSuperior.Dispose ();
				viewSuperior = null;
			}
		}
	}
}
