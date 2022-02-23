using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arquitetura.Web.WebControls;
using System.Drawing.Imaging;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //wb1.RequestComplete += new EventHandler<TWebRequestEventArgs>(wb1_RequestComplete);
            //wb1.RequestError += new EventHandler<TWebRequestEventArgs>(wb1_RequestError);
            //wb1.RequestClose += new EventHandler<TWebRequestEventArgs>(wb1_RequestClose);

            //DateTime diaAnterior = DateTime.UtcNow.Date.AddDays(-1);
            //string postData = string.Format("data={0}&selFonte=21&projecao=2&selSetor={1}+++", diaAnterior.ToString("yyyy/MM/dd").Replace("/", "%2F"), "CO");

            //wb1.Navigate(new Uri("http://pituna.cptec.inpe.br/acervo/goes_anteriores.jsp"), string.Empty);

            TWebRequest wb1 = new TWebRequest();

            TWebRequestEventArgs e = wb1.Download(new Uri("http://www.redemet.aer.mil.br/sigwx/exibe_imagem.php?ID_REDEMET=eq9ftd5ja08e6fq13c73tf4a42&data=24%2F05%2F2012&imagem=L3Byb2R1dG9zL3NpZ3d4LzIwMTIvMDUvMjQvc2lnaW5mMDAuZ2lm"));

            string caminho = @"C:\Clientes\Infraero\CmaWeb\Teste\Teste.jpg";

            // verifica se existe diretorio
            if (!Directory.Exists(caminho))
            {
                Directory.CreateDirectory(caminho);
            }

            e.Image.Save(caminho, ImageFormat.Jpeg);

            Console.WriteLine("Pressione uma tecla para terminar...");
            Console.ReadKey();
        }

        //static void wb1_RequestError(object sender, TWebRequestEventArgs e)
        //{

        //}

        //static void wb1_RequestClose(object sender, TWebRequestEventArgs e)
        //{
        //    TWebRequest wb1 = (TWebRequest)sender;

        //    DateTime diaAnterior = DateTime.UtcNow.Date.AddDays(-1);
        //    string postData = string.Format("data={0}&selFonte=21&projecao=2&selSetor={1}+++", diaAnterior.ToString("yyyy/MM/dd").Replace("/", "%2F"), "CO");

        //    wb1.Navigate(new Uri("http://pituna.cptec.inpe.br/acervo/goes_anteriores.jsp"), postData);
        //}

        //static void wb1_RequestComplete(object sender, TWebRequestEventArgs e)
        //{

        //}
    }
}
