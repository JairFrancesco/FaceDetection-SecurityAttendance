
//Detección de rostros aplicado en un sistema de seguridad y en la toma automatica de lista de asistentes 
//Usando EmguCV cross platform .Net wrapper para C# .NET
//Integrantes : Jair Huaman Canqui
//            : Miguel Ravelo Jove

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;

namespace DeteccionRostros
{
    public partial class FrmPrincipal : Form
    {
        //Declaración de todas las variables, vectores and haarcascades
        Image<Bgr, Byte> currentFrame;
        Image<Bgr, Byte> currentFrameSecurity;
        Capture grabber;
        Capture grabberSecurity;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels= new List<string>();
        List<string> NamePersons = new List<string>();
        List<int> CUIDetecteds = new List<int>();
        int ContTrain, NumLabels, t;
        string name,apellidos, names = null;
        int CUI, rostrosDetectados;
        BindingSource bindingSourceModems;
        private int ContadorTiempo = 0;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private bool primerRostroDetectado = true;

        //Procedimiento para iniciar la lista de asistentes
        private void initListView()
        {
            // Agregar las columnas
            lvEstudiantes.Columns.Add("CUI", 150);
            lvEstudiantes.Columns.Add("Nombres", 150);
            lvEstudiantes.Columns.Add("Apellidos", 150);
        }


        private void iniciarTimer() {
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            //timer.Start();
        }

        //Procedimiento para obtener los Modems conectados a la PC y enlazarlos al combobox
        private void cargarModems() {
            GSMcom gsmControl = new GSMcom();
            bindingSourceModems = new BindingSource();
            bindingSourceModems.DataSource = gsmControl.ListarModemsConectados();

            //Cargar la lista de puertos conectados
            cbModems.DataSource = bindingSourceModems.DataSource;
            cbModems.DisplayMember = "Description";
            cbModems.ValueMember = "Name";
        }

        //Esta función se ejecuta cada 1 segundo y aumenta el contador para verificar que 
        //ya pasaron 5 minutos para enviar el siguiente SMS
        private void timer_Tick(object sender, EventArgs e)
        {
            ContadorTiempo++;
        }


