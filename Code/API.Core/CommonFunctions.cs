using Code.Domain.Entities;
using Code.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core
{
    public class CommonFunctions
    {
        static List<Tagsmodel> _tags = new List<Tagsmodel>();
        public static List<Tagsmodel> add_dummy_tag(int id)
        {
            _tags = new List<Tagsmodel>();
            int counter = 1;
            while (counter <= id + 20)
            {
                dummy_tag(counter);
                counter++;
            }
            return _tags;
        }
        public static void dummy_tag(int id)
        {
            Random rnd = new Random();

            Tagsmodel model = new Tagsmodel();
            model.Id = id;
            model.Name = "Clothes";
            model.Isactive = true;

            _tags.Add(model);
        }
    }
}
