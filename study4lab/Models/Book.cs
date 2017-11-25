using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace study4lab.Models
{
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(1000)]
        public string Title { get; set; }
        public int? AuthorId { get; set; } //может принимать значение NULL
        public Author Author { get; set; } //взаимосвязь
    }
}