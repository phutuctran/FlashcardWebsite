﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DBModels.Models
{
    public partial class Accounts
    {
        public Accounts()
        {
            Dictionary = new HashSet<Dictionary>();
            Studies = new HashSet<Studies>();
            Themes = new HashSet<Themes>();
        }

        public string UserName { get; set; }
        public string PassWord { get; set; }
        public DateTime? DateCreate { get; set; }
        public string Role { get; set; }

        public virtual UserInfos UserInfos { get; set; }
        public virtual ICollection<Dictionary> Dictionary { get; set; }
        public virtual ICollection<Studies> Studies { get; set; }
        public virtual ICollection<Themes> Themes { get; set; }
    }
}