        //Funcion para enviar un SMS, entra el numero de celular y el puerto al que esta conectado el GSM Modem
        private void enviarMensaje(string celular, string COM) {
            try
            {
                SerialPort sp = new SerialPort();
                sp.PortName = cbModems.SelectedValue.ToString();
                sp.Open();
                sp.WriteLine("AT" + Environment.NewLine);
                Thread.Sleep(200);
                sp.WriteLine("AT+CMGF=1" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CMGS=\"" + celular + "\"" + Environment.NewLine);
                Thread.Sleep(200);
                sp.WriteLine(txtMensaje.Text + Environment.NewLine);
                Thread.Sleep(100);
                sp.Write(new byte[] { 26 }, 0, 1);
                Thread.Sleep(100);
                var response = sp.ReadExisting();
                if (response.Contains("ERROR"))
                {
                    MessageBox.Show("Error al enviar el mensaje!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    MessageBox.Show("Mensaje Enviado !", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                sp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        //Evento del boton iniciar seguridad
        private void btnInitSecurity_Click(object sender, EventArgs e)
        {
            //Inicializar la captura de al WebCam
            grabberSecurity = new Capture();
            grabberSecurity.QueryFrame();
            //Inicializar evento FrameGraber
            Application.Idle += new EventHandler(FrameGrabberSecurity);
            btnInitSecurity.Enabled = false;
        }

        //Evento del boton Exportar
        private void btnExport2Excel_Click(object sender, EventArgs e)
        {
            Export2Excel();
        }


        //Evento que se ejecuta al iniciar el programa
        public FrmPrincipal()
        {
            InitializeComponent();
            initListView();
            iniciarTimer();
            cargarModems();
            //Cargar haarcascades para la detección de rostros
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            try
            {
                //Cargar los rostros previamente entrenados y labes para cada imagen
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels+1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }
            
            }
            catch(Exception e)
            {
                MessageBox.Show("En caso use la opción de tomar lista aun no hay Nada en la base de datos, Por favor agrege al menos un rostro(Agrege un estudiante con el boton Guardar).", "Cargar Rostros entrenados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        //Iniciar la captura de la webcam e iniciar la detección de rostros
        private void btnTomarLista_Click(object sender, EventArgs e)
        {
            //Inicializar la captura de al WebCam
            grabber = new Capture();
            grabber.QueryFrame();
            //Inicializar evento FrameGraber
            Application.Idle += new EventHandler(FrameGrabber);
            btnTomarLista.Enabled = false;
        }


        //Evento del boton Guardar para Guardar un rostro junto con su CUI y nombres y apellidos
        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            try
            {
                //Contador de Rostros entrenados
                ContTrain = ContTrain + 1;

                //Obtener un Frame en escala de grises del dispositivo de captura(Webcam)
                gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Detector de rostros
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                    face,
                    1.2,
                    10,
                    Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                    new Size(20, 20));

                //Acción para cada elemento detectados
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }

                //Cambiar tamaño del rostro detectado para forzar a comprar el mismo tamaño con la
                //imagen de prueba con el metodo de inperpolacion cubica
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                trainingImages.Add(TrainedFace);
                labels.Add(txtCUI.Value + "," + txtNombres.Text + "," + txtApellidos.Text);

                //Mostrar rostro agregado en escala de grises
                imgBoxEstudianteNuevo.Image = TrainedFace;

                //Escribir el numero de rostros entrenados en un archivo de texto para su posterior carga
                File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                //Escribir las etiquetas de los rostros entrenados en un archivo de texto para su posterior carga
                for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                {
                    trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                    File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                }

                MessageBox.Show(txtNombres.Text + "´s Rostros detectados y agregados", "Entrenamiento exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("No se ha detectado ningun Rostro", "Entrenamiento fallido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //Frame Grabber para la toma de lista de asistentes
        void FrameGrabber(object sender, EventArgs e)
        {
            lblRostrosDetectados.Text = "0";
            NamePersons.Add("");

            //Obtener el actual Frame del dispositivo de captura
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convertirlo a Escala de grises
            gray = currentFrame.Convert<Gray, Byte>();

            //Detector de Rostros
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                  face,
                  1.2,
                  10,
                  Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                  new Size(20, 20));

            //Accion para cada elemento detectado
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //Dibujar el rostro detectado en el 0th (gray) channel con el color azul
                currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);

                if (trainingImages.ToArray().Length != 0)
                {
                    //TermCriteria para reconocimiento de rostros con numeros de imagenes entrenadas como maxIteration
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                    //Reconocedor Eigen face 
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                        trainingImages.ToArray(),
                        labels.ToArray(),
                        3000,
                        ref termCrit);

                    string[] tmpData = recognizer.Recognize(result).Split(',');
                    name = tmpData[1];
                    apellidos = tmpData[2];

                    //Manejar CUIs y Agregar a lista de asistentes.
                    CUI = int.Parse(tmpData[0]);

                    bool exists = false;
                    //verificar si el CUI ya fue detectado
                    foreach (int unitCUI in CUIDetecteds)
                    {
                        if (CUI == unitCUI) {
                            exists = true;
                        }
                    }
                    if (!exists) {
                        CUIDetecteds.Add(CUI);
                        string[] arr = new string[3];
                        ListViewItem itm;
                        //Agregar items a la lista de asistentes
                        arr[0] = CUI.ToString();
                        arr[1] = name;
                        arr[2] = apellidos;
                        itm = new ListViewItem(arr);
                        lvEstudiantes.Items.Add(itm);
                    }
                    
                    //Dibujar la etiqueta para cada rostro detectado y reconocido
                    currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
                }

                NamePersons[t-1] = name;
                NamePersons.Add("");
                
                //Establecer el numero de rostros detectados en la escena
                lblRostrosDetectados.Text = facesDetected[0].Length.ToString();

            }
            t = 0;

            //Concatenación de nombres de personas reconocidas
            for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                names = names + NamePersons[nnn] + ", ";
            }
            //Mostrar los rostros procesados y reconocidos
            imageBoxFrameGrabber.Image = currentFrame;
            lblPresentesEscene.Text = names;
            names = "";
            //Limpiar la list(vector) de nombres
            NamePersons.Clear();
        }

        //Frame Grabber para el mini sistema de seguridad con notificación
        void FrameGrabberSecurity(object sender, EventArgs e)
        {
            try
            {
                //Obtener el actual Frame del dispositivo de captura
                currentFrameSecurity = grabberSecurity.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //Convertirlo a Escala de grises
                gray = currentFrameSecurity.Convert<Gray, Byte>();
                //Detector de Rostros
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                      face,
                      1.2,
                      10,
                      Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                      new Size(20, 20));

                bool messageSend = false;
                //Accion para cada elemento detectado
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    t = t + 1;
                    result = currentFrameSecurity.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    //Dibujar el rostro detectado en el 0th (gray) channel con el color azul
                    currentFrameSecurity.Draw(f.rect, new Bgr(Color.Red), 2);
                    //Establecer el numero de rostros detectados en la escena
                    rostrosDetectados = facesDetected[0].Length;
                    if (primerRostroDetectado && !messageSend)
                    {
                        timer.Start();
                        primerRostroDetectado = false;
                        enviarMensaje(txtCelular.Text, cbModems.SelectedValue.ToString());
                        messageSend = true;
                    }

                    //Envia un SMS al detectar algun rostro y espera 5 minutos antes de enviar el
                    //siguiente SMS en caso detecte algun rostro.
                    //Es necesario para que no envie SMS a cada segundo
                    if (ContadorTiempo >= 300 && !messageSend)
                    {
                        enviarMensaje(txtCelular.Text, cbModems.SelectedValue.ToString());
                        messageSend = true;
                        ContadorTiempo = 0;
                    }
                }
                t = 0;
                //Mostrar los rostros procesados y reconocidos
                imgBoxFrameGrabberSecurity.Image = currentFrameSecurity;
            }
            catch (NullReferenceException nullex)
            {
                MessageBox.Show("No se ha detectado un puerto COM o un Celular");
                primerRostroDetectado = true;
                ContadorTiempo = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Función para exportar ListView a Excel
        private void Export2Excel()
        {
            try
            {
                string[] st = new string[lvEstudiantes.Columns.Count];
                DirectoryInfo di = new DirectoryInfo(@"c:\DeteccionRostros\");
                if (di.Exists == false)
                    di.Create();
                StreamWriter sw = new StreamWriter(@"c:\DeteccionRostros\" + "Asistentes" + ".xls", false);
                sw.AutoFlush = true;
                for (int col = 0; col < lvEstudiantes.Columns.Count; col++)
                {
                    sw.Write("\t" + lvEstudiantes.Columns[col].Text.ToString());
                }

                int rowIndex = 1;
                int row = 0;
                string st1 = "";
                for (row = 0; row < lvEstudiantes.Items.Count; row++)
                {
                    if (rowIndex <= lvEstudiantes.Items.Count)
                        rowIndex++;
                    st1 = "\n";
                    for (int col = 0; col < lvEstudiantes.Columns.Count; col++)
                    {
                        st1 = st1 + "\t" + "'" + lvEstudiantes.Items[row].SubItems[col].Text.ToString();
                    }
                    sw.WriteLine(st1);
                }
                sw.Close();
                FileInfo fil = new FileInfo(@"c:\DeteccionRostros\" + "Asistentes" + ".xls");
                if (fil.Exists == true)
                    MessageBox.Show("Proceso Completo", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}