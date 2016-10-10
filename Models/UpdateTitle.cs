using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FourQuarterMVC.Models
{
    public class UpdateTitle
    {
        [Required(ErrorMessage = "Please Enter Mobile Manufacured")]
        [Display(Name = "Enter Mobile Manufacured")]
        [DataType(DataType.Text)]
        public string MobileManufacured { get; set; }

        [Required(ErrorMessage="Please Enter Dropdown List Value")]
        [Display(Name="Enter DropList Item")]
        [StringLength (30,MinimumLength =5,ErrorMessage ="List Item Must be Between 5 and 30 Character...")]
        public string DDlValues { get; set; }

        [Required(ErrorMessage = "Please Enter Title")]
        [Display(Name = "Enter The Title")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Title Must be Between 10 and 100 Character...")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter Sub Title")]
        [Display(Name = "Enter The Sub Title")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Sub Title Must be Between 10 and 500 Character...")]
        public string  SubTitle { get; set; }

        [Required(ErrorMessage = "Please Select Image")]
        [Display(Name = "Enter Select Image")]
        [DataType(DataType.Text)]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Please Enter The Statements For Div 1...")]
        [Display(Name = "Enter Statement for Div 1...")]
        [StringLength (1000,MinimumLength=50,ErrorMessage="Exeeding Limit")]
        [DataType(DataType.Text)]
        public string Div1 { get; set; }

        [Required(ErrorMessage = "Please Enter The Statements For Div 2...")]
        [Display(Name = "Enter Statement for Div 2...")]
        [StringLength(1000, MinimumLength = 50, ErrorMessage = "Exeeding Limit")]
        [DataType(DataType.Text)]
        public string Div2 { get; set; }

        [Required(ErrorMessage = "Please Enter The Statements For Div 3...")]
        [Display(Name = "Enter Statement for Div 3...")]
        [StringLength(1000, MinimumLength = 50, ErrorMessage = "Exeeding Limit")]
        [DataType(DataType.Text)]
        public string Div3 { get; set; }
        
    }
}