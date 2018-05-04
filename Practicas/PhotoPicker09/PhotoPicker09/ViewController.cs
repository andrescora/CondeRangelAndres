using System;
using Photos;
using UIKit;
using Foundation;
using AVFoundation;

namespace PhotoPicker09
{
    public partial class ViewController : UIViewController, IUIImagePickerControllerDelegate
    {

        #region class variables

        UITapGestureRecognizer profileTapGesture; 
        UITapGestureRecognizer coverTapGesture;

        bool editModeEnable; 

        #endregion

        #region constructors
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        #endregion

        #region controller life cycle
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            InitializeComponents();

            btnEdit.Clicked += BtnEdit_Clicked;

        }
        #endregion

        #region User Interactions
        void ShowOptions(UITapGestureRecognizer gesture)
        {
            //var imagePickerController = new UIImagePickerController
            //{
             //   SourceType = UIImagePickerControllerSourceType.PhotoLibrary
            //};

            UIAlertController alert = UIAlertController.Create(null,null,UIAlertControllerStyle.ActionSheet);
            alert.AddAction(UIAlertAction.Create("Open photo Library", UIAlertActionStyle.Default,TryOpenGallery));
            alert.AddAction(UIAlertAction.Create("Create a photo", UIAlertActionStyle.Default,TryOpenCamera));
            alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null));

            PresentViewController(alert, true, null);
        }

        void BtnEdit_Clicked(object sender, EventArgs e)
        {
            editModeEnable = !editModeEnable;

            btnEdit.Title = editModeEnable ? "Done" : "Edit";
            profileTapGesture.Enabled = coverTapGesture.Enabled = editModeEnable;
            lblInferior.Hidden = lblSuperior.Hidden = !editModeEnable;

        }

        #endregion


        #region UIImage Picker Controller Delegate

        [Export("imagePickerController:didFinishPickingMediaWithInfo:")]
        public void FinishedPickingMedia(UIImagePickerController picker, NSDictionary info)
        {
            var image = info[UIImagePickerController.OriginalImage] as UIImage;
            imgSuperior.Image = image;
            picker.DismissViewController(true, null);
        }

        [Export("imagePickerControllerDidCancel:")]
        public void Canceled(UIImagePickerController picker)
        {
            picker.DismissViewController(true, null);
        }

        #endregion
       

        #region Photo Library
        
        void TryOpenGallery(UIAlertAction obj){

            if (!UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.PhotoLibrary))
            {
                return;
            }

            CheckPhotoLibraryAuthorizationsStatus(PHPhotoLibrary.AuthorizationStatus);
        }

        void CheckPhotoLibraryAuthorizationsStatus(PHAuthorizationStatus authorizationStatus)
        {
            switch (authorizationStatus)
            {
                case PHAuthorizationStatus.NotDetermined:
                    // TODO: Pedir permiso para acceder
                    PHPhotoLibrary.RequestAuthorization(CheckPhotoLibraryAuthorizationsStatus);
                    break;
                case PHAuthorizationStatus.Restricted:
                    // TODO: Mostrar un mensaje diciendo que está restringido
                    InvokeOnMainThread(() => { ShowMessage("The resource is not available", "El recuerso no esa dispii", NavigationController);});
                    break;
                case PHAuthorizationStatus.Denied:
                    // TODO: Mostrar un mensaje diciendo que el usuario denego
                    InvokeOnMainThread(() => { ShowMessage("The resource is not available", "El recuerso no esta disponible", NavigationController);});
                    break;
                case PHAuthorizationStatus.Authorized:
                    // TODO: Abrir galeria
                    InvokeOnMainThread(() =>
                    {
                        var imagePickerController = new UIImagePickerController
                        {
                            SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                            Delegate = this
                        };
                        PresentViewController(imagePickerController, true, null);
                    });

                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Camera

        void TryOpenCamera(UIAlertAction obj)
        {

            if (!UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera))
            {
                InvokeOnMainThread(() => { ShowMessage("ERROR", "No se puede acceder a la camara", NavigationController); });
            }
            else
            {
                CheckCameraAuthorizationsStatus(AVCaptureDevice.GetAuthorizationStatus(AVMediaType.Video));
            }

        }

        void CheckCameraAuthorizationsStatus(AVAuthorizationStatus authorizationStatus)
        {
            switch (authorizationStatus)
            {
                case AVAuthorizationStatus.NotDetermined:
                    // TODO: Pedir permiso para acceder

                    AVCaptureDevice.RequestAccessForMediaType(AVMediaType.Video, (bool accessGranted)=> CheckCameraAuthorizationsStatus(AVCaptureDevice.GetAuthorizationStatus(AVMediaType.Video)));
                    

                    break;
                case AVAuthorizationStatus.Restricted:
                    // TODO: Mostrar un mensaje diciendo que está restringido
                    InvokeOnMainThread(() => { ShowMessage("The resource is not available", "La camara no esa disponible", NavigationController); });
                    break;
                case AVAuthorizationStatus.Denied:
                    // TODO: Mostrar un mensaje diciendo que el usuario denego
                    InvokeOnMainThread(() => { ShowMessage("The resource is not available", "La camara no esta disponible", NavigationController); });
                    break;
                case AVAuthorizationStatus.Authorized:
                    // TODO: Abrir galeria
                    InvokeOnMainThread(() =>
                    {
                        var imagePickerController = new UIImagePickerController
                        {
                            SourceType = UIImagePickerControllerSourceType.Camera,
                            Delegate = this
                        };
                        PresentViewController(imagePickerController, true, null);
                    });

                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Internal Functionality

        void InitializeComponents()
        {
            lblSuperior.Hidden = lblInferior.Hidden = true;

            profileTapGesture = new UITapGestureRecognizer(ShowOptions) { Enabled = false };
            viewSuperior.AddGestureRecognizer(profileTapGesture);

            coverTapGesture = new UITapGestureRecognizer(ShowOptions) { Enabled = false };
            viewInferior.AddGestureRecognizer(coverTapGesture);
        }

        void ShowMessage(string title, string message, UIViewController fromViewController)
        {

            UIAlertController alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

            fromViewController.PresentViewController(alert, true, null);
        }

        #endregion
    }
}
