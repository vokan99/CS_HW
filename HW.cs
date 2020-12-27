/*Вариант C
Двигатель (название модели, серийный номер, тип – бензин или дизель)
Кабина (название модели, серийный номер, тип – стандарт, полярное исполнение, тропическое
исполнение)
Трактор (название модели, серийный номер). В трактор входит один двигатель и одна кабина.
Вариант 1
Реализовать сохранение корневой сущности в XML путем сериализации
Студент Кан В.А. ИУ6-73Б
*/

using System;
using System.Xml.Serialization;
using System.IO;

namespace MyTractor 
{	    
	public class Engine
	{
	    public string EngModel {get; set; }
	    public int EngNumber {get; set; } 
	    public enum EngTypes
	    {
	    	Petrol,
	    	Diesel
	    }
	    public EngTypes EngType {get; set; } 
	}

	public class Cabin
	{
		public enum CabTypes
	    {
	    	Standart,
	    	PolarVersion, 
	    	TropicalVersion
	    }
	    public string CabModel {get; set; }
	    public int CabNumber {get; set; }
	    public CabTypes CabType {get; set; }
	   
	}

	public class Tractor
	{
	    public string TracModel {get; set; }
	    public int TracNumber{get; set; }
	    public Cabin TracCabin;
	    public Engine TracEngine;
	}

	 class Program
   {
        static void Main(string[] args)
        {
            Engine catEngine = new Engine {EngModel = "eng1", EngNumber = 1, EngType = Engine.EngTypes.Diesel};
        	  Cabin catCabin = new Cabin {CabModel = "cab1", CabNumber = 1, CabType = Cabin.CabTypes.PolarVersion};
            Tractor cat = new Tractor { TracModel = "cat1", TracNumber = 1, TracCabin = catCabin, TracEngine = catEngine};
            XmlSerializer formatter = new XmlSerializer(typeof(Train));

            using (FileStream fs = new FileStream("tractor.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, tractor);
            }
        }
    } 
}
