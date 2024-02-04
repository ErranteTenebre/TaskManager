using System.ComponentModel.DataAnnotations;

namespace SimpleTODOLesson.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "���� '�����' ������������ ��� ����������.")]
        [MaxLength(30, ErrorMessage = "����� �� ������ ��������� 30 ��������")]
        public string Login { set; get; }
        [Required(ErrorMessage = "���� 'Pass' ������������ ��� ����������.")]
        [MinLength(8, ErrorMessage = "������ ������ ��������� �� ����� 8 ��������.")]
        public string Pass { set; get; }
        [Compare("Pass", ErrorMessage = "������ �� ���������")]
        public string RePass { set; get; }
    }
}