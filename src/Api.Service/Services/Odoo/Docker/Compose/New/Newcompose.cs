using System.IO;

namespace Api.Service.Services.Odoo.Docker.Compose.New
{
    public class Newcompose
    {
        private string nomeArquivo;
        private string customerEmail;
        private string odooPort;
        private string dockerimage;
        private string basePath = @"c:/" + "OPENERP";
        public Newcompose(string CustomerEmail, string OdooPort, string DockerImage)
        {
            this.customerEmail = CustomerEmail;
            this.odooPort = ("- " + char.ConvertFromUtf32(0x0022) + OdooPort + ":8069" + char.ConvertFromUtf32(0x0022));

            this.dockerimage = DockerImage;
            //Docker-compose.yml
            Dockercompose();

        }
        private void Dockercompose() //Docker-compose.yml
        {

            nomeArquivo = basePath + customerEmail + @"\docker-compose" + ".yml";
            StreamWriter writer = new StreamWriter(nomeArquivo);

            writer.WriteLine("# APENINOS SOFTWARE");
            writer.WriteLine("version: '2'");
            writer.WriteLine("services:");
            writer.WriteLine("db:");
            writer.WriteLine("image: apeninos / asasaas_postgres:version9");
            writer.WriteLine("environment:");
            writer.WriteLine("-POSTGRES_PASSWORD = odoo");
            writer.WriteLine("- POSTGRES_USER = odoo");
            writer.WriteLine("odoo11:");
            writer.WriteLine("image: " + dockerimage);
            writer.WriteLine("depends_on:");
            writer.WriteLine("-db");
            writer.WriteLine("ports:");
            writer.WriteLine(odooPort);
            writer.WriteLine("tty: true");
            writer.WriteLine("command: ----dev = reload");
            writer.WriteLine("#    command: odoo scaffold /mnt/extra-addons/test_module");
            writer.WriteLine("volumes:");
            writer.WriteLine("- ./ o_addons:/ mnt / extra - addons");
            writer.WriteLine("- ./ o_etc:/ etc / odoo");
            writer.WriteLine("volumes:");
            writer.WriteLine("db:");
            writer.WriteLine("odoo11:");

            writer.Close();
        }

    }
}
