using PatientDataWebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver.Linq;
using System.Web;

namespace PatientDataWebapi
{
    public static class MongoConfig
    {
        public static void Seed()
        {
            var patients = PatientDb.Open();

            if (!patients.AsQueryable().Any(p => p.Name == "Mahak"))
            {
                var data = new List<Patient>()
                {
                    new Patient{Name="Kamal",
                    Ailments=new List<Ailment>(){new Ailment {Name="Headache"}},
                    Medications=new List<Medication>()
                    {
                        new Medication
                        {
                            Name="Crocin"
                        }
                    } } };

                /*new Patient{Name="Aman",
                Ailments=new List<Ailment>(){new Ailment {Name="Stomache"}},
                Medications=new List<Medication>()
                {
                    new Medication
                    {
                        Name="Crocin"
                    }
                },


                new Patient{Name="Jay",
                Ailments=new List<Ailment>(){new Ailment {Name="Body pain"}}
                Medications=new List<Medication>()
                {
                    new Medication
                    {
                        Name="Crocin"
                    }
                },*/
                patients.InsertBatch(data);

                }
            }
        }
    }