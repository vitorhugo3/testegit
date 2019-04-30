using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MesmoIP
{
    public partial class MesmoIP : Form
    {


        private BackgroundWorker bgWorker;

        public MesmoIP()
        {

            InitializeComponent();

            bgWorker = new BackgroundWorker();

            //Delegates para o Background Work funcionar
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_OnExecute);
            
            //Executa
            bgWorker.RunWorkerAsync();

        }

        #region bgWorker_OnExecute
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        private void bgWorker_OnExecute(object Sender, EventArgs e) 
        {

            string ipAtual = "";
            string ipAnterior = "";


            while (true) 
            {

                Thread.Sleep(600);

                ipAtual = GetIpExterno();

                if (ipAtual != ipAnterior) 
                {

                    WebRequest request = WebRequest.Create("http://www.contoso.com/");

                    var a = request.GetResponse();

                }


            }    

        
        }
        #endregion

        #region bgWorker_OnFinish
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        private void bgWorker_OnFinish(object Sender, EventArgs e) 
        {
        
        
        
        }
        #endregion


        #region GetIpExterno
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetIpExterno()
        {

            return new System.Net.WebClient().DownloadString("https://api.ipify.org");
        
        }
        #endregion


    }
}
