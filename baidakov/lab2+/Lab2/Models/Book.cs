using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Models
{
    public class Book
    {
        public int Id { get; set; }                                     //TextBox
        public string Title { get; set; }                               //TextBox
        public string Author { get; set; }                              //TextBox
        public string Description { get; set; }                         //TextArea
        public DateTime Created { get; set; }                           
        public Genre Genre { get; set; }                                //DroplistDown
        public string[] Languages { get; set; }                         //Listbox
        public bool IsPaper { get; set; }                               //Checkbox
        public bool DeliveryRequired { get; set; }                      //Radiobutton
    }
        public enum Genre
        {
        Novel,
        Detective,
        Poem,
        Fantasy,
        History,
        Other
        }
        public enum Language
        {
        English,
        Russian,
        Polish,
        Deutsch
        }
}