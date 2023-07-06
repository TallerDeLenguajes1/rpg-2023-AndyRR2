namespace EspacioTomarApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using EspacioItems;
using System.Text.Encodings.Web;

public class TomarApi{

    //https://www.dnd5eapi.co/api/magic-schools 
    public void ObtenerItem(){
    var url = $"https://www.dnd5eapi.co/api/magic-schools";
    var request = (HttpWebRequest)WebRequest.Create(url);
    request.Method = "GET";
    request.ContentType =  "aplication/json";
    request.Accept =  "aplication/json";
    try{ 
        using (WebResponse response = request.GetResponse())
        {
            using (Stream str = response.GetResponseStream())
            {
                if (str == null) return;
                {
                    using (StreamReader strR = new StreamReader(str))
                    {
                        string responseBody = strR.ReadToEnd();
                        Items item = JsonSerializer.Deserialize<Items>(responseBody);
                        Console.WriteLine("Numeros de item: {0}",item.count);
                        List<Result> listaNombres = item.results;
                        foreach (var nombre in listaNombres)
                        {
                            Console.WriteLine("Numeros de item: {0}",nombre.name);//pectacular
                        }
                    }
                }
            }
        }
    }
    catch (WebException)
    {
        Console.WriteLine("Problemas en el acceso a la API");
    }
    }
    
}


