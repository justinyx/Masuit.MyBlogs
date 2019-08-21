using Masuit.MyBlogs.Core.Models.Enum;
using Masuit.MyBlogs.Core.Models.Validation;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Masuit.MyBlogs.Core.Models.Entity
{
    /// <summary>
    /// ���ı�
    /// </summary>
    [Table("Broadcast")]
    public class Broadcast : BaseEntity
    {
        public Broadcast()
        {
            Status = Status.Subscribing;
            UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// ���Ľ�������
        /// </summary>
        [IsEmail]
        public string Email { get; set; }

        /// <summary>
        /// ��֤��
        /// </summary>
        public string ValidateCode { get; set; }

        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public SubscribeType SubscribeType { get; set; }
    }
}