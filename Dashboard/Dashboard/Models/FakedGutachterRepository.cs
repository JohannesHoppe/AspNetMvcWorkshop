using System;
using System.Collections.Generic;
using System.Linq;
using AutoPoco;
using AutoPoco.DataSources;
using AutoPoco.Engine;

namespace Dashboard.Models
{
    public class FakedGutachterRepository : IGutachterRepository
    {
        public static IList<Gutachter> DemoData { get; private set; }

        static FakedGutachterRepository()
        {
            DemoData = GenerateDemoData();
        }

        public int Create(string vorname, string nachname, string mail)
        {
            int newId = DemoData.Max(c => c.Id);

            var gutachter = new Gutachter
                            {
                                Id = newId,
                                Vorname = vorname,
                                Nachname = nachname,
                                EMail = mail
                            };

            DemoData.Add(gutachter);
            return newId;
        }

        public void Update(Gutachter gutachter)
        {
            var gutachterToChagne = DemoData.FirstOrDefault(c => c.Id == gutachter.Id);
            if (gutachterToChagne != null)
            {
                gutachterToChagne.Vorname = gutachterToChagne.Vorname;
                gutachterToChagne.Nachname = gutachterToChagne.Nachname;
                gutachterToChagne.EMail = gutachterToChagne.EMail;
            }
        }

        public Gutachter Read(int id)
        {
            return DemoData.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Gutachter> ReadAll()
        {
            return DemoData;
        }

        public void Delete(int id)
        {
            var gutachter = DemoData.FirstOrDefault(c => c.Id == id);
            if (gutachter != null)
            {
                DemoData.Remove(gutachter);
            }        
        }


        private static IList<Gutachter> GenerateDemoData()
        {
            IGenerationSessionFactory factory = AutoPocoContainer.Configure(x =>
            {
                x.Conventions(c => c.UseDefaultConventions());
                x.AddFromAssemblyContainingType<Gutachter>();

                x.Include<Gutachter>()
                    .Setup(c => c.Id).Use<IntegerIdSource>()
                    .Setup(c => c.Vorname).Use<FirstNameSource>()
                    .Setup(c => c.Nachname).Use<LastNameSource>()
                    .Setup(c => c.EMail).Use<EmailAddressSource>();
            });

            IGenerationSession session = factory.CreateSession();
            IList<Gutachter> gutachter = session.List<Gutachter>(1001).Get();
            gutachter.RemoveAt(0);
            return gutachter;
        }
    }
}