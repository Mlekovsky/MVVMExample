using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Example.Model
{
    public class Opinion
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Author Author { get; set; }


        public String OpinionTextForGrid
        {
            get
            {
                return $"{Text} ~{Author.FullName}";
            }
        }

    }
}
