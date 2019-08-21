using Masuit.MyBlogs.Core.Models.Entity;
using Masuit.MyBlogs.Core.Models.Enum;
using Masuit.MyBlogs.Core.Models.Validation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Masuit.MyBlogs.Core.Models.DTO
{
    /// <summary>
    /// ���۱�����ģ��
    /// </summary>
    public class CommentInputDto : BaseEntity
    {
        public CommentInputDto()
        {
            Status = Status.Pending;
            IsMaster = false;
        }
        /// <summary>
        /// �ǳ�
        /// </summary>
        [Required(ErrorMessage = "��ȻҪ���ۣ���������ô���أ�"), MaxLength(36, ErrorMessage = "���֣���������̫���˰ɣ�"), MinLength(2, ErrorMessage = "�ǳ�����2���֣�")]
        public string NickName { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [IsEmail]
        public string Email { get; set; }

        /// <summary>
        /// QQ��΢��
        /// </summary>
        [StringLength(32, ErrorMessage = "QQ��΢�Ų��Ϸ�")]
        public string QQorWechat { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Required(ErrorMessage = "�������ݲ���Ϊ�գ�"), SubmitCheck(2, 500)]
        public string Content { get; set; }

        /// <summary>
        /// ����ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// ����ID
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime CommentDate { get; set; }

        /// <summary>
        /// ������汾
        /// </summary>
        [StringLength(255)]
        public string Browser { get; set; }

        /// <summary>
        /// ����ϵͳ�汾
        /// </summary>
        [StringLength(255)]
        public string OperatingSystem { get; set; }

        /// <summary>
        /// �Ƿ��ǲ���
        /// </summary>
        [DefaultValue(false)]
        public bool IsMaster { get; set; }

        /// <summary>
        /// ֧����
        /// </summary>
        public int VoteCount { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public int AgainstCount { get; set; }

        /// <summary>
        /// ������IP
        /// </summary>
        public string IP { get; set; }

    }

}