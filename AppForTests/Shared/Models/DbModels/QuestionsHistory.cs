﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AppForTests.Shared.Models.DbModels
{
    public partial class QuestionsHistory
    {
        public QuestionsHistory()
        {
            AnswersHistories = new HashSet<AnswersHistory>();
        }

        public int Id { get; set; }
        public int TestHistoryId { get; set; }
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
        public virtual TestsHistory TestHistory { get; set; }
        public virtual ICollection<AnswersHistory> AnswersHistories { get; set; }
    }
}