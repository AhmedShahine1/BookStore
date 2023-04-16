using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace library.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string description { get; set; }

        public Author Author { get; set; }
    }
}
