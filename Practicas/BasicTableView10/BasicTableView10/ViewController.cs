using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace BasicTableView10
{
    public partial class ViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate
    {

        #region Global Variables

        //Lista de resultados
        public List<string> list;
        //Cual será la tabla de multiplicar
        public int Tabla;
        //Hasta que numero se multipicara
        public int Veces;
        //TextField del alert
        UITextField texto;
        //Operacion en string
        public string Operacion;

        #endregion

        #region Constructors
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        #endregion

        #region Controller Life
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            TableView.DataSource = this; 
            TableView.Delegate = this;

            list = new List<string>(); 

        }
        #endregion

        #region Interactions

        partial void BtnAdd_Clicked(NSObject sender)
        {
            ShowOptions();
        }

        void AlertError(string Mensaje)
        {
            var AlertController = UIAlertController.Create("ERROR", $"No se permite el valor especificado: {Mensaje}", UIAlertControllerStyle.Alert);
            AlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Cancel, null));
            PresentViewController(AlertController, true, null);
        }

        void ShowAlert()
        {
            var AlertController = UIAlertController.Create("Seleccione", "Multiplicar hasta...", UIAlertControllerStyle.Alert);

            //Add Actions
            AlertController.AddTextField(HandleAction);
            AlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, obtenerTxt));
            AlertController.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null));

            //Present Alert
            PresentViewController(AlertController, true, null);
        }

        void obtenerTxt(UIAlertAction obj)
        {

            try
            {
                int resultado;

                Veces = int.Parse(texto.Text);
                Console.WriteLine($"El texto es: {Veces}");

                //Agregamos la lista:
                list = new List<string>();

                for (int i = 1; i <= Veces; i++)
                {
                    resultado = Tabla * i;
                    Operacion = $"{i} = {resultado}";
                    list.Add(Operacion);
                }

                //Recargamos la tabla
                InvokeOnMainThread(TableView.ReloadData);
            }
            catch (Exception ex)
            {
                AlertError(ex.Message);
            }

        }

        //Igualamos nuestro txt al txt del ALERT
        void HandleAction(UITextField obj)
        {
            texto = obj; 
        }


        void ShowOptions()
        {
            UIAlertController alert = UIAlertController.Create("Tablas de Multiplicar", "Seleccione la tabla:", UIAlertControllerStyle.ActionSheet);
            alert.AddAction(UIAlertAction.Create("1", UIAlertActionStyle.Default, SetTabla));
            alert.AddAction(UIAlertAction.Create("2", UIAlertActionStyle.Default, SetTabla));
            alert.AddAction(UIAlertAction.Create("3", UIAlertActionStyle.Default, SetTabla));
            alert.AddAction(UIAlertAction.Create("4", UIAlertActionStyle.Default, SetTabla));
            alert.AddAction(UIAlertAction.Create("5", UIAlertActionStyle.Default, SetTabla));
            alert.AddAction(UIAlertAction.Create("6", UIAlertActionStyle.Default, SetTabla));
            alert.AddAction(UIAlertAction.Create("7", UIAlertActionStyle.Default, SetTabla));
            alert.AddAction(UIAlertAction.Create("8", UIAlertActionStyle.Default, SetTabla));
            alert.AddAction(UIAlertAction.Create("9", UIAlertActionStyle.Default, SetTabla));
            alert.AddAction(UIAlertAction.Create("10", UIAlertActionStyle.Default, SetTabla));
            alert.AddAction(UIAlertAction.Create("11", UIAlertActionStyle.Default, SetTabla));
            alert.AddAction(UIAlertAction.Create("12", UIAlertActionStyle.Default, SetTabla));
            alert.AddAction(UIAlertAction.Create("13", UIAlertActionStyle.Default, SetTabla));
            alert.AddAction(UIAlertAction.Create("14", UIAlertActionStyle.Default, SetTabla));
            alert.AddAction(UIAlertAction.Create("15", UIAlertActionStyle.Default, SetTabla));
            alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null));

            PresentViewController(alert, true, null);
        }


        void SetTabla(UIAlertAction obj)
        {
            Tabla = int.Parse(obj.Title);

            //Mostramos la alerta.
            ShowAlert(); 
        }

        #endregion


        #region UITableView Data Source

        // Los opcionales siempre llevan export.
        [Export("numberOfSectionsInTableView:")]
        public nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public nint RowsInSection(UITableView tableView, nint section)
        {
            //switch (section)
            //{
            //    case 0:
            //        return 3; 
            //    case 1:
            //        return 10; 
            //    case 2:
            //        return 1;
            //}
            return list.Count;
        }

        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            //indexPath guarda las coordenadas de la tabla. 
            var cell = tableView.DequeueReusableCell("BasicTableViewCell", indexPath);
            cell.TextLabel.Text = $"{Tabla} x {list[indexPath.Row]}";

            return cell;
        }

        #endregion

        #region UITableView Delegate


        #endregion
    }
}
