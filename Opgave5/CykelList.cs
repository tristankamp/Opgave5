using System;
using System.Collections.Generic;
using System.Text;
using Opgave_1;

namespace Opgave5
{
    public static class CykelList
    {
        public static List<Cykel> CykelListe = new List<Cykel>()
        {
            new Cykel(2, "red", 9001, 7),
            new Cykel(3, "blue", 9002, 3),
            new Cykel(4, "yellow", 9003, 2)
        };



            // GET: api/<CykelController>
     
            public static List<Cykel> Get()
            {
                if (CykelListe == null || CykelListe.Count == 0)
                {
                    return CykelListe;
                }

                return null;
            }

            // GET api/<CykelController>/5

            public static Cykel Get(int id)
            {
                if (CykelListe.Exists(i => i.Id == id))
                {
                    return (CykelListe.Find(i => i.Id == id));
                }
                return null;
            }

            // POST api/<CykelController>

            public static void Post(Cykel value)
            {
                int highestId = 0;
                foreach (Cykel c in CykelListe)
                {
                    if (c.Id > highestId)
                    {
                        highestId = c.Id;
                    }
                }
                value.Id = highestId + 1;
                CykelListe.Add(value);
            }
        }
}
