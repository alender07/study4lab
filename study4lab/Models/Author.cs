using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace study4lab.Models
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        public string Years { get; set; }
        public ICollection<Book> Books { get; set; }
        
    }
}