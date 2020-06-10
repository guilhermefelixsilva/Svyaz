using System;
using System.Diagnostics;
using System.IO;

namespace Api.Service.Services.Odoo.Docker.Launch
{
    public class Newlaunch
    {
        private string basePath = @"c:\" + "OPENERP";
        private string nomeArquivo;
        private string customerEmail;
        public Newlaunch(string CustomerEmail)
        {
            this.customerEmail = CustomerEmail;
            NewSAAS();
        }

        private void NewSAAS()
        {
            nomeArquivo = basePath + @"\" + customerEmail + @"\odoo11_install" + ".sh";
            StreamWriter writer = new StreamWriter(nomeArquivo);
            writer.WriteLine("#!/bin/bash");
            writer.WriteLine(": " + char.ConvertFromUtf32(0x0027));
            writer.WriteLine("++++++++++++++++++++++++++++++++++++++");
            writer.WriteLine("APENINOS SOFTWARE");
            writer.WriteLine("CUSTOMER INSTANCE: " + customerEmail);
            writer.WriteLine("______________________________________");
            writer.WriteLine(char.ConvertFromUtf32(0x0027));
            writer.WriteLine("cd " + basePath + @"\" + customerEmail + @"\");
            writer.WriteLine("sudo apt-get update - y");
            writer.WriteLine("docker-compose up");
            writer.Close();

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"cd " + (basePath + @"\" + customerEmail + @"\  & sudo sh./ odoo11_install.sh"),
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
        }
    }
}
