﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.ViewModels.ViewModels
{
    public abstract class CreateBaseFamilyViewModel
    {
        [Required(ErrorMessage = "Прізвище не може бути порожнім!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Ім'я не може бути порожнім!")]
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
    }

    public abstract class UpdateBaseFamilyViewModel : CreateBaseFamilyViewModel
    {
        [Required]
        public string HashId { get; set; }
        [Required]
        public string HashIdEmployee { get; set; }
        [Required]
        public uint RowVersion { get; set; }
    }

    //------------------------------------------------------------------------------------------------------------------------------------------

    public class CreateFamilyViewModel : CreateBaseFamilyViewModel
    {
        public DateTime? BirthDate { get; set; }
    }

    public class UpdateFamilyViewModel : UpdateBaseFamilyViewModel
    {
        public DateTime? BirthDate { get; set; }
    }

    //------------------------------------------------------------------------------------------------------------------------------------------

    public class CreateChildrenViewModel : CreateBaseFamilyViewModel
    {
        [Required(ErrorMessage = "Дата народження не може бути порожньою!")]
        public DateTime BirthDate { get; set; }
    }

    public class UpdateChildrenViewModel : UpdateBaseFamilyViewModel
    {
        [Required(ErrorMessage = "Дата народження не може бути порожньою!")]
        public DateTime BirthDate { get; set; }
    }

    //------------------------------------------------------------------------------------------------------------------------------------------

    public class CreateGrandChildrenViewModel : CreateBaseFamilyViewModel
    {
        [Required(ErrorMessage = "Дата народження не може бути порожньою!")]
        public DateTime BirthDate { get; set; }
    }

    public class UpdateGrandChildrenViewModel : UpdateBaseFamilyViewModel
    {
        [Required(ErrorMessage = "Дата народження не може бути порожньою!")]
        public DateTime BirthDate { get; set; }
    }
}