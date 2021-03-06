// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;

namespace ex_par_2
{
	public partial class CustomTableViewCell : UITableViewCell
	{
        public static readonly NSString Key = new NSString(nameof(CustomTableViewCell));

        #region Properties

        public UIImage ProfileImage
        {
            get => imagen.Image;
            set => imagen.Image = value;
        }

        public string SomeText
        {
            get => LblTweet.Text;
            set => LblTweet.Text = value;
        }

        public string Retweet
        {
            get;
            set;
        }

        public NSIndexPath IndexPath
        {
            get;
            set;
        }

        #endregion

        #region Constructores
        public CustomTableViewCell(IntPtr handle) : base(handle)
        {
            
        }
		#endregion
	}
}
