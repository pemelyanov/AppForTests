﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AppForTests.Shared.Models.DbModels
{
    public partial class Test
    {
        public Test()
        {
            Questions = new HashSet<Question>();
            TestsHistories = new HashSet<TestsHistory>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<TestsHistory> TestsHistories { get; set; }
    }
}