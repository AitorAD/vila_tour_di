using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientRESTAPI {
    internal class RestClient {
        private String url; // url de nuestra base de datos
        private HttpWebRequest request;

        public RestClient(String url, String tipo) {
            /*
             * Constructor que inicializa las peticiones web, requiere url y GET o POST (o PUT O DELETE)
             * 
             */

            this.url = url;
            this.request = (HttpWebRequest)WebRequest.Create(this.url);
            this.request.Method = "GET";

            switch (tipo) {
                case "GET":
                    this.request.Method = "GET";
                    break;
                case "POST":
                    this.request.Method = "POST";
                    break;
            }

            this.request.ContentType = "application/json";
            request.Accept = "application/json";


        }


        public String getItem() {
            /* Método que hace una peticion get de vuelos por origen
             * 
             */
            try {
                WebResponse response = request.GetResponse();
                Stream strReader = response.GetResponseStream();

                if (strReader != null) {

                    StreamReader sr = new StreamReader(strReader);
                    string str = sr.ReadToEnd();
                    return str;
                } else return null;
            } catch (WebException e) {

                return null;
            }

        }




        public String postItem(String data) {

            /*
             El string data que le pasamos es un json válido de petición post (añadir por ejemplo)
             */

            try {
                Stream strWriter = request.GetRequestStream();
                if (strWriter != null) {
                    StreamWriter sw = new StreamWriter(strWriter);

                    sw.Write(data);
                    sw.Flush();
                    sw.Close();

                    // Hasta aqui hemos hecho la petición POST
                    // Ahora obtenemos la respuesta del server

                    WebResponse response = request.GetResponse();
                    Stream strReader = response.GetResponseStream();
                    if (strReader != null) {
                        StreamReader sr = new StreamReader(strReader);
                        String respuesta = sr.ReadToEnd();
                        return respuesta;
                    }

                } else return null;
            } catch (WebException e) {

                return null;
            }

            return null;
        }



    }
}
