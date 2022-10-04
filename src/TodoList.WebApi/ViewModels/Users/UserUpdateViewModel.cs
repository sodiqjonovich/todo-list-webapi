﻿using System.ComponentModel.DataAnnotations;

namespace TodoList.WebApi.ViewModels.Users
{
    public class UserUpdateViewModel
    {
        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(50), MinLength(2)]
        [RegularExpression(@"^(?=.{1,40}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$",
            ErrorMessage = "Please enter valid first name. " +
            "First name must be contains only letters or ' character")]
        public string FirstName { get; set; } = String.Empty;

        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(50), MinLength(2)]
        [RegularExpression(@"^(?=.{1,40}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$",
            ErrorMessage = "Please enter valid last name. " +
            "Last name must be contains only letters or ' character")]
        public string LastName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$",
            ErrorMessage = "Please enter valid phone number")]
        public string PhoneNumber { get; set; } = String.Empty;

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "Please enter valid email")]
        public string Email { get; set; } = String.Empty;
    }
}
