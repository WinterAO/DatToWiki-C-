using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DatToWiki {
    public partial class frmMain : Form {

        string rutaDats;
        const int NUMCLASES = 12;

        public frmMain() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {

            if (txtRutaDats.Text.Length < 1) {
                BuscarCarpeta();
            }

            if (radioButton6.Checked) { //Cascos
                this.ConvertObj(17);

            } else if (radioButton5.Checked) { //Armaduras
                this.ConvertObj(3);

            } else if (radioButton2.Checked) { //Escudos
                this.ConvertObj(16);

            } else if (radioButton1.Checked) { //Armas
                this.ConvertObj(2);

            } else if (radioButton4.Checked) { // Hechizos
                this.ConvertHechizos();

            } else if (radioButton3.Checked) { // NPC's Hostiles
                this.ConvertNPCs();
            }
        }

        private void ConvertObj(int objType) {
            string clase;
            int tipoObj;

            string rutaArchivo = rutaDats + "\\obj.dat";

            if (!File.Exists(rutaArchivo)) {
                txtResultado.Text = "Nose ha encontrado el archivo de obj.dat";
            }

            string resultado = "{| class='wikitable'" + Environment.NewLine;

            //Creamos el objeto
            IniParser parser = new IniParser();

            //Cargamos el archivo
            parser.Load(rutaArchivo);

            //Leemos el total de objetos
            int numOBJs = int.Parse(parser.GetValue("INIT", "NumOBJs"));

            if (numOBJs != null) {
                // Preparamos la cabecera de la tabla
                resultado += "|-" + Environment.NewLine;
                resultado += "!Imagen !! Nombre !! Min !! Max !! Nivel !! Precio !! Clases no Permitidas" + Environment.NewLine;
                resultado += "|-" + Environment.NewLine;

                for (int i = 1; i <= numOBJs; i++) {

                    string objTypeStr = parser.GetValue("OBJ" + i, "ObjType");

                    if (!string.IsNullOrEmpty(objTypeStr)) {
                        tipoObj = int.Parse(objTypeStr);

                    } else {
                        tipoObj = 0;

                    }

                    // ¿Es un casco?
                    if (tipoObj == objType) {

                        resultado += "|[[Archivo:" + parser.GetValue("OBJ" + i, "GrhIndex") + ".png|thumb]] || " + parser.GetValue("OBJ" + i, "Name") + " || " + parser.GetValue("OBJ" + i, "MinDef") + " || " + parser.GetValue("OBJ" + i, "MaxDef");
                        resultado += " || " + parser.GetValue("OBJ" + i, "Nivel") + " || " + parser.GetValue("OBJ" + i, "Valor") + "||";

                        for (int j = 1; j <= NUMCLASES; j++) {
                            clase = parser.GetValue("OBJ" + i, "CP" + j);

                            if (clase != null) {
                                resultado += clase + ", ";
                            }
                        }

                        resultado += Environment.NewLine + "|-" + Environment.NewLine;

                    }

                }

                resultado += "}";
                txtResultado.Text = resultado;

            }
        }

        private void ConvertHechizos() {

            string rutaArchivo = rutaDats + "\\hechizos.dat";

            if (!File.Exists(rutaArchivo)) {
                txtResultado.Text = "Nose ha encontrado el archivo de hechizos.dat";
            }

            string resultado = "{| class='wikitable'" + Environment.NewLine;

            //Creamos el objeto
            IniParser parser = new IniParser();

            //Cargamos el archivo
            parser.Load(rutaArchivo);

            //Leemos el total de objetos
            int numSpells = int.Parse(parser.GetValue("INIT", "NumeroHechizos"));

            if (numSpells > 0) {

                // Preparamos la cabecera de la tabla
                resultado += "|-" + Environment.NewLine;
                resultado += "!Hechizo !! Palabras Mágicas !! Efecto !! Maná !! Energía !! Skills en Magia" + Environment.NewLine;
                resultado += "|-" + Environment.NewLine;

                for (int i = 1; i <= numSpells; i++) {

                    resultado += parser.GetValue("HECHIZO" + i, "Nombre") + " || " + parser.GetValue("HECHIZO" + i, "PalabrasMagicas") + " || " + parser.GetValue("HECHIZO" + i, "Desc") + " || " + parser.GetValue("HECHIZO" + i, "ManaRequerido") + " || " + parser.GetValue("HECHIZO" + i, "StaRequerido") + " || " + parser.GetValue("HECHIZO" + i, "MinSkill");
                    resultado += Environment.NewLine + "|-" + Environment.NewLine;

                }

                resultado += "|}";
                txtResultado.Text = resultado;

            }

        }

        private void ConvertNPCs() {
            int tipoNPC;

            string rutaArchivo = rutaDats + "\\npcs.dat";

            if (!File.Exists(rutaArchivo)) {
                txtResultado.Text = "Nose ha encontrado el archivo de npcs.dat";
            }

            string resultado = "{| class='wikitable'" + Environment.NewLine;

            //Creamos el objeto
            IniParser parser = new IniParser();

            //Cargamos el archivo
            parser.Load(rutaArchivo);

            //Leemos el total de objetos
            int numNPCs = int.Parse(parser.GetValue("INIT", "NumNPCs"));

            if (numNPCs != null) {
                // Preparamos la cabecera de la tabla
                resultado += "|-" + Environment.NewLine;
                resultado += "!Imagen !! Nombre !! Vida !! Exp !! Oro !! Drop !! Daño !! Defensa !! Evasión !! Nivel" + Environment.NewLine;
                resultado += "|-" + Environment.NewLine;


                for (int i = 1; i <= numNPCs; i++) {

                    //Comprobamos si es hostil
                    string npcTypeStr = parser.GetValue("NPC" + i, "Hostile");

                    if (!string.IsNullOrEmpty(npcTypeStr)) {
                        tipoNPC = int.Parse(npcTypeStr);

                    } else {
                        tipoNPC = 0;

                    }

                    // ¿Es hostil?
                    if (tipoNPC == 1) {

                        resultado += "|[[Archivo:" + i + ".png|thumb]] || " + parser.GetValue("NPC" + i, "Name") + " || " + parser.GetValue("NPC" + i, "MinHP") + " / " + parser.GetValue("NPC" + i, "MaxHP") + " || " + parser.GetValue("NPC" + i, "GiveEXP");
                        resultado += " || " + parser.GetValue("NPC" + i, "GiveGLD") + " || " + parser.GetValue("NPC" + i, "MaxHIT") + " / " + parser.GetValue("NPC" + i, "MinHIT") + "||" + parser.GetValue("NPC" + i, "PoderEvasion") + "||" + parser.GetValue("NPC" + i, "ELV") + "||";
                        resultado += Environment.NewLine + "|-" + Environment.NewLine;

                    }

                }

                resultado += "|}";
                txtResultado.Text = resultado;

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e) {

        }

        private void txtRutaDats_TextChanged(object sender, EventArgs e) {
            rutaDats = txtRutaDats.Text;
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            BuscarCarpeta();
        }

        private void BuscarCarpeta() {
            // Crear una instancia del diálogo de selección de carpetas
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // Configurar las propiedades del diálogo (opcional)
            folderBrowserDialog.Description = "Seleccione la carpeta que desea utilizar";
            folderBrowserDialog.ShowNewFolderButton = true;

            // Mostrar el diálogo y obtener la ruta de la carpeta seleccionada
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK) {
                // Mostrar la ruta de la carpeta seleccionada en el TextBox
                txtRutaDats.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void frmMain_Load(object sender, EventArgs e) {

        }
    }
}
