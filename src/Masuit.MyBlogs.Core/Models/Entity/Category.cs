using Masuit.MyBlogs.Core.Models.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Masuit.MyBlogs.Core.Models.Entity
{
    /// <summary>
    /// ���·���
    /// </summary>
    [Table("Category")]
    public class Category : BaseEntity
    {
        public Category()
        {
            Post = new HashSet<Post>();
            Status = Status.Available;
        }
        /// <summary>
        /// ������
        /// </summary>
        [Required(ErrorMessage = "����������Ϊ��"), MaxLength(64, ErrorMessage = "�������������64���ַ�"), MinLength(2, ErrorMessage = "����������2���ַ�")]
        public string Name { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string Description { get; set; }

        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<PostHistoryVersion> PostHistoryVersion { get; set; }
    }
